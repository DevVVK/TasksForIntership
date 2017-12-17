using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapPictureDto : IMapBuilder<PictureDto, PictureContract>
    {
        private readonly MapUserProfileDto _mapperUserProfileDto = new MapUserProfileDto();

        public PictureDto GetMapOne(PictureContract source)
        {
            var pictureDto = new PictureDto
            {
                Id = source.Id,
                PictureName = source.PictureName,

                Profile = _mapperUserProfileDto.GetMapOne(source.Profile)
            };

            return pictureDto;
        }

        public List<PictureDto> GetMapList(List<PictureContract> source)
        {
            var pictureDtos = new List<PictureDto>();

            source.ForEach(item => pictureDtos.Add(GetMapOne(item)));

            return pictureDtos;
        }
    }
}