using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Logon.Contracts;
using Logon.MapBuilders;
using Logon.Properties;
using Logon.ViewModels.Commands;
using Users.BLL.Services;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Logon.ViewModels
{
    public class RegistrationVm
    {
        public UserContract User { get; set; }

        private ObservableCollection<UserContract> _contracts;

        private readonly RegistrationWindow _link;

        public RegistrationVm(ObservableCollection<UserContract> contracts, RegistrationWindow link)
        {
            _contracts = contracts;
            _link = link;
            User = new UserContract();
            AddPhotoCommand = new BaseCommandRelay(AddPhoto);
        }

        #region Commands

        public BaseCommandRelay AddPhotoCommand { get; }

        #endregion

        #region Methods

        private readonly Regex _expressonError = new Regex(@"^[a-zA-Z][a-zA-Z0-9_\.]*$");
        
        private string CheckPasswords(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password))
            {
                return $"Это поле должно быть заполнено";
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                return $"Это поле должно быть заполнено";
            }
            if (password.Length < 9)
            {
                return $"Пароль должен содоержать не менее 10 символов";
            }
            if (!_expressonError.IsMatch(password))
            {
                return $"Пароль должен содержать символы и числа";
            }
            if (!object.Equals(password, confirmPassword))
            {
                return $"Пароли дожны совпадают";
            }

            return string.Empty;
        }

        private readonly MapUserDto _mapperDto = new MapUserDto();

        public void AddUser(PasswordBox password, PasswordBox confirmPasssword)
        {
            if (User.HasErrorsFields) return;

            if (!object.Equals(CheckPasswords(password.Password, confirmPasssword.Password), string.Empty))
            {
                User.ToolTypePasswordError = CheckPasswords(password.Password, confirmPasssword.Password);
                User.VisibleErrorPasword = Visibility.Visible;
                User.VisibleErrorConfirmPassword = Visibility.Visible;
                return;
            }

            User.Password = password.Password;

            _contracts.Add(User);

            using (var userService = new UserService()) userService.AddUser(_mapperDto.GetMapOne(User));

            _link.Close();
        }

        private readonly int _photoId = Guid.NewGuid().GetHashCode();

        private void AddPhoto(object parameter)
        {
            var openFileDialog = new OpenFileDialog { Filter = $"Файлы изображений |*.png; *.jpg" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        User.Photo = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }

                    User.PictureName = $@"{_photoId}{Path.GetFileName(openFileDialog.FileName)}";
                    File.Copy(openFileDialog.FileName, Resources.PhotoPath + User.PictureName, true);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Ошибка");
                }
            }
        }

        #endregion
    }
}