using System.Collections.Generic;
using Users.BLL.BusinessModels.Date;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUser : IMapBuilder<User, UserDto>
    {
        public User GetMapOne(UserDto source)
        {
            var date = new  DateConverter(source.Year, source.Month, source.Day);

            var user = new User
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                Salt = source.Salt,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                DateBirth = date.DateTime
            };

            return user;
        }

        public List<User> GetMapList(List<UserDto> source)
        {
            var users = new List<User>();

            source.ForEach(item => users.Add(GetMapOne(item)));

            return users;
        }
    }
}