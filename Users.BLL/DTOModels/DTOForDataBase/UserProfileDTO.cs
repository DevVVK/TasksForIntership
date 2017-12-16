using System;
using UsersDAL.Entities;

namespace Users.BLL.DTOModels.DTOForDataBase
{
    public class UserProfileDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public string Gender { get; set; }
    }
}