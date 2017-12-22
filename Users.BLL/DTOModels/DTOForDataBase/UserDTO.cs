using System;

namespace Users.BLL.DTOModels.DTOForDataBase
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string PictureName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateBirth { get; set; }

        public string Gender { get; set; }
    }
}