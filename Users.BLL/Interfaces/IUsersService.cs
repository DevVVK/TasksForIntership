using System;
using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;

namespace Users.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс дял взаимодействия уровня доступа к данным и уровня представления, 
    /// для обмена моделями данных 
    /// </summary>
    public interface IUsersService : IDisposable
    {
        void AddUser(UserDto user);

        List<UserDto> GetAllUsers();

        UserDto GetUserOne(int id);

        void UpdateUser(UserDto user);

        void DeleteUser(int id);

        bool GetCheckResult(int id, string login, string password);

        new void Dispose();
    }
}