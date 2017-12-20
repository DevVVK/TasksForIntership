using System.Collections.Generic;
using Logon.Commands.BaseCommand;
using Logon.Contracts;
using Logon.ViewModels.Commands;

namespace Logon.ViewModels
{
    public class RegistrationVm
    {
        public UserContract User { get; set; }

        private IList<UserContract> _contracts;

        private RegistrationWindow _link;

        public RegistrationVm(IList<UserContract> contracts, RegistrationWindow link)
        {
            _contracts = contracts;
            _link = link;
            User = new UserContract();
        }

        private BaseCommand _addUserCommand = null;

        public BaseCommand AddUserCommand => _addUserCommand ?? new AddUserCommand(_link, _contracts, User);
    }
}