using System.IO;
using System.Runtime.Serialization.Json;

namespace StudentCard
{
    public class JsonSerializer
    {
        private Student _student { get; }
        
        private readonly DataContractJsonSerializer _serializer;

        public JsonSerializer()
        {
            _serializer = new DataContractJsonSerializer(typeof(Student));
        }

        public JsonSerializer(Student student) : this()
        {
            _student = student;
        }

        public Student GetStudentCardFromDeserializationFile(string _filePath)
        {
            var student = new Student();
            using (var fstream = new FileStream(_filePath, FileMode.Open))
            {
                student = (Student)_serializer.ReadObject(fstream);
            }

            return student;
        }

        public void GetSerializationFile(string _filePath)
        {
            using (var fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                _serializer.WriteObject(fs, _student);
            }
        }
    }
}