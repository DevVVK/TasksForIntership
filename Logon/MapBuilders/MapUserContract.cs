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
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,
                PictureName = source.PictureName,
                DateBirth = source.DateBirth
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