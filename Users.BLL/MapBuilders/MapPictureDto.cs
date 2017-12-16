using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapPictureDto : IMapBuilder<PictureDto, Picture>
    {
        private readonly MapUserProfileDto _mapper = new MapUserProfileDto();

        public PictureDto GetMapOne(Picture source)
        {
            var pictureDto = new PictureDto
            {
                Id = source.Id,
                PictureName = source.NamePicture,

                Profile = _mapper.GetMapOne(source.Profile)
            };

            return pictureDto;
        }

        public List<PictureDto> GetMapList(List<Picture> source)
        {
            var pictureDto = new List<PictureDto>();

            source.ForEach(item => pictureDto.Add(GetMapOne(item)));

            return pictureDto;
        }
    }
}