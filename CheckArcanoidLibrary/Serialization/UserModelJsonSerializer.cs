using System.IO;
using System.Runtime.Serialization.Json;

namespace CheckArcanoidLibrary.Serialization
{
    public class JsonSerializer<TModel>
    {
        private readonly DataContractJsonSerializer _jsonSerializer = new DataContractJsonSerializer(typeof(TModel));

        private string FilePath { get; }

        public JsonSerializer(string filePath)
        {
            FilePath = filePath;
        }

        public void Serialize(TModel userList)
        {
            if (ExistsFile())
                ClearFile();

            using (var fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                _jsonSerializer.WriteObject(fs, userList);
            }
        }

        public TModel Deserialize()
        {
            using (var fs = new FileStream(FilePath, FileMode.Open))
            {
                return (TModel)_jsonSerializer.ReadObject(fs);
            }
        }

        private void ClearFile()
        {
            using (File.Open(FilePath, FileMode.Truncate))
            {
                
            }
        }

        public bool ExistsFile()
        {
            return File.Exists(FilePath);
        }
    }
}