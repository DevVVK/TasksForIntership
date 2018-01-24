using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.Users.Data.MapBuilders
{
    /// <summary>
    /// Класс отображения модели <see cref="UserDto"/> на модель <see cref="UserContract"/> 
    /// </summary>
    public class MapUserContract : IMapBuilder<UserContract, UserDto>
    {
        #region Методы

        /// <summary>
        /// Получает модель <see cref="UserContract"/>
        /// </summary>
        /// <param name="source">объект источник см. <see cref="UserDto"/></param>
        /// <returns></returns>
        public UserContract GetMapOne(UserDto source)
        {
            if (source == null) return null;

            var userContract = new UserContract
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                ExtensionPicture = source.ExtensionPicture,
                DateBirth = source.DateBirth,
                Avatar = source.Avatar
            };

            return userContract;
        }

        /// <summary>
        /// Получает список отображенных объектов модели <see cref="UserContract"/>
        /// </summary>
        /// <param name="source">список объектов <see cref="UserDto"/></param>
        /// <returns></returns>
        public List<UserContract> GetMapList(List<UserDto> source)
        {
            if (source == null) return null;

            var userContracts = new List<UserContract>();

            source.ForEach(item => userContracts.Add(GetMapOne(item)));

            return userContracts;
        }

        #endregion
    }
}