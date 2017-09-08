using System.Collections.Generic;

namespace StudentCard
{
    public class Student
    {
        public string firstName { get; set; }

        public string patronimycName { get; set; }

        public string lastName { get; set; }

        public Curriculum curriculumList = new Curriculum();

        public List<Adress> addressList = new List<Adress>();

        public List<Contact> contactsList = new List<Contact>();
    }
}
