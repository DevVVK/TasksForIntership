using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersDAL.Entities
{
    public class Picture
    {
        [Key]
        [ForeignKey("Profile")]
        public int Id { get; set; }

        [Required]
        public string NamePicture { get; set; }

        public UserProfile Profile { get; set; }
    }
}
