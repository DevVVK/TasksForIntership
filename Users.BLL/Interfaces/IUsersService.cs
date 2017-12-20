using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;

namespace Users.BLL.Interfaces
{
    public interface IUsersService
    {
        void AddUser(UserDto user);

        List<UserDto> GetAllUsers();

        UserDto GetUserOne(int id);

        void UpdateUser(UserDto user);

        void DeleteUser(UserDto user);

        void Dispose();
    }
}