using System.Collections.Generic;
using Logon.Contracts;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;

namespace Logon.MapBuilders
{
    public class MapPictureContract : IMapBuilder<PictureContract, PictureDto>
    {
        private readonly MapUserProfileContract _mapperUserProfileContract = new MapUserProfileContract();

        public PictureContract GetMapOne(PictureDto source)
        {
            var pictureContract = new PictureContract
            {
                Id = source.Id,
                PictureName = source.PictureName,

                Profile = _mapperUserProfileContract.GetMapOne(source.Profile)
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