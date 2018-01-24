using System;
using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    /// <summary>
    /// Класс отображения модели <see cref="UserDto"/> на модель <see cref="User"/>
    /// </summary>
    public class MapUser : IMapBuilder<User, UserDto>
    {
        #region Методы
        
        /// <summary>
        /// Для генерации имени файла изображения
        /// </summary>
        private readonly int _pictureId = Guid.NewGuid().GetHashCode();

        /// <summary>
        /// Получает отображенный обьект <see cref="User"/>
        /// </summary>
        /// <param name="source">модель источника отображения</param>
        /// <returns></returns>
        public User GetMapOne(UserDto source)
        {
            if (source == null) return null;

            var user = new User
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                DateBirth = source.DateBirth,
                PictureName = $"{_pictureId}{source.ExtensionPicture}"
            };

            return user;
        }

        /// <summary>
        /// Получает список отображенных объектов
        /// </summary>
        /// <param name="source">список источник отображения</param>
        /// <returns></returns>
        public List<User> GetMapList(List<UserDto> source)
        {
            if (source == null) return null;

            var users = new List<User>();

            source.ForEach(item => users.Add(GetMapOne(item)));

            return users;
        }

        #endregion
    }
}