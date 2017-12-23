using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserDto : IMapBuilder<UserDto, UserContract>
    {
        public UserDto GetMapOne(UserContract source)
        {
            var userDto = new UserDto
            {
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                PictureName = source.PictureName,
                DateBirth = source.DateBirth
            };

            return userDto;
        }

        public List<UserDto> GetMapList(List<UserContract> source)
        {
            var userDtos = new List<UserDto>();

            source.ForEach(item => userDtos.Add(GetMapOne(item)));

            return userDtos;
        }
    }
}