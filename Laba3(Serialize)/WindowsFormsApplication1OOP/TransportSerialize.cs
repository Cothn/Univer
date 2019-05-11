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
        string FilePath { get;}
        string FileExtens { get;}
        void Serialize(Object itemList);
        Object DeSerialize();
    }

    class BinSerial : TransportSerialize
    {
        public string FilePath { get; }

        public string FileExtens { get { return ".dat"; } }

        public BinSerial(string SerializeFilePath)
        {
            FilePath = SerializeFilePath;
        }

        public void Serialize(Object itemList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, itemList);
            }
        }

        public Object DeSerialize()
        {
            Object Return_Object = null;
            // десериализация из файла people.dat
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
        public string FilePath { get; }

        public string FileExtens { get { return ".json"; } }

        public JsonSerial(string SerializeFilePath)
        {
            FilePath = SerializeFilePath;
        }

        public void Serialize(Object itemList)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            using (StreamWriter fs = new StreamWriter(FilePath))
            {
                fs.Write(jsonObject);
            }
        }
        public Object DeSerialize()
        {
            string jsonObject = String.Empty;

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
        public string FilePath { get; }

        public string FileExtens { get { return ".jcot"; } }

        public JcotSerial(string SerializeFilePath)
        {
            FilePath = SerializeFilePath;
        }

        public void Serialize(Object itemList)
        {
            JcotFormatter formatter = new JcotFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, itemList);
            }
        }

        public Object DeSerialize()
        {
            Object Return_Object = null;
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                JcotFormatter formatter = new JcotFormatter();
                Return_Object = (Object)formatter.Deserialize(fs);
            }

            return Return_Object;
        }


    }
}
