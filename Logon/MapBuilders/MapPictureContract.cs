using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapPictureContract : IMapBuilder<PictureContract, PictureDto>
    {
        public PictureContract GetMapOne(PictureDto source)
        {
            var pictureContract = new PictureContract
            {
                PictureName = source.PictureName
            };

            return pictureContract;
        }

        public List<PictureContract> GetMapList(List<PictureDto> source)
        {
            var pictureContracts = new List<PictureContract>();

            source.ForEach(item => pictureContracts.Add(GetMapOne(item)));

            return pictureContracts;
        }
    }
}