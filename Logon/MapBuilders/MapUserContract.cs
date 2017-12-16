using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserContract : IMapBuilder<UserContract, UserDto>
    {
        public UserContract GetMapOne(UserDto source)
        {
            var userContract = new UserContract
            {
                Login = source.Login,
                Password = source.Password
            };

            return userContract;
        }

        public List<UserContract> GetMapList(List<UserDto> source)
        {
            var userContracts = new List<UserContract>();

            source.ForEach(item => userContracts.Add(GetMapOne(item)));

            return userContracts;
        }
    }
}