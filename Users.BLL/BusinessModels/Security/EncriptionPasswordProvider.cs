using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Users.BLL.BusinessModels.Security
{
    public class EncriptionPasswordProvider : IDisposable
    {
        private string _password { get; set; }

        private readonly MD5CryptoServiceProvider _md5Hasher;

        private readonly RNGCryptoServiceProvider _rnGenerator;

        public EncriptionPasswordProvider(string password)
        {
            _md5Hasher = new MD5CryptoServiceProvider();
            _rnGenerator = new RNGCryptoServiceProvider();
            _password = password;
        }

        public string GetHashPassword()
        {
            var bytesPassword = _md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(_password));

            return GetStringHash(bytesPassword);
        }

        private string GetStringHash(IEnumerable<byte> bytes)
        {
            return bytes.Aggregate(string.Empty, (total, next) => total += next.ToString("x2"));
        }

        private bool _disposedValue = false; 

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
