using System;
using System.IO;
using Newtonsoft.Json;

namespace CRUD_OOP2
{
    public class JsonSerial
    {
        public string FilePath = "Serial.json";

        public string FileExtens = ".json";

        public void Serialize(Object itemList)
        {
            string jsonObject = JsonConvert.SerializeObject(itemList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });

            using ( StreamWriter fs = new StreamWriter(FilePath))
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
}
