using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CheckArcanoidLibrary.Models
{
    [DataContract]
    public class UserListModel
    {
        [DataMember]
        public List<UserModel> Users = new List<UserModel>();
    }
}