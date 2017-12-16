using System.Collections.Generic;
using Users.BLL.DTOModels.DTOForDataBase;
using UsersDAL.Repositories.UnitOfWorks;

namespace Logon.Commands
{
    public class AddUserCommand : Logon.Commands.BaseCommand.BaseCommand
    {
        private IList<UserProfileDto> _userProfiles;

        public UserProfileDto _profile;

        public AddUserCommand(IList<UserProfileDto> userProfile)
        {
            _userProfiles = userProfile;
            _profile = new UserProfileDto();
        }

        public override bool CanExecute(object parameter) => _userProfiles != null && _profile != null;

        public override void Execute(object parameter)
        {
            using (var dataBase = new UnitOfWork())
            {
                
            }
        }
    }
}