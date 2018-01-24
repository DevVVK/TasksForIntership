using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using Logon.Users.Data;
using Logon.Users.ViewModels;
using Visibility = System.Windows.Visibility;

namespace Logon.Windows
{
    /// <summary>
    /// Interaction logic for LogonWindow.xaml
    /// </summary>
    public partial class LogonWindow : Window
    {
        public LogonWindow(ObservableCollection<UserContract> users, int id)
        {
            InitializeComponent();
            DataContext = new LogonViewModel(users, id, this);
        }

        private void BtnLogof_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Check()
        {
            LblLang.Text = InputLanguage.CurrentInputLanguage.Culture.DisplayName;

            LblCapsLock.Visibility = Control.IsKeyLocked(Keys.CapsLock) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            Check();
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Check();
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            Check();
        }

        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Check();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            Check();
        }
    }
}
