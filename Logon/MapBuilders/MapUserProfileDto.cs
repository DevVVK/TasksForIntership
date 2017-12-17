using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapUserProfileDto : IMapBuilder<UserProfileDto, UserProfileContract>
    {
        private readonly MapPictureDto _mapperPictureDto = new MapPictureDto();

        private readonly MapUserDto _mappeMapUserDto = new MapUserDto();

        public UserProfileDto GetMapOne(UserProfileContract source)
        {
            var userProfile = new UserProfileDto
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Year = source.Year,
                Month = source.Month,
                Day = source.Day,
                Gender = source.Gender,

                Picture = _mapperPictureDto.GetMapOne(source.Picture),
                User = _mappeMapUserDto.GetMapOne(source.User)
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