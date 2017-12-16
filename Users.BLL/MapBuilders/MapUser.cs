using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUser : IMapBuilder<User, UserDto>
    {
        private readonly MapUserProfile _mapper = new MapUserProfile();

        public User GetMapOne(UserDto source)
        {
            var user = new User
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                Salt = source.Salt,

                Profile = _mapper.GetMapOne(source.Profile)
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