using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRUD_OOP2
{
    interface TransportSerialize
    {
        string FilePath { get; set;}
        string FileExtens { get;}
        void Serialize(Object itemList);
        Object DeSerialize();
    }

    class BinSerial : TransportSerialize
    {
        public string FilePath { get; set;}

        public string FileExtens { get { return ".dat"; } }

        public void Serialize(Object itemList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // файл для записи сериализованного объекта
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                formatter.Serialize(fs, itemList);
            }
        }

        public Object DeSerialize()
        {
            Object Return_Object = null;
            // десериализация из файла
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Return_Object = (Object)formatter.Deserialize(fs);
            }

            return Return_Object;
        }

    }

    public class JsonSerial : TransportSerialize
    {
        public string FilePath { get; set;}

        public string FileExtens { get { return ".json"; } }

        public void Serialize(Object itemList)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            // файл для записи сериализованного объекта
            using (StreamWriter fs = new StreamWriter(FilePath))
            {
                fs.Write(jsonObject);
            }
        }
        public Object DeSerialize()
        {
            string jsonObject = String.Empty;

            // десериализация из файла
            using (StreamReader Sr = new StreamReader(FilePath))
            {
                jsonObject = Sr.ReadToEnd();
            }

            object Return_Object = JsonConvert.DeserializeObject<Object>(jsonObject, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All

            });

            return Return_Object;
        }

    }

    public class JcotSerial : TransportSerialize
    {
        public string FilePath { get; set;}

        public string FileExtens { get { return ".jcot"; } }

        public void Serialize(Object itemList)
        {
            JcotFormatter formatter = new JcotFormatter();
            // файл для записи сериализованного объекта
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                formatter.Serialize(fs, itemList);
            }
        }

        public Object DeSerialize()
        {
            Object Return_Object = null;
            // десериализация из файла
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                JcotFormatter formatter = new JcotFormatter();
                Return_Object = (Object)formatter.Deserialize(fs);
            }

            return Return_Object;
        }


    }
}
