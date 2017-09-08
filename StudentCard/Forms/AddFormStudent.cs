using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using StudentCard.Properties;
using StudentCard.Sourсe;

namespace StudentCard.Forms
{
    public partial class AddFormStudent : Form
    {
        private CRUDStudent _crudStudent;

        private DataTable contactDataTable;

        private DataTable adressDataTable;

        private DataView contactDataView;

        private DataView adressDataView;

        private MainForm mainForm;

        private Student student;

        private string fileName;

        private int currentRowIndex;

        private FlagAddOrUpdate flag;

        private string _firstNameProperty => FirstNameTextBox.Text;

        private string _patronymicNameProperty => PatronymicNameTextBox.Text;

        private string _lastNameProperty => LastNameTextBox.Text;

        private string _courseProperty => CourseComboBox.Text;

        private string _groupProperty => GroupTextBox.Text;

        private string _facultyProperty => FacultyTextBox.Text;

        private string _specialityPropery => SpecialityTextBox.Text;

        public AddFormStudent()
        {
            InitializeComponent();
            InitialiZeColorFields();
            flag = FlagAddOrUpdate.Addition;
        }

        public AddFormStudent(MainForm mainForm) : this()
        {
            this.mainForm = mainForm;
            student = new Student();
            _crudStudent = new CRUDStudent();
            contactDataTable = CreateDataTableContacts();
            adressDataTable = CreateDataTableAdress();
            AddBindingDataSourceDataTableContact();
            AddBindingSourceDataTableAdress();
            AddButton.Enabled = false;
            SetOptionsForUpdateOrAdditingForm(flag);
        }

        public AddFormStudent(MainForm mainForm, Student student, string fileName, FlagAddOrUpdate flag) : this(mainForm)
        {
            this.student = student;
            this.fileName = fileName;
            this.flag = flag;
            InitializeFieldsAndDataGridsAddFormStudent();
            SetOptionsForUpdateOrAdditingForm(flag);
            SetButtonsContactEnabledOrDisabled();
            SetButtonsAdressEnabledOrDisabled();
            AddButton.Enabled = false;
        }

        private void InitializeFieldsAndDataGridsAddFormStudent()
        {
            FirstNameTextBox.Text = student.firstName;
            PatronymicNameTextBox.Text = student.patronimycName;
            LastNameTextBox.Text = student.lastName;

            CourseComboBox.Text = student.curriculumList.course;
            GroupTextBox.Text = student.curriculumList.group;
            FacultyTextBox.Text = student.curriculumList.faculty;
            SpecialityTextBox.Text = student.curriculumList.speciality;

            RefreshDataTableContacts(student, contactDataTable);
            RefreshDataTableAdress(student, adressDataTable);
            _crudStudent = new CRUDStudent(student);
        }

        private int GetCurrentRowIndexContactDataGridView()
        {
            return ContactsDataAdvancedDataGridView.CurrentRow.Index;
        }

        private int GetCurrentRowIndexAdressDataGridView()
        {
            return AdressAdvancedDataGridView.CurrentRow.Index;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateFileSerializationFile();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.ErrorString, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            mainForm.OpenFileFromDirectory();
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddRowContactButton_Click(object sender, EventArgs e)
        {
            _crudStudent = new CRUDStudent(student);
            using (var newAddFormContacts = new AddFormContacts(contactDataTable, _crudStudent, currentRowIndex, FlagAddOrUpdate.Addition))
            {
                newAddFormContacts.ShowDialog();
            }

            SetButtonsContactEnabledOrDisabled();

        }

        private void UpdateRowContactButton_Click(object sender, EventArgs e)
        {
            currentRowIndex = GetCurrentRowIndexContactDataGridView();
            if (currentRowIndex == null) return;
            using (var newAddFormContacts = new AddFormContacts(contactDataTable, _crudStudent, currentRowIndex, FlagAddOrUpdate.Update))
            {
                newAddFormContacts.ShowDialog();
            }
        }

        private void AddRowAdressButton_Click(object sender, EventArgs e)
        {
            _crudStudent = new CRUDStudent(student);
            using (var newAdressForm = new AdressForm(adressDataTable, _crudStudent, currentRowIndex, FlagAddOrUpdate.Addition))
            {
                newAdressForm.ShowDialog();
            }

            SetButtonsAdressEnabledOrDisabled();
        }

        private void UpdateRowAdressButton_Click(object sender, EventArgs e)
        {
            currentRowIndex = GetCurrentRowIndexAdressDataGridView();
            if (currentRowIndex == null) return;
            using (var newAdressForm = new AdressForm(adressDataTable, _crudStudent, currentRowIndex, FlagAddOrUpdate.Update))
            {
                newAdressForm.ShowDialog();
            }
        }

        private void DeleteRowContactButton_Click(object sender, EventArgs e)
        {
            if (ContactsDataAdvancedDataGridView.CurrentRow != null)
            {
                currentRowIndex = GetCurrentRowIndexContactDataGridView();
                var typeRecord = ContactsDataAdvancedDataGridView.Rows[currentRowIndex].Cells["Тип контакта"].Value;
                var record = ContactsDataAdvancedDataGridView.Rows[currentRowIndex].Cells["Контакт"].Value;

                if (ShowMessageDeleteFromContacts(typeRecord + " - " + record))
                {
                    DeleteInstanceRowTable(currentRowIndex);
                    RefreshDataTableContacts(student, contactDataTable);
                }
            }

            SetButtonsContactEnabledOrDisabled();
        }

        private bool ShowMessageDeleteFromContacts(string contact)
        {
            var message = $"Вы действительно хотите удалить '{contact}'";
            const string caption = "Подтверждение удаления записи";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

            return result == DialogResult.OK;
        }

        private void DeleteInstanceRowTable(int indexCurrentRow)
        {
            Contact thisDeleteContact = _crudStudent.GetContact(indexCurrentRow);
            _crudStudent.DeleteCurrentContact(thisDeleteContact);
        }

        private void RefreshDataTableContacts(Student student, DataTable dataContacts)
        {
            dataContacts.Rows.Clear();
            foreach (var element in student.contactsList)
            {
                dataContacts.Rows.Add(DictionaryForRefreshDataTables.GetContactTypeEnumToString(element.contactType), 
                    element.contactValue);
            }
        }

        private void DeleteRowAdressButton_Click(object sender, EventArgs e)
        {
            if (AdressAdvancedDataGridView.CurrentRow != null)
            {
                if (ShowMessageDeleteFromAdress())
                {
                    DeleteInstanceRowTableAdress(currentRowIndex);
                    RefreshDataTableAdress(student, adressDataTable);
                }
            }

            SetButtonsAdressEnabledOrDisabled();
        }

        private void RefreshDataTableAdress(Student student, DataTable dataTableAdress)
        {
            dataTableAdress.Rows.Clear();

            foreach (var element in student.addressList)
            {
                dataTableAdress.Rows.Add(DictionaryForRefreshDataTables.GetAdressTypeEnumToString(element.adressType), 
                    element.city, element.postindex, element.street);
            }
        }

        private bool ShowMessageDeleteFromAdress()
        {
            var message = "Вы действительно хотите удалить данный адрес ?";
            const string caption = "Подтверждение удаления записи";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

            return result == DialogResult.OK;
        }

        private void DeleteInstanceRowTableAdress(int indexCurrentRow)
        {
            Adress thisDeleteAdress = _crudStudent.GetAdress(indexCurrentRow);
            _crudStudent.DeleteCurrentAdress(thisDeleteAdress);
        }

        private void AddBindingDataSourceDataTableContact()
        {
            contactDataView = new DataView(contactDataTable);
            ContactbindingSource.DataSource = contactDataView;
            ContactsDataAdvancedDataGridView.DataSource = ContactbindingSource;
        }

        private void AddBindingSourceDataTableAdress()
        {
            adressDataView = new DataView(adressDataTable);
            AdressBindingSource.DataSource = adressDataView;
            AdressAdvancedDataGridView.DataSource = AdressBindingSource;
        }

        private void CreateFileSerializationFile()
        {
            student.firstName = _firstNameProperty;
            student.patronimycName = _patronymicNameProperty;
            student.lastName = _lastNameProperty;
            student.curriculumList.faculty = _facultyProperty;
            student.curriculumList.speciality = _specialityPropery;
            student.curriculumList.course = _courseProperty;
            student.curriculumList.group = _groupProperty;
            
            string fileNamelocal = student.GetHashCode().ToString();

            if (flag == FlagAddOrUpdate.Update)
            {
                _crudStudent.CreateNewStudentCard(fileName, student);
                mainForm.OpenFileFromDirectory();
            }
            else
            {
                _crudStudent.CreateNewStudentCard(fileNamelocal, student);
            }
        }

        private DataTable CreateDataTableContacts()
        {
            var contactDataTable = new DataTable("Contacts");
            contactDataTable.Columns.Add("Тип контакта", typeof(string));
            contactDataTable.Columns.Add("Контакт", typeof(string));

            return contactDataTable;
        }

        private DataTable CreateDataTableAdress()
        {
            var adressDataTable = new DataTable("Adress");
            adressDataTable.Columns.Add("Тип адреса", typeof(string));
            adressDataTable.Columns.Add("Город", typeof(string));
            adressDataTable.Columns.Add("Почтовый индекс", typeof(string));
            adressDataTable.Columns.Add("Улица", typeof(string));

            return adressDataTable;
        }

        private void ContactsDataAdvancedDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            var contactsRowCount = ContactsDataAdvancedDataGridView.RowCount;
            if (e.KeyCode == Keys.Enter && contactsRowCount > 0)
            {
                UpdateRowContactButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Insert)
            {
                AddRowContactButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Delete && contactsRowCount > 0)
            {
                DeleteRowContactButton_Click(sender, e);
            }
        }

        private void AdressAdvancedDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            var adressRowCount = AdressAdvancedDataGridView.RowCount;

            if (e.KeyCode == Keys.Enter && adressRowCount > 0)
            {
                UpdateRowAdressButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Insert)
            {
                AddRowAdressButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Delete && adressRowCount > 0)
            {
                DeleteRowAdressButton_Click(sender, e);
            }
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_lastNameProperty, sender);

            VlidatedFieldsFromStudent();
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_firstNameProperty, sender);

            VlidatedFieldsFromStudent();
        }

        private void PatronymicNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_patronymicNameProperty, sender);

            VlidatedFieldsFromStudent();
        }

        private void FacultyTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_facultyProperty, sender);

            VlidatedFieldsFromStudent();
        }

        private void SpecialityTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_specialityPropery, sender);

            VlidatedFieldsFromStudent();
        }

        private void GroupTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_groupProperty, sender);

            VlidatedFieldsFromStudent();
        }

        private void PatronymicNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersTextBox(e, PatronymicNameTextBox, ValidatingToolTip);
        }

        private void FirstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersTextBox(e, FirstNameTextBox, ValidatingToolTip);
        }

        private void LastNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersTextBox(e, LastNameTextBox, ValidatingToolTip);
        }

        private void FacultyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersTextBox(e, FacultyTextBox, ValidatingToolTip);
        }

        private void SpecialityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersTextBox(e, SpecialityTextBox, ValidatingToolTip);
        }

        private void GroupTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorFunctions.SetOptionsForLettersGroupTextBox(e);
        }

        private void CourseComboBox_TextChanged(object sender, EventArgs e)
        {
            VlidatedFieldsFromStudent();
        }

        private void LastNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void FirstNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void PatronymicNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void FacultyTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void SpecialityTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void VlidatedFieldsFromStudent()
        {
            if (_courseProperty != "" &&
                _facultyProperty != "" &&
                _firstNameProperty != "" &&
                _groupProperty != "" &&
                _lastNameProperty != "" &&
                _patronymicNameProperty != "" &&
                _specialityPropery != "")
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
            }
        }

        private void InitialiZeColorFields()
        {
            FirstNameTextBox.BackColor = Color.DarkGray;
            LastNameTextBox.BackColor = Color.DarkGray;
            GroupTextBox.BackColor = Color.DarkGray;
            PatronymicNameTextBox.BackColor = Color.DarkGray;
            SpecialityTextBox.BackColor = Color.DarkGray;
            FacultyTextBox.BackColor = Color.DarkGray;
        }

        private void SetOptionsForUpdateOrAdditingForm(FlagAddOrUpdate flag)
        {
            Text = flag == FlagAddOrUpdate.Addition ? Resources.AddMessageStudent : Resources.UpdateMessageStudent;
        }

        private void SetButtonsContactEnabledOrDisabled()
        {
            if (ContactsDataAdvancedDataGridView.RowCount > 0)
            {
                UpdateRowContactButton.Enabled = true;
                DeleteRowContactButton.Enabled = true;
            }
            else
            {
                UpdateRowContactButton.Enabled = false;
                DeleteRowContactButton.Enabled = false;
            }
        }

        private void SetButtonsAdressEnabledOrDisabled()
        {
            if (AdressAdvancedDataGridView.RowCount > 0)
            {
                UpdateRowAdressButton.Enabled = true;
                DeleteRowAdressButton.Enabled = true;
            }
            else
            {
                UpdateRowAdressButton.Enabled = false;
                DeleteRowAdressButton.Enabled = false;
            }
        }

        private void ContactsDataAdvancedDataGridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateRowContactButton_Click(sender, e);
        }

        private void AdressAdvancedDataGridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateRowAdressButton_Click(sender,e);
        }
    }
}