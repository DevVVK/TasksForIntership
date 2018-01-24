using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersDAL.Entities
{
    /// <summary>
    /// Сущность пользователь
    /// </summary>
    public class User
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Свойство хранящее логин
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        /// <summary>
        /// Свойство хранящее пароль
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// Свойство хранящее Имя
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Свойство хранящее Фамилию
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Свойство хранящее пол
        /// </summary>
        [StringLength(4)]
        public string Gender { get; set; }

        /// <summary>
        /// Свойство хранящее дату рождения
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Свойство хранящее название ссылку на файл
        /// </summary>
        public string PictureName { get; set; }

        #endregion
    }
}