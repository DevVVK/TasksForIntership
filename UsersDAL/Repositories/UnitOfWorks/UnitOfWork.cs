using System;

namespace UsersDAL.Repositories.UnitOfWorks
{
    public class UnitOfWork : IDisposable
    {
        private PictureRepository _pictureRepository;

        private UserRepository _userRepository;

        private UserProfileRepository _userProfileRepository;


        public PictureRepository Pictures => _pictureRepository ?? (_pictureRepository = new PictureRepository());

        public UserRepository Users => _userRepository ?? (_userRepository = new UserRepository());

        public UserProfileRepository Profiles => _userProfileRepository ?? (_userProfileRepository = new UserProfileRepository());

        
        public void Dispose()
        {
            _pictureRepository?.Dispose();
            _userRepository?.Dispose();
            _userProfileRepository?.Dispose();
        }
    }
}