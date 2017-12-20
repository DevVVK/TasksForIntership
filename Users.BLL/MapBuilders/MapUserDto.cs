using System.Collections.Generic;
using Users.BLL.BusinessModels.Date;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUserDto : IMapBuilder<UserDto, User>
    {
        public UserDto GetMapOne(User source)
        {
            var dateConverter = new DateFormConverter(source.DateBirth);
            var date = dateConverter.Form;

            var userDto = new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                Salt = source.Salt,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                PictureName = source.NamePicture,
                Month = date.Month,
                Year = date.Year,
                Day = date.Day
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