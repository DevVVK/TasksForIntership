using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserDto : IMapBuilder<UserDto, UserContract>
    {
        private readonly MapUserProfileDto _mapperUserProfileDto = new MapUserProfileDto();

        public UserDto GetMapOne(UserContract source)
        {
            var userDto = new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,

                Profile = _mapperUserProfileDto.GetMapOne(source.Profile)
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