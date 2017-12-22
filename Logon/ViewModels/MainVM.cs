using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logon.Contracts;
using Logon.MapBuilders;
using Logon.ViewModels.Commands;
using Users.BLL.Services;

namespace Logon.ViewModels
{
    public class MainVm
    {
        public ObservableCollection<UserContract> UserDataProfiles { get; set; }

        private readonly MapUserContract _mapperUserContract = new MapUserContract();
        
        public MainVm()
        {
            using (var userService = new UserService())
            {
                //UserDataProfiles = new ObservableCollection<UserContract>(_mapperUserContract.GetMapList(userService.GetAllUsers()));
            }
            UserDataProfiles = new ObservableCollection<UserContract>();

            ShowRegistrationViewCommand = new BaseCommandRelay(ShowRegistrationView);
        }

        #region Commands

        public BaseCommandRelay ShowRegistrationViewCommand { get; }

        #endregion

        #region Methods 

        private void ShowRegistrationView(object parameter)
        {
            var registerWondow = new RegistrationWindow(UserDataProfiles);
            registerWondow.ShowDialog();
        }

        #endregion
    }
}