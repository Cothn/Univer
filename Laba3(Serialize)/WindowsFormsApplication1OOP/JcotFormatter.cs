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
        private List<Object> ObjectId = new List<Object>();

        const string ArrayFirst = "[\n";
        const string ArrayEnd = "]";
        const string ClassFirst = "{\n";
        const string ClassEnd = "}";
        const string TypeStr = "type";
        const string Field_Valye = ": ";
        const string After_Valye = "\n";
        const string StringFirst = "\"";
        const string StringEnd = "\"";
        const string StrId = "Id";
        const string Ref = "&ref";

        public void Serialize(Stream SerializationStream, object SerializeObject)
        {

            buff = buff + ClassFirst + TypeStr + Field_Valye + SerializeObject.GetType().FullName + "\n";
            FieldInfo[] fields = SerializeObject.GetType().GetFields();
            if (fields.Length == 0)
            {
                buff = buff + "valye" + Field_Valye;
                SerializeField(SerializeObject);
            }
            else
            {
                SerializeClass(SerializeObject);
            }

            buff = buff + ClassEnd;
            byte[] ByteBuff = Encoding.Unicode.GetBytes(buff);
            SerializationStream.Write(ByteBuff, 0, ByteBuff.Length);
        }

        public void SerializeField(object SerialField)
        {
            //Сиреализация массива
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
                buff = buff + StringFirst + SerialField + StringEnd;
            }
            else if ((SerialField.GetType().IsArray) || (SerialField.GetType().IsEquivalentTo(typeof(List<Object>))))
            {
                Type test = SerialField.GetType();
                buff = buff + ArrayFirst;
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
            buff = buff + ClassFirst;
            //buff = buff + ClassFirst + StrId + Field_Valye + ClassId.ToString() + "\n";
            //поиск совпадения id
            int i = 1;
            int id = 0;
            foreach (var obj in ObjectId)
            {
                if (obj == SerialClass)
                {
                    id = i;
                }
                i++;
            }
            //CountId++;

            if (id != 0)
            {
                //ссылка
                buff = buff + Ref + Field_Valye + id.ToString() + "\n";
            }
            else
            {
                //новый обьект
                ObjectId.Add(SerialClass);
                buff = buff + StrId + Field_Valye + i.ToString() + "\n";
                buff = buff + TypeStr + Field_Valye + SerialClass.GetType().FullName + "\n";
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
            Object Return_Object = null;

            return Return_Object;
        }
    }
}
