using System.Runtime.Serialization;

namespace CheckArcanoidLibrary.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Time { get; set; }
    }
}