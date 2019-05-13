using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace CRUD_OOP2
{
    class JcotFormatter
    {
        private string buff;
        private List<Object> ObjectId; //лист ссылок на обьекты(нужен для ссылочной целостности)

        //константы разделители
        const string ArrayFirst = "[";
        const string ArrayEnd = "]";
        const string ClassFirst = "{";
        const string ClassEnd = "}";
        const string Field_Valye = ": ";
        const char After_Valye = '\n';
        //const char StringFirst = '"';
        //const char StringEnd = '"';
        const string StrId = "%Id";
        const string TypeStr = "^type";
        const string Ref = "&ref";
        const string AnonimVal = "$valye";

        public void Serialize(Stream SerializationStream, object SerializeObject)
        {

            ObjectId = new List<Object>();
            buff = buff + ClassFirst + After_Valye + TypeStr + Field_Valye + SerializeObject.GetType().FullName + After_Valye;
            FieldInfo[] fields = SerializeObject.GetType().GetFields();
      
            if (fields.Length == 0)
            {
                //сохраняем значение при отсутствии свойств 
                ObjectId.Add(SerializeObject);
                buff = buff + AnonimVal + Field_Valye;
                SerializeField(SerializeObject);
            }
            else
            {
                SerializeClass(SerializeObject);
            }

            //вывод
            buff = buff + ClassEnd;
            byte[] ByteBuff = Encoding.Unicode.GetBytes(buff);
            SerializationStream.Write(ByteBuff, 0, ByteBuff.Length);
        }

        public void SerializeField(object SerialField)
        {
            // сиреализация разных типов
            if (SerialField == null)
            {
                buff = buff + "null";
            }
            else if (SerialField.GetType().IsPrimitive)
            {
                buff = buff + SerialField.ToString();
            }
            else if (SerialField.GetType().IsEnum)
            {
                buff = buff + ((int)SerialField).ToString();
            }
            else if (SerialField.GetType() == typeof(string))
            {
                buff = buff + /*StringFirst +*/ SerialField /*+ StringEnd*/;
            }
            else if (SerialField.GetType().GetInterface("ICollection")!= null || SerialField.GetType().GetInterface("IEnumerable") != null) //(SerialField.GetType().IsEquivalentTo(typeof(List<Object>))) ///продумать условие!!!
            {
                //Сиреализация массива
                Type test = SerialField.GetType();
                buff = buff + ArrayFirst + After_Valye;
                foreach (var field in (List<object>)SerialField)
                {
                    SerializeField(field);
                }
                buff = buff + ArrayEnd;
            }
            else
            {

                SerializeClass(SerialField);
            }
            buff = buff + After_Valye;
        }

        public void SerializeClass(object SerialClass)
        {
            buff = buff + ClassFirst + After_Valye;

            //поиск совпадения id
            int i = 0;
            int id = 0;
            foreach (var obj in ObjectId)
            {
                if (obj == SerialClass)
                {
                    id = i;
                }
                i++;
            }

            if (id != 0)
            {
                //ссылка
                buff = buff + Ref + Field_Valye + id.ToString() + After_Valye;
            }
            else
            {
                //новый обьект
                ObjectId.Add(SerialClass);
                buff = buff + TypeStr + Field_Valye + SerialClass.GetType().FullName + After_Valye;
                buff = buff + StrId + Field_Valye + i.ToString() + After_Valye;
                FieldInfo[] fields = SerialClass.GetType().GetFields();
                foreach (var field in fields)
                {
                    buff = buff + field.Name + Field_Valye;
                    SerializeField(field.GetValue(SerialClass));
                }
            }
            buff = buff + ClassEnd;
        }



        public object Deserialize(Stream SerializationStream)
        {
            ObjectId = new List<Object>();
            byte[] JcotByteBuff = new byte[4096];
            int colReadByte;
            // обработка потока ввода
            do
            {
                colReadByte = SerializationStream.Read(JcotByteBuff, 0, 4096);
                buff = buff + Encoding.Unicode.GetString(JcotByteBuff, 0, colReadByte);
            } while (colReadByte == 4096);

            int offset = 2;
            Object Return_Object = DeSerializeClass(buff, ref offset);

            return Return_Object;
        }

        public object DeSerializeClass(string Buff, ref int Offset)
        {
            string FieldName = "";
            Object BuffObject = null;

            //получение имени типа
            Offset = ReadFieldName(Buff, Offset, ref FieldName);
            if (FieldName == Ref)
            {
                BuffObject = ObjectId[Convert.ToInt16(ReadFieldValye(Buff, ref Offset, typeof(Int16)))];

                while (Buff[Offset] != ClassEnd[0])
                    Offset++;
                Offset = Offset + ClassEnd.Length + 1;
                return BuffObject;
            }

            //получение типа
            BuffObject = Type.GetType((string)ReadFieldValye(Buff, ref Offset, typeof(string))).GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes);
            ObjectId.Add(BuffObject);

            //получаем имя поля
            Offset = ReadFieldName(Buff, Offset, ref FieldName);

            if (FieldName == AnonimVal)
            {
                //только при первом вызове
                return ReadFieldValye(Buff, ref Offset, BuffObject.GetType());
            }
            else
            {
                // удаление id
                if (FieldName == StrId)
                {
                    while (Buff[Offset] != After_Valye)
                        Offset++;
                    Offset++;
                }

                //восстановление свойств обьекта
                FieldInfo[] fields = BuffObject.GetType().GetFields();
                while (Buff[Offset] != ClassEnd[0])
                {
                    Offset = ReadFieldName(Buff, Offset, ref FieldName);
                    FieldInfo FI = fields.ToList().Where(field => field.Name == FieldName).First();
                    FI.SetValue(BuffObject, ReadFieldValye(Buff, ref Offset, FI.FieldType));
                }
                Offset = Offset + ClassEnd.Length + 1;
                return BuffObject;
            }

        }
        public int ReadFieldName(string Buff, int Offset, ref string FieldName)
        {
            int i = Offset;
            FieldName = "";
            while (Buff[i] != Field_Valye[0])
            {
                FieldName = FieldName + Buff[i];
                i++;
            }
            i = i + Field_Valye.Length;

            return i;
        }

        public object ReadFieldValye(string Buff, ref int Offset, Type FieldType)
        {
            // строковое представление значения
            string StrFieldValye = "";
            object ReturnObj = null;
            while (Buff[Offset] != After_Valye)
            {
                StrFieldValye = StrFieldValye + Buff[Offset];
                Offset++;
            }
            Offset++;

            // возврат значения
            if (StrFieldValye == "null")
            {
                return null;
            }
            else if (StrFieldValye[0] == ClassFirst[0])
            {
                return DeSerializeClass(Buff, ref Offset); // вложенный класс
            }
            else if ((StrFieldValye[0] == ArrayFirst[0]))
            {
                // массив обьектов
                ReturnObj = new List<Object>();  //другие массивы&&&
                Type ArrElemType = FieldType.GetGenericArguments()[0];
                while (Buff[Offset] != ArrayEnd[0])
                {
                    ((List<Object>)ReturnObj).Add(ReadFieldValye(Buff, ref Offset, ArrElemType));
                }
                Offset = Offset + ArrayEnd.Length + 1;
                return ReturnObj;
            }
            else
            {
                if (FieldType.IsEnum)
                {
                    return Convert.ChangeType(StrFieldValye, typeof(int));
                }
                else
                {
                    return Convert.ChangeType(StrFieldValye, FieldType);
                }
            }
            //return null;
        }

    }



}
