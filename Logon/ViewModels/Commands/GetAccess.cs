using System.Collections.Generic;
using UsersDAL.Entities;

namespace Users.BLL.Infrastructure.Commands
{
    internal class GetAccess : Logon.Commands.BaseCommand.BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
