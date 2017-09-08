using System.Collections.Generic;
using System.IO;
using StudentCard.Properties;

namespace StudentCard.Sourсe
{
    public class CRUDStudent
    {
        private string _directory { get; }

        private JsonSerializer _jsonSerializer;

        private readonly Student _student;

        public CRUDStudent()
        {
            _jsonSerializer = new JsonSerializer();
            _directory = Resources.FilePathDirectory;
        }

        public CRUDStudent(Student student):this()
        {
            _student = student;
        }

        private string GetFullFilePath(string fileName)
        {
            return _directory + "\\" + fileName;
        }

        #region CRUD Карточка студента
        public void CreateNewStudentCard(string fileName, Student newStudent)
        {
            _jsonSerializer = new JsonSerializer(newStudent);
            _jsonSerializer.GetSerializationFile(GetFullFilePath(fileName));
        }

        public void UpdateStudentCard(string fileName)
        {
            _jsonSerializer.GetSerializationFile(GetFullFilePath(fileName));
        }

        public Student ReadStudentCard(string fileName)
        {
            return _jsonSerializer.GetStudentCardFromDeserializationFile(GetFullFilePath(fileName));
        }

        public void DeleteStudentCard(string fileName)
        {
            File.Delete(GetFullFilePath(fileName));
        }
        #endregion

        #region CRUD Контакт
        public void CreateNewContact(Contact contact)
        {
            _student.contactsList.Add(contact);
        }

        public void UpdateCurrentContact(Contact contact, Contact newContact, int currentRowIndexContact)
        {
            _student.contactsList.Remove(contact);
            _student.contactsList.Insert(currentRowIndexContact, newContact);
        }

        public List<Contact> GetContactList()
        {
            return _student.contactsList;
        }

        public Contact GetContact(int currentRowIndexContact)
        {
            return _student.contactsList[currentRowIndexContact];
        }

        public void DeleteCurrentContact(Contact contact)
        {
            _student.contactsList.Remove(contact);
        }
        #endregion

        #region CRUD Адреса
        public void CreateNewAdress(Adress adress)
        {
            _student.addressList.Add(adress);
        }

        public void UpdateCurrentAdress(Adress adress, Adress newAdress, int currentRowIndexAdress)
        {
            _student.addressList.Remove(adress);
            _student.addressList.Insert(currentRowIndexAdress, newAdress);
        }

        public List<Adress> GetAdressList()
        {
            return _student.addressList;
        }

        public Adress GetAdress(int currentRowIndexAdress)
        {
            return _student.addressList[currentRowIndexAdress];
        }

        public void DeleteCurrentAdress(Adress adress)
        {
            _student.addressList.Remove(adress);
        }
        #endregion
    }
}