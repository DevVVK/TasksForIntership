namespace Logon.Contracts
{
    public class PictureContract
    {
        public int Id { get; set; }

        public string PictureName { get; set; }

        public UserProfileContract Profile { get; set; }
    }
}