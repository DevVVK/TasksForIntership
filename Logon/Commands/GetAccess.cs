using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Users.BLL.Infrastructure.Commands;
using UsersDAL.Entities;

namespace Users.BLL.Infrastructure.Commands
{
    internal class GetAccess : Logon.Commands.BaseCommand.BaseCommand
    {
        private IList<UserProfile> _userDataProfiles;

        public GetAccess(IList<UserProfile> profiles)
        {
            _userDataProfiles = profiles;
        }

        public override bool CanExecute(object parameter)
        {
            return _userDataProfiles != null && _userDataProfiles.Count > 0;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
