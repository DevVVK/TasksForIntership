using System.Collections.Generic;
using Logon.Commands.BaseCommand;
using Logon.Contracts;
using Users.BLL.Services;

namespace Logon.ViewModels.Commands
{
    public class AddUserCommand : BaseCommand
    {
        private UserContract _user;

        private IList<UserContract> _contracts;

        private RegistrationWindow _link;

        public AddUserCommand(RegistrationWindow link, IList<UserContract> contracts, UserContract user)
        {
            _user = user;
            _contracts = contracts;
            _link = link;
        }

        public override bool CanExecute(object parameter)
        {
            return _user != null;
        }

        public override void Execute(object parameter)
        {
            using (var userService = new UserService())
            {
                
            }

            _link.Close();
        }
    }
}