using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapPicture : IMapBuilder<Picture, PictureDto>
    {
        public Picture GetMapOne(PictureDto source)
        {
            var picture = new Picture
            {
                NamePicture = source.PictureName,
            };

            return picture;
        }

        public List<Picture> GetMapList(List<PictureDto> source)
        {
            var pictures = new List<Picture>();

            source.ForEach(item => pictures.Add(GetMapOne(item)));

            return pictures;
        }
    }
}