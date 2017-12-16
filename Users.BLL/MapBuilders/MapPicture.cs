using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using UsersDAL.Entities;

namespace Users.BLL.MapBuilders
{
    public class MapPicture : IMapBuilder<Picture, PictureDto>
    {
        private readonly MapUserProfile _mapper = new MapUserProfile();

        public Picture GetMapOne(PictureDto source)
        {
            var picture = new Picture
            {
                Id = source.Id,
                NamePicture = source.PictureName,

                Profile =  _mapper.GetMapOne(source.Profile)
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