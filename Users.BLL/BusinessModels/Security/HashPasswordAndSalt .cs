namespace Users.BLL.BusinessModels.Security
{
    public class HashPasswordAndSalt
    {
        public string Password { get; set; }

        public string Salt { get; set; }

        public HashPasswordAndSalt()
        {

        }

        public HashPasswordAndSalt(string password, string salt)
        {
            Password = password;
            Salt = salt;
        }
    }
}