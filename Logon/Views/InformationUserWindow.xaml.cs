using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logon.Users.Data;
using Logon.Users.ViewModels;
using Logon.ViewModels;

namespace Logon
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class InformationUserWindow : Window
    {
        public InformationUserWindow(ObservableCollection<UserContract> users, UserContract user)
        {
            InitializeComponent();
            DataContext = new InformationUserViewModel(users, user, this);
        }
    }
}
