using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserProfileContract : IMapBuilder<UserProfileContract, UserProfileDto>
    {
        private readonly MapPictureContract _mapperPictureContract = new MapPictureContract();

        private readonly MapUserContract _mapperUserContract = new MapUserContract();

        public UserProfileContract GetMapOne(UserProfileDto source)
        {
            var userProfile = new UserProfileContract
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Year = source.Year,
                Month = source.Month,
                Day = source.Day,
                Gender = source.Gender,

                User = _mapperUserContract.GetMapOne(source.User),
                Picture = _mapperPictureContract.GetMapOne(source.Picture)
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