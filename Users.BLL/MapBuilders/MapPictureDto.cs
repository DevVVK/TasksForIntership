using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapPictureDto : IMapBuilder<PictureDto, Picture>
    {
        public PictureDto GetMapOne(Picture source)
        {
            var pictureDto = new PictureDto
            {
                PictureName = source.NamePicture
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