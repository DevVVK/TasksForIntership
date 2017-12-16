using System.Collections.Generic;
using Users.BLL.BusinessModels.Date;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapUserProfile : IMapBuilder<UserProfile, UserProfileDto>
    {
        private DateConverter _dateConverter;

        public UserProfile GetMapOne(UserProfileDto source)
        {
            _dateConverter = new DateConverter(source.Year, source.Month, source.Day);

            var userProfile = new UserProfile
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Gender = source.Gender,

                DateBirth = _dateConverter.DateTime
            };

            return userProfile;
        }

        public List<UserProfile> GetMapList(List<UserProfileDto> source)
        {
            var userProfiles = new List<UserProfile>();

            source.ForEach(item => userProfiles.Add(GetMapOne(item)));

            return userProfiles;
        }
    }
}