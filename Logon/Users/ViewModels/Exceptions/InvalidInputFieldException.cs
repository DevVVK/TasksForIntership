using System;

namespace Logon.Users.ViewModels.Exceptions
{
    public class InvalidInputFieldException : Exception
    {
        public InvalidInputFieldException() : base("Заполните поля, которые обозначены - *")
        {

        }
    }
}