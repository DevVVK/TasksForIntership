using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Users.BLL.BusinessLogic.Logers;
using Users.BLL.BusinessLogic.Security;
using Users.BLL.DTOModels.DTOForDataBase;
using Users.BLL.Interfaces;
using Users.BLL.MapBuilders.UnitOfWork;
using Users.BLL.Properties;
using UsersDAL.Repositories.UnitOfWorks;

namespace Users.BLL.Services
{
    /// <summary>
    /// Класс взаимодеяствия уровня доступа к данным с уровнем представления
    /// </summary>
    public class UserService : IUsersService
    {
        #region Закрытые поля

        /// <summary>
        /// Поле объекта см. <see cref="UnitOfWork"/>
        /// </summary>
        private UnitOfWork DataBase { get; }

        /// <summary>
        /// Поле объекта см. <see cref="UnitOfWorkMapper"/>
        /// </summary>
        private UnitOfWorkMapper Mapper { get; }

        /// <summary>
        /// Поле объекта см. <see cref="LogUsers"/>
        /// </summary>
        private LogUsers Logger { get; }

        #endregion

        #region Конструторы

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public UserService()
        {
            DataBase = new UnitOfWork();
            Mapper = new UnitOfWorkMapper();
            Logger = new LogUsers("LoginsAndPasswordsUsers.txt");
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет пользователя в бд 
        /// </summary>
        /// <param name="source">промежуточная модель см. <see cref="UserDto"/></param>
        public void AddUser(UserDto source)
        {
            Logger.Add(source);

            using (var md5Hasher = new EncriptionPasswordProvider(source.Password))
            {
                source.Password = md5Hasher.GetHashPassword();
            }

            var addUser = Mapper.MapUser.GetMapOne(source);

            var filePath = $"{Resources.FileImageDirectory}{addUser.PictureName}";

            if (source.Avatar != null)
                AddImageInCurrentDirectory(source.Avatar, filePath);

            DataBase.Users.Add(addUser);
        }

        /// <summary>
        /// Получает список всех пользователей в бд
        /// </summary>
        /// <returns>список пользователей отображенных на промежуточную модель см. <see cref="UserDto"/></returns>
        public List<UserDto> GetAllUsers()
        {
            var users = DataBase.Users.GetAll();

            return Mapper.MapUserDto.GetMapList(users);
        }

        /// <summary>
        /// Проверяет на правильность введенного пароля и логина пользователя
        /// </summary>
        /// <param name="id">идентификатор ползователя</param>
        /// <param name="login">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns>true - если данные верны иначе false</returns>
        public bool GetCheckResult(int id, string login, string password)
        {
            var user = Mapper.MapUserDto.GetMapOne(DataBase.Users.GetOne(id));

            using (var md5Hasher = new EncriptionPasswordProvider(password))
            {
                if (user.Login == login && user.Password == md5Hasher.GetHashPassword())
                   return true;
            }

            return false;
        }

        /// <summary>
        /// Получает пользователя по идентификатору
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>пользователь отображенный на промежуточную модель см. <see cref="UserDto"/></returns>
        public UserDto GetUserOne(int id)
        {
            var user = DataBase.Users.GetOne(id);

            return Mapper.MapUserDto.GetMapOne(user);
        }

        /// <summary>
        /// Обновляет данные пользователя
        /// </summary>
        /// <param name="user">промежуточная модель см. <see cref="UserDto"/></param>
        public void UpdateUser(UserDto user)
        {
            var updateUser = Mapper.MapUser.GetMapOne(user);

            DataBase.Users.Update(updateUser);
        }

        /// <summary>
        /// Удаляет пользователя 
        /// </summary>
        /// <param name="id">идентификатор пользователя требующий удаления</param>
        public void DeleteUser(int id)
        {
            var deleteUser = DataBase.Users.GetOne(id);

            if (deleteUser.PictureName != null) DeleteFile(deleteUser.PictureName);
            
            DataBase.Users.Delete(deleteUser);
        }

        #endregion

        #region Методы (helpers)

        /// <summary>
        /// Удаляет файл изображение из директории
        /// </summary>
        /// <param name="fileName"></param>
        private void DeleteFile(string fileName)
        {
            try
            {
                File.Delete($@"{Resources.FileImageDirectory}{fileName}");
            }
            catch (FileNotFoundException)
            {
                return;
            }
        }

        /// <summary>
        /// Добавляет файл в указанную директорию
        /// </summary>
        /// <param name="picture">изображение для сохранения</param>
        /// <param name="filePath">путь сохранения</param>
        private void AddImageInCurrentDirectory(BitmapSource picture, string filePath)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(picture));

            try
            {
                using (var stream = File.Open(filePath, FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Ошибка", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Очистка памяти
        /// </summary>
        public void Dispose()
        {
            DataBase?.Dispose();
        }

        #endregion
    }
}