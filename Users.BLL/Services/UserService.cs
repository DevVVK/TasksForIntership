using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using Users.BLL.MapBuilders.UnitOfWork;
using UsersDAL.Repositories.UnitOfWorks;

namespace Users.BLL.Services
{
    public class UserService : IUsersService
    {
        private UnitOfWork _dataBase;

        private UnitOfWorkMapper _mapper;

        public UserService()
        {
            _dataBase = new UnitOfWork();
            _mapper = new UnitOfWorkMapper();
        }

        public void AddUser(UserDto user)
        {
            var userDal = _mapper.MapUser.GetMapOne(user);

            _dataBase.Users.Add(userDal);
        }

        public IEnumerable<UserDto> GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public UserProfileDto GetUserOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserProfileDto> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserProfile(UserProfileDto userProfileDto)
        {
            throw new System.NotImplementedException();
        }

        public PictureDto GetPicture(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PictureDto> GetAllPictures()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePicture(PictureDto picture)
        {
            throw new System.NotImplementedException();
        }
    }
}