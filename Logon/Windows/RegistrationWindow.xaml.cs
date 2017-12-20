using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Logon.Contracts;
using Logon.ViewModels;

namespace Logon
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private IList<UserContract> _users;

        public RegistrationWindow(IList<UserContract> users)
        {
            InitializeComponent();
            _users = users;

            this.DataContext = new RegistrationVm(_users, this);

            InitializeYearList();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public IList<int> YearList { get; set; }

        private void InitializeYearList()
        {
            YearList = new ObservableCollection<int>();

            for (var i = 1900; i < 2050; i++)
            {
                YearList.Add(i);
            }

            YearBox.ItemsSource = YearList;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
