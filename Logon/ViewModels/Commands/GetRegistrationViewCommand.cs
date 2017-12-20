using System.Collections.Generic;
using Logon.Commands.BaseCommand;
using Logon.Contracts;

namespace Logon.ViewModels.Commands
{
    public class GetRegistrationViewCommand : BaseCommand
    {
        private IList<UserContract> _users;

        public GetRegistrationViewCommand(IList<UserContract> users)
        {
            _users = users;
        }

        public override bool CanExecute(object parameter) => _users != null;

        public override void Execute(object parameter)
        {
            var registerWondow = new RegistrationWindow(_users);

            registerWondow.ShowDialog();
        }
    }
}