using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUserDto : IMapBuilder<UserDto, User>
    {
        private readonly MapUserProfileDto _mapper = new MapUserProfileDto();

        public UserDto GetMapOne(User source)
        {
            var userDto = new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                Salt = source.Salt,

                Profile = _mapper.GetMapOne(source.Profile)
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