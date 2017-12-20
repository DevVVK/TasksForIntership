namespace Users.BLL.DTOModels.DTOForDataBase
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string PictureName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public string Gender { get; set; }
    }
}