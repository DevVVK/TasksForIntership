namespace Users.BLL.MapBuilders.UnitOfWork
{
    public class UnitOfWorkMapper
    {
        private MapPicture _mapPicture;

        private MapPictureDto _mapPictureDto;

        private MapUser _mapUser;

        private MapUserDto _mapUserDto;

        private MapUserProfile _mapUserProfile;

        private MapUserProfileDto _mapUserProfileDto;


        public MapPicture MapPicture => _mapPicture ?? (_mapPicture = new MapPicture());

        public MapPictureDto MapPictureDto => _mapPictureDto ?? (_mapPictureDto = new MapPictureDto());

        public MapUser MapUser => _mapUser ?? (_mapUser = new MapUser());

        public MapUserDto MapUserDto => _mapUserDto ?? (_mapUserDto = new MapUserDto());

        public MapUserProfile MapUserProfile => _mapUserProfile ?? (_mapUserProfile = new MapUserProfile());

        public MapUserProfileDto MapUsepProfileDto => _mapUserProfileDto ?? (_mapUserProfileDto = new MapUserProfileDto());
    }
}