using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserProfileContract : IMapBuilder<UserProfileContract, UserProfileDto>
    {
        public UserProfileContract GetMapOne(UserProfileDto source)
        {
            var userProfile = new UserProfileContract
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Year = source.Year,
                Month = source.Month,
                Day = source.Day,
                Gender = source.Gender
            };

            return userProfile;
        }

        public List<UserProfileContract> GetMapList(List<UserProfileDto> source)
        {
            var userProfiles = new List<UserProfileContract>();

            source.ForEach(item => userProfiles.Add(GetMapOne(item)));

            return userProfiles;
        }
    }
}