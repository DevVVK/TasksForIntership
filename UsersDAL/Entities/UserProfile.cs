using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersDAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(4)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        public Picture Picture { get; set; }

        public User User { get; set; }
    }
}