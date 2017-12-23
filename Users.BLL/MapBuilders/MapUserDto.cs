using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUserDto : IMapBuilder<UserDto, User>
    {
        public UserDto GetMapOne(User source)
        {
            var userDto = new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                PictureName = source.NamePicture,
                DateBirth = source.DateBirth
            };

            return userDto;
        }

        public List<UserDto> GetMapList(List<User> source)
        {
            var userDtos = new List<UserDto>();

            source.ForEach(item => userDtos.Add(GetMapOne(item)));

            return userDtos;
        }
    }
}