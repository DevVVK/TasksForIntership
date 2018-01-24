using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using Users.BLL.Properties;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    /// <summary>
    /// Класс отображения модели <see cref="User"/> на модель <see cref="UserDto"/>
    /// </summary>
    public class MapUserDto : IMapBuilder<UserDto, User>
    {
        #region Методы

        /// <summary>
        /// Получает модель <see cref="UserDto"/>
        /// </summary>
        /// <param name="source">модель источник отображения <see cref="User"/></param>
        /// <returns>модель <see cref="UserDto"/></returns>
        public UserDto GetMapOne(User source)
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
                DateBirth = source.DateBirth
            };

            if (source.PictureName == null) return userDto;

            try
            {
                using (var stream = new FileStream($@"{Resources.FileImageDirectory}{source.PictureName}", FileMode.Open))
                {
                    userDto.Avatar = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
            catch (FileNotFoundException)
            {
                return userDto;
            }

            return userDto;
        }

        /// <summary>
        /// Получает список обьектов <see cref="UserDto"/> 
        /// </summary>
        /// <param name="source">список источника отображения <see cref="User"/></param>
        /// <returns>список отображенных объектов <see cref="UserDto"/></returns>
        public List<UserDto> GetMapList(List<User> source)
        {
            if (source == null) return null;

            var userDtos = new List<UserDto>();

            source.ForEach(item => userDtos.Add(GetMapOne(item)));

            return userDtos;
        }

        #endregion
    }
}