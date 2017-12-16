namespace Users.BLL.DTOModels.DTOForDataBase
{
    public class PictureDto
    {
        public int Id { get; set; }

        public string PictureName { get; set; }

        public UserProfileDto Profile { get; set; }
    }
}