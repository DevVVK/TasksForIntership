using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logon.Commands.BaseCommand;
using Logon.Contracts;
using Logon.MapBuilders;
using Logon.ViewModels.Commands;
using Users.BLL.Services;

namespace Logon.ViewModels
{
    public class MainVm
    {
        public readonly IList<UserContract> UserDataProfiles;

        private readonly MapUserContract _mapperUserContract = new MapUserContract();
        
        public MainVm()
        {
            using (var userService = new UserService())
            {
                UserDataProfiles = new ObservableCollection<UserContract>(_mapperUserContract.GetMapList(userService.GetAllUsers()));
            }
        }

        private readonly BaseCommand _getRigstrationViewCommand = null;

        public BaseCommand GetReginstrationViewCommand => _getRigstrationViewCommand ?? new GetRegistrationViewCommand(UserDataProfiles);
    }
}