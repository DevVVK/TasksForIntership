using System.Collections.Generic;
using Users.BLL.BusinessModels.Security;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using Users.BLL.MapBuilders.UnitOfWork;
using UsersDAL.Repositories.UnitOfWorks;

namespace Users.BLL.Services
{
    public class UserService : IUsersService
    {
        private readonly UnitOfWork _dataBase;

        private readonly UnitOfWorkMapper _mapper;

        public UserService()
        {
            _dataBase = new UnitOfWork();
            _mapper = new UnitOfWorkMapper();
        }

#region CRUD users

        public void AddUser(UserDto user)
        {
            var addUser = _mapper.MapUser.GetMapOne(user);

            var hasher = new EncriptionPasswordProvider(addUser.Password);
            var hashPasswordAndSalt = hasher.GetHashPasswordAndSalt();

            addUser.Password = hashPasswordAndSalt.Password;
            addUser.Salt = hashPasswordAndSalt.Salt;

            _dataBase.Users.Add(addUser);

            if (addUser.Profile != null)
                _dataBase.Profiles.Add(addUser.Profile);

            if (addUser.Profile.Picture != null)
                _dataBase.Pictures.Add(addUser.Profile.Picture);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dataBase.Users.GetAll();

            return _mapper.MapUserDto.GetMapList(users);
        }

        public UserDto GetUserOne(int id)
        {
            var user = _dataBase.Users.GetOne(id);

            return _mapper.MapUserDto.GetMapOne(user);
        }

        public void UpdateUser(UserDto user)
        {
            var updateUser = _mapper.MapUser.GetMapOne(user);

            _dataBase.Users.Update(updateUser);
        }

        public void DeleteUser(UserDto user)
        {
            var deleteUser = _mapper.MapUser.GetMapOne(user);

            if (deleteUser.Profile != null)
            {
                if (deleteUser.Profile.Picture != null)
                    _dataBase.Pictures.Delete(deleteUser.Profile.Picture);

                _dataBase.Profiles.Delete(deleteUser.Profile);
            }

            _dataBase.Users.Delete(deleteUser);
        }

        #endregion

#region CRUD Profile

        public UserProfileDto GetUserProfileOne(int id)
        {
            var profile = _dataBase.Profiles.GetOne(id);

            return _mapper.MapUserProfileDto.GetMapOne(profile);
        }

        public IEnumerable<UserProfileDto> GetAllUserProfiles()
        {
            var userProfiles = _dataBase.Profiles.GetAll();

            return _mapper.MapUserProfileDto.GetMapList(userProfiles);
        }

        public void UpdateUserProfile(UserProfileDto userProfileDto)
        {
            var updateUserProfile = _mapper.MapUserProfile.GetMapOne(userProfileDto);

            _dataBase.Profiles.Update(updateUserProfile);
        }

        public void DeleteUserProfile(UserProfileDto userProfileDto)
        {
            var deleteUserProfile = _mapper.MapUserProfile.GetMapOne(userProfileDto);

            if (deleteUserProfile.Picture != null)
                _dataBase.Pictures.Delete(deleteUserProfile.Picture);

            _dataBase.Profiles.Delete(deleteUserProfile);
        }

        #endregion

        public PictureDto GetPicture(int id)
        {
            var picture = _dataBase.Pictures.GetOne(id);

            return _mapper.MapPictureDto.GetMapOne(picture);
        }

        public IEnumerable<PictureDto> GetAllPictures()
        {
            var pictures = _dataBase.Pictures.GetAll();

            return _mapper.MapPictureDto.GetMapList(pictures);
        }

        public void UpdatePicture(PictureDto pictureDto)
        {
            var updatePicture = _mapper.MapPicture.GetMapOne(pictureDto);

            _dataBase.Pictures.Update(updatePicture);
        }

        public void DeletePicture(PictureDto pictureDto)
        {
            var deletePicture = _mapper.MapPicture.GetMapOne(pictureDto);

            _dataBase.Pictures.Delete(deletePicture);
        }

        public void Dispose()
        {
            _dataBase?.Dispose();
        }
    }
}