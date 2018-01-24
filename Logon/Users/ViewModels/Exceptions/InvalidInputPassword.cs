using System;

namespace Logon.Users.ViewModels.Exceptions
{
    public class InvalidInputPassword : Exception
    {
        public InvalidInputPassword() : base("Пароли не совпадают")
        {
            
        }
    }
}