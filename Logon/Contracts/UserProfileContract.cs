using Logon.Contracts.Validation;

namespace Logon.Contracts
{
    public class UserProfileContract : BaseValidation
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public string Gender { get; set; }

        public PictureContract Picture { get; set; }

        public UserContract User { get; set; }
    }
}