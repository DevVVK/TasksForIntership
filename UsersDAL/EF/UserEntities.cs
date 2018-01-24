using UsersDAL.Entities;

namespace UsersDAL.EF
{
    using System.Data.Entity;

    /// <summary>
    /// �������� �������������� � ��
    /// </summary>
    public class UserEntities : DbContext
    {
        #region �������� ����

        /// <summary>
        /// �������� ������������ ����� ������ <see cref="User"/>>
        /// </summary>
        public DbSet<User> Users { get; set; }

        #endregion

        #region �����������

        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public UserEntities() : base("name=UsersConnection")
        {
        }

        #endregion

        #region ������

        /// <summary>
        /// ����� ���������� ������
        /// </summary>
        /// <param name="modelBuilder">��������� ������</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //�������� ��� ������� DateBirth �� "datetime2" ��� ����������� ����������� ��������
            modelBuilder.Entity<User>().Property(p => p.DateBirth).HasColumnType("datetime2").IsRequired();
        }

        #endregion
    }
}