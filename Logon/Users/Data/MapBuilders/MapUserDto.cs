using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.Users.Data.MapBuilders
{
    /// <summary>
    /// Класс отображения модели <see cref="UserContract"/> на модель <see cref="UserDto"/>
    /// </summary>
    public class MapUserDto : IMapBuilder<UserDto, UserContract>
    {
        #region Методы

        /// <summary>
        /// Получает модель <see cref="UserDto"/>
        /// </summary>
        /// <param name="source">объект источник <see cref="UserContract"/></param>
        /// <returns></returns>
        public UserDto GetMapOne(UserContract source)
        {
            if (source == null) return null;

            var userDto = new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                ExtensionPicture = source.ExtensionPicture,
                Avatar = source.Avatar,
                DateBirth = source.DateBirth
            };

            return userDto;
        }

        /// <summary>
        /// Получает список отображенных объектов модели <see cref="UserDto"/>
        /// </summary>
        /// <param name="source">список объектов источника <see cref="UserContract"/></param>
        /// <returns></returns>
        public List<UserDto> GetMapList(List<UserContract> source)
        {
            if (source == null) return null;

            var userDtos = new List<UserDto>();

            source.ForEach(item => userDtos.Add(GetMapOne(item)));

            return userDtos;
        }

        #endregion
    }
}