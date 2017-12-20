using System;

namespace UsersDAL.Repositories.UnitOfWorks
{
    public class UnitOfWork : IDisposable
    {
        private UserRepository _userRepository;

        public UserRepository Users => _userRepository ?? (_userRepository = new UserRepository());
        
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}