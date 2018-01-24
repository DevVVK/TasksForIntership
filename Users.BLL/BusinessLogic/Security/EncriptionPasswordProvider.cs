using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Users.BLL.BusinessLogic.Security
{
    /// <summary>
    /// Класс хэширующий значение пароля
    /// </summary>
    public class EncriptionPasswordProvider : IDisposable
    {
        #region Закрытые поля

        /// <summary>
        /// Поле содержащее пароль пользователя
        /// </summary>
        private string _password;

        /// <summary>
        /// Поле соеджащее объект хэширующий значение пароля
        /// </summary>
        private readonly MD5CryptoServiceProvider _md5Hasher;

        /// <summary>
        /// Поле содержащее обьект для полущения криптостойкой последовательности байтов 
        /// </summary>
        private readonly RNGCryptoServiceProvider _rnGenerator;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="password">пароль пользователя</param>
        public EncriptionPasswordProvider(string password)
        {
            _md5Hasher = new MD5CryptoServiceProvider();
            _rnGenerator = new RNGCryptoServiceProvider();
            _password = password;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Получает хеш-сумму пароля (md5)
        /// </summary>
        /// <returns></returns>
        public string GetHashPassword()
        {
            var bytesPassword = _md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(_password));

            return GetStringHash(bytesPassword);
        }

        /// <summary>
        /// Получает хеш-сумму пароля в виду строки
        /// </summary>
        /// <param name="bytes">пароль представленный в виде последовательности байтов</param>
        /// <returns></returns>
        private string GetStringHash(IEnumerable<byte> bytes)
        {
            return bytes.Aggregate(string.Empty, (total, next) => total += next.ToString("x2"));
        }

        #endregion

        #region Методы (helpers)

        private bool _disposedValue = false; 

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _md5Hasher.Dispose();
                    _rnGenerator.Dispose();
                    _password = null;
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
