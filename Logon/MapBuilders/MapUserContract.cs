using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserContract : IMapBuilder<UserContract, UserDto>
    {
        private readonly MapUserProfileContract _mapeerUserProfileContract = new MapUserProfileContract();

        public UserContract GetMapOne(UserDto source)
        {
            var userContract = new UserContract
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                
                Profile = _mapeerUserProfileContract.GetMapOne(source.Profile)
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