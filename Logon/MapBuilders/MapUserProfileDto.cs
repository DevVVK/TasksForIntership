using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserProfileDto : IMapBuilder<UserProfileDto, UserProfileContract>
    {
        public UserProfileDto GetMapOne(UserProfileContract source)
        {
            var userProfile = new UserProfileDto
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

        public List<UserProfileDto> GetMapList(List<UserProfileContract> source)
        {
            var userProfileDtos = new List<UserProfileDto>();

            source.ForEach(item => userProfileDtos.Add(GetMapOne(item)));

            return userProfileDtos;
        }
    }
}