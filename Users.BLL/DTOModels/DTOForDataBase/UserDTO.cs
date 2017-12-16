﻿namespace Users.BLL.DTOModels.DTOForDataBase
{
    public class UserDto
    {
        public int Id { get; set; }

        public UserProfileDto Profile { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}