using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;

namespace Users.BLL.Interfaces
{
    public interface IUsersService
    {
        void AddUser(UserDto user);

        IEnumerable<UserDto> GetAllUsers();

        UserDto GetUserOne(int id);

        void UpdateUser(UserDto user);

        void DeleteUser(UserDto user);

        
        UserProfileDto GetUserOne(int id);

        IEnumerable<UserProfileDto> GetAllUserProfiles();

        void UpdateUserProfile(UserProfileDto userProfileDto);

        void DeleteUserProfile(UserProfileDto userProfileDto);


        PictureDto GetPicture(int id);

        IEnumerable<PictureDto> GetAllPictures();

        void UpdatePicture(PictureDto pictureDto);

        void DeletePicture(PictureDto pictureDto);
    }
}