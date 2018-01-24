using System;

namespace Logon.Users.ViewModels.Exceptions
{
    public class InvalidInputIncorrectPassword : Exception
    {
        public InvalidInputIncorrectPassword() : base ("Неверный пароль")
        {
            
        }
    }
}