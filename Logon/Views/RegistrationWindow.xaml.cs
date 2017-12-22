using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Logon.Contracts;
using Logon.ViewModels;

namespace Logon
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(ObservableCollection<UserContract> users)
        {
            InitializeComponent();
            DataContext = new RegistrationVm(users, this);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
