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
        string name { get; }
        string FileExtens { get; }
        void Serialize(Stream fs, Object itemList);
        Object DeSerialize(Stream fs);
    }

    class BinSerial : TransportSerialize
    {
        public string name { get { return "Binary"; } }
        public string FileExtens { get { return ".dat"; } }

        public void Serialize(Stream fs, Object itemList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // файл для записи сериализованного объекта

            formatter.Serialize(fs, itemList);
        }

        public Object DeSerialize(Stream fs)
        {
            Object Return_Object = null;
            // десериализация из файла

            BinaryFormatter formatter = new BinaryFormatter();
            Return_Object = (Object)formatter.Deserialize(fs);

            return Return_Object;
        }

    }

    public class JsonSerial : TransportSerialize
    {
        public string name { get { return "Json"; } }
        public string FileExtens { get { return ".json"; } }

        public void Serialize(Stream fs, Object itemList)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            // файл для записи сериализованного объекта
            StreamWriter Sw = new StreamWriter(fs);
            Sw.Write(jsonObject);
            Sw.Flush();
        }
        public Object DeSerialize(Stream fs)
        {
            string jsonObject = String.Empty;

            // десериализация из файла
            StreamReader Sr = new StreamReader(fs);
            jsonObject = Sr.ReadToEnd();

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
        public string name { get { return "Jcot"; } }
        public string FileExtens { get { return ".jcot"; } }

        public void Serialize(Stream fs, Object itemList)
        {
            JcotFormatter formatter = new JcotFormatter();
            // файл для записи сериализованного объекта

            formatter.Serialize(fs, itemList);
        }

        public Object DeSerialize(Stream fs)
        {
            Object Return_Object = null;
            // десериализация из файла

            JcotFormatter formatter = new JcotFormatter();
            Return_Object = (Object)formatter.Deserialize(fs);
            return Return_Object;
        }


    }
}
