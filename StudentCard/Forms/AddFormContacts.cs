using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using StudentCard.Properties;
using StudentCard.Sourсe;

namespace StudentCard.Forms
{
    public partial class AddFormContacts : Form
    {

        /// <summary>
        /// Переменные
        /// </summary>

        #region Variables

        private CRUDStudent _crudStudent;

        private DataTable _dataTableContact;

        private int _currentRowContactIndex;

        private FlagAddOrUpdate _flag;

        private string _contactType => TypeContactComboBox.Text;

        private string _stringContact => stringMaskedTextBox.Text;

        #endregion

        /// <summary>
        /// Функции формы
        /// </summary>

        #region FormFunctions
        public AddFormContacts()
        {
            InitializeComponent();
            AddButton.Enabled = false;
        }

        public AddFormContacts(DataTable dataTableContact, CRUDStudent crudStudent, int currentRowContactIndex,
            FlagAddOrUpdate flag) : this()
        {
            SetDataSourceTypeContactComboBox();

            _currentRowContactIndex = currentRowContactIndex;
            _dataTableContact = dataTableContact;
            _crudStudent = crudStudent;
            _flag = flag;

            SetAdditingOrUpdateForm(flag);
            SetOptionColorForStringMaskedTextBox();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_flag == FlagAddOrUpdate.Addition)
                {
                    CreateAndAddRowContact();
                }
                else
                {
                    UpdateFromDataTableContact();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.ErrorString, MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        /// <summary>
        /// Вспомогательные функции для работы с формой
        /// </summary>

        #region SuportingFunctions
        private void CreateAndAddRowContact()
        {
            var contactType = DictionaryForRefreshDataTables.GetContactTypeByValueContactTypeCombobox(_contactType);
            var newContact = new Contact {contactType = contactType, contactValue = _stringContact};

            _crudStudent.CreateNewContact(newContact);

            AddRowsDataTableContact(_crudStudent.GetContactList(), _dataTableContact);
        }

        private void AddRowsDataTableContact(List<Contact> contact, DataTable dataTable)
        {
            dataTable.Rows.Clear();

            foreach (var element in contact)
            {
                dataTable.Rows.Add(DictionaryForRefreshDataTables.GetContactTypeEnumToString(element.contactType),
                    element.contactValue);
            }
        }

        private void SetDataSourceTypeContactComboBox()
        {
            var strForContactTypeCombobox = new[]
            {
                "Номер домашнего телефона",
                "Номер мобильного телефона",
                "Адрес электронной почты"
            };

            TypeContactComboBox.DataSource = strForContactTypeCombobox;
        }

        private void UpdateSettingForm()
        {
            Text = Resources.UpdateMessageAddFormContacts;
        }

        private void AdditingSettingForm()
        {
            Text = Resources.AdditingMessageAddFormContacts;
        }

        private void SetAdditingOrUpdateForm(FlagAddOrUpdate flag)
        {
            if (flag == FlagAddOrUpdate.Addition)
            {
                AdditingSettingForm();
            }
            else
            {
                UpdateSettingForm();
                SetFieldsUpdateFormContact();
            }
        }

        private void SetFieldsUpdateFormContact()
        {
            var gettingContact = _crudStudent.GetContact(_currentRowContactIndex);

            TypeContactComboBox.Text =
                DictionaryForRefreshDataTables.GetContactTypeEnumToString(gettingContact.contactType);
            stringMaskedTextBox.Text = gettingContact.contactValue;
        }

        private void UpdateFromDataTableContact()
        {
            var contactType =
                DictionaryForRefreshDataTables.GetContactTypeByValueContactTypeCombobox(TypeContactComboBox.Text);
            var contact = stringMaskedTextBox.Text;

            var newContact = new Contact() {contactType = contactType, contactValue = contact};
            var thisDeleteContact = _crudStudent.GetContact(_currentRowContactIndex);

            _crudStudent.DeleteCurrentContact(thisDeleteContact);
            _crudStudent.UpdateCurrentContact(thisDeleteContact, newContact, _currentRowContactIndex);

            AddRowsDataTableContact(_crudStudent.GetContactList(), _dataTableContact);
        }

        #endregion

        private string GetOnKeyMaskForStringContact(string key)
        {
            var maskString = new Dictionary<string, string>()
            {
                {"Номер домашнего телефона", "000-000"},
                {"Номер мобильного телефона", "+7(000)-000-00-00"},
                {"Адрес электронной почты", ""}
            };

            string mask;

            maskString.TryGetValue(key, out mask);

            return mask;
        }

        private void TypeContactComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            stringMaskedTextBox.Mask = GetOnKeyMaskForStringContact(TypeContactComboBox.Text);
            stringMaskedTextBox.Text = "";
        }

        private void VlidatedFieldsFormAdress()
        {
            if (stringMaskedTextBox.Text != "" &&
                stringMaskedTextBox.MaskCompleted)
            {
                AddButton.Enabled = true;
            }
            else
            {
                AddButton.Enabled = false;
            }
        }

        private void SetOptionColorForStringMaskedTextBox()
        {
            stringMaskedTextBox.BackColor = Color.DarkGray;
        }

        private void stringMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidatorFunctions.UpdateColorStringMaskedTextBox(stringMaskedTextBox.Text, stringMaskedTextBox);

            VlidatedFieldsFormAdress();
        }
    }
}
