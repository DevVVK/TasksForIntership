using Logon.Contracts.Validation;

namespace Logon.Contracts
{
    public class UserContract : BaseValidation
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}