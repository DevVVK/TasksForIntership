using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using StudentCard.Properties;
using StudentCard.Sourсe;

namespace StudentCard.Forms
{
    public partial class AdressForm : Form
    {
        private DataTable _dataTableAdress;

        private CRUDStudent _crudStudent;

        private int _currentRowAdressIndex;

        private FlagAddOrUpdate _flag;

        private string _typeAdress => TypeAdressComboBox.Text;

        private string _cityProperty => CityTextBox.Text;

        private string _porsIndexProperty => PostIndexMaskedTextBox.Text;

        private string _streetProperty => StreetTextBox.Text;

        public AdressForm()
        {
            InitializeComponent();
            InitializeColorFields();
            OkButton.Enabled = false;
        }
        
        public AdressForm(DataTable dataTableAdress, CRUDStudent crudStudent, int currentRowAdressIndex, FlagAddOrUpdate flag):this()
        {
            SetDataSourceTypeAdressComboBox();

            _dataTableAdress = dataTableAdress;
            _crudStudent = crudStudent;
            _currentRowAdressIndex = currentRowAdressIndex;
            _flag = flag;

            OkButton.Enabled = false;

            SetSetAdditingOrUpdateForm(flag);
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_flag == FlagAddOrUpdate.Addition)
                {
                    CreateAndAddRowAdress();
                }
                else
                {
                    UpdateFromDataTableAdress();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.ErrorString, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void AdditingSettingForm()
        {
            Text = Resources.AdditingMessageAdressForm;
        }

        private void UpdationgSettingForm()
        {
            Text = Resources.UpdatingMessageAdressForm;
        }

        private void SetSetAdditingOrUpdateForm(FlagAddOrUpdate flag)
        {
            if (flag == FlagAddOrUpdate.Addition)
            {
                AdditingSettingForm();
            }
            else
            {
                UpdationgSettingForm();
                SetFieldsUpdateFormAdress();
            }
        }

        private void CreateAndAddRowAdress()
        {
            AdressType adressType = DictionaryForRefreshDataTables.GetAdressTypeByValueAdressTypeComboBox(_typeAdress);
            Adress newAdress = new Adress()
            {
                adressType = adressType,
                city = _cityProperty,
                postindex = _porsIndexProperty,
                street = _streetProperty
            };
            
            _crudStudent.CreateNewAdress(newAdress);

            AddRowsDataTableAdress(_crudStudent.GetAdressList(), _dataTableAdress);
        }

       
        private void SetDataSourceTypeAdressComboBox()
        {
            var strForAdressTypeCombobox = new[]
            {
                "Адрес по прописке",
                "Адрес фактический",
            };

            TypeAdressComboBox.DataSource = strForAdressTypeCombobox;
        }

        private void AddRowsDataTableAdress(List<Adress> adressList, DataTable dataTable)
        {
            dataTable.Rows.Clear();

            foreach (var element in adressList)
            {
                dataTable.Rows.Add(DictionaryForRefreshDataTables.GetAdressTypeEnumToString(element.adressType), 
                    element.city, element.postindex, element.street);
            }
        }

        private void SetFieldsUpdateFormAdress()
        {
            var gettingAdress = _crudStudent.GetAdress(_currentRowAdressIndex);

            TypeAdressComboBox.Text = DictionaryForRefreshDataTables.GetAdressTypeEnumToString(gettingAdress.adressType);
            StreetTextBox.Text = gettingAdress.street;
            CityTextBox.Text = gettingAdress.city;
            PostIndexMaskedTextBox.Text = gettingAdress.postindex;
        }

        private void UpdateFromDataTableAdress()
        {
            var adressType = DictionaryForRefreshDataTables.GetAdressTypeByValueAdressTypeComboBox(TypeAdressComboBox.Text);
            var city = CityTextBox.Text;
            var street = StreetTextBox.Text;
            var postIndex = PostIndexMaskedTextBox.Text;

            var newAdress = new Adress()
            {
                adressType = adressType,
                city = city,
                postindex = postIndex,
                street = street
            };
            var thisDeleteAdress = _crudStudent.GetAdress(_currentRowAdressIndex);

            _crudStudent.UpdateCurrentAdress(thisDeleteAdress, newAdress, _currentRowAdressIndex);

            AddRowsDataTableAdress(_crudStudent.GetAdressList(), _dataTableAdress);
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            VlidatedFieldsFormAdress();

            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_cityProperty, sender);
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            VlidatedFieldsFormAdress();

            ValidatorFunctions.UpdateColorOnUpdatingStringTextBox(_streetProperty, sender);
        }

        private void TypeAdressComboBox_TextChanged(object sender, EventArgs e)
        {
            VlidatedFieldsFormAdress();
        }

        private void PostIndexMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            PostIndexMaskedTextBox.BackColor = _porsIndexProperty != "" && 
            PostIndexMaskedTextBox.MaskCompleted ? Color.White : Color.DarkGray;

            VlidatedFieldsFormAdress();
        }

        private void VlidatedFieldsFormAdress()
        {
            if (_cityProperty != "" &&
                _porsIndexProperty != "" &&
                _streetProperty != "" &&
                _typeAdress != "" &&
                PostIndexMaskedTextBox.MaskCompleted)
            {
                OkButton.Enabled = true;
            }
            else
            {
                OkButton.Enabled = false;
            }
        }

        private void InitializeColorFields()
        {
            CityTextBox.BackColor = Color.DarkGray;
            StreetTextBox.BackColor = Color.DarkGray;
            PostIndexMaskedTextBox.BackColor = Color.DarkGray;
        }

        private void CityTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }

        private void StreetTextBox_Leave(object sender, EventArgs e)
        {
            TextBoxFunctions.UpdateInputString(sender);
        }
    }
}
