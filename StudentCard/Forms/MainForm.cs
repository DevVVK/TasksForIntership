using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using StudentCard.Forms;
using StudentCard.Properties;
using StudentCard.Sourсe;

namespace StudentCard
{
    public partial class MainForm : Form
    {
        private Student _studentCard;

        private CRUDStudent _crudStudent;

        private DataTable _dataStudent { get; set; }

        private DataView _dataView { get; set; }

        public string currentFileName { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            _crudStudent = new CRUDStudent();
            OpenFileFromDirectory();
            SetAutoSortModeIsTrue();
        }

        private void SetAutoSortModeIsTrue()
        {
            foreach (DataGridViewColumn column in DataFromXmlFilesAdvanxedDataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private string GetCurrentStudentName()
        {
            var currentRowIndex = DataFromXmlFilesAdvanxedDataGrid.CurrentRow.Index;
            var name = DataFromXmlFilesAdvanxedDataGrid.Rows[currentRowIndex].Cells["Имя"].Value.ToString();
            var patronimyc = DataFromXmlFilesAdvanxedDataGrid.Rows[currentRowIndex].Cells["Отчество"].Value.ToString();
            var lastname = DataFromXmlFilesAdvanxedDataGrid.Rows[currentRowIndex].Cells["Фамилия"].Value.ToString();
            
            return name + " " + patronimyc + " " + lastname;
        }

        private void DataFromXmlFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (DataFromXmlFilesAdvanxedDataGrid.CurrentRow != null)
            {
                var currentrowindex = DataFromXmlFilesAdvanxedDataGrid.CurrentRow.Index;
                var filepathcolumnindex = _dataStudent.Columns.IndexOf("Путь к файлу");
                if (DataFromXmlFilesAdvanxedDataGrid.Rows.Count != 0)
                {
                    currentFileName = DataFromXmlFilesAdvanxedDataGrid.Rows[currentrowindex].
                        Cells[filepathcolumnindex].Value.ToString();
                }

                DataFromXmlFilesAdvanxedDataGrid.Columns[filepathcolumnindex].Visible = false;
            }

            if (DataFromXmlFilesAdvanxedDataGrid.Rows.Count > 0)
            {
                EditButton.Enabled = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Student studnet = _crudStudent.ReadStudentCard(currentFileName);
            using (var newUpdate = new AddFormStudent(this, studnet, currentFileName, FlagAddOrUpdate.Update))
            {
                newUpdate.ShowDialog();
            }
        }

        private void DataFromXmlFilesAdvanxedDataGrid_FilterStringChanged(object sender, EventArgs e)
        {
            bindingsourcestudent.Filter = DataFromXmlFilesAdvanxedDataGrid.FilterString;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var filter = "([" + ColumnsComboBox.Text + "] LIKE " + "('%" + SearchTextBox.Text + "%'))";
            bindingsourcestudent.Filter = filter;
        }

        private void DataFromXmlFilesAdvanxedDataGrid_SortStringChanged(object sender, EventArgs e)
        {
            bindingsourcestudent.Sort = DataFromXmlFilesAdvanxedDataGrid.SortString;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddFormStudent newAddFormStudent = new AddFormStudent(this);
            newAddFormStudent.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataFromXmlFilesAdvanxedDataGrid.SelectedRows.Count > 1)
            {
                if (ShowMessageBoxForConfirmationDelete(null))
                {
                    DeleteSelectedRowsStudentCard(GetFileNamesSelectedRows());
                    OpenFileFromDirectory();
                    return;
                }
            }

            if (DataFromXmlFilesAdvanxedDataGrid.SelectedRows.Count < 2)
            {
                if (ShowMessageBoxForConfirmationDelete(GetCurrentStudentName()))
                {
                    _crudStudent.DeleteStudentCard(currentFileName);
                    OpenFileFromDirectory();
                }
            }

            if (!ChekAvailabilityFiles())
            {
                DeleteButton.Enabled = false;
                EditButton.Enabled = false;
            }
        }

        private string[] GetFileNamesSelectedRows()
        {
            var selectedRows = DataFromXmlFilesAdvanxedDataGrid.SelectedRows;

            var fileNames = new string[selectedRows.Count];

            for (var i = 0; i < selectedRows.Count; i++)
            {
                fileNames[i] = selectedRows[i].Cells["Путь к файлу"].Value.ToString();
            }

            return fileNames;
        }

        private void DeleteSelectedRowsStudentCard(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                _crudStudent.DeleteStudentCard(fileName);
            }
        }

        public void OpenFileFromDirectory()
        {
            var fileNameFromDyrectory = new List<string>();
            fileNameFromDyrectory.AddRange(Directory.GetFiles(Resources.FilePathDirectory).
                Select(Path.GetFileNameWithoutExtension));

            _dataStudent = CreateDataTable();

            foreach (var fileName in fileNameFromDyrectory)
            {
                _studentCard = _crudStudent.ReadStudentCard(fileName);
                CreateDataRow(fileName);
            }

            CreateConnectionBindeingSource();

            if (ChekAvailabilityFiles())
            {
                DeleteButton.Enabled = true;
            }
        }

        private void CreateConnectionBindeingSource()
        {
            _dataView = new DataView(_dataStudent);
            bindingsourcestudent.DataSource = _dataView;
            DataFromXmlFilesAdvanxedDataGrid.DataSource = bindingsourcestudent;
            ColumnsComboBox.DataSource = GetColumnsName(_dataStudent);
        }

        private List<string> GetColumnsName(DataTable dataTable)
        {
            return (from DataColumn column in dataTable.Columns select column.ColumnName).ToList();
        }

        private void CreateDataRow(string fileName)
        {
            _dataStudent.Rows.Add(_studentCard.lastName,
                _studentCard.firstName,
                _studentCard.patronimycName,
                _studentCard.curriculumList.faculty,
                _studentCard.curriculumList.speciality,
                _studentCard.curriculumList.course,
                _studentCard.curriculumList.group,
                fileName);
        }

        private DataTable CreateDataTable()
        {
            var datatable = new DataTable();

            datatable.Columns.Add("Фамилия", typeof(string));
            datatable.Columns.Add("Имя", typeof(string));
            datatable.Columns.Add("Отчество", typeof(string));
            datatable.Columns.Add("Факультет", typeof(string));
            datatable.Columns.Add("Специальность", typeof(string));
            datatable.Columns.Add("Курс", typeof(string));
            datatable.Columns.Add("Группа", typeof(string));
            datatable.Columns.Add("Путь к файлу", typeof(string));

            return datatable;
        }

        private bool ShowMessageBoxForConfirmationDelete(string nameStudent)
        {
            string  message = null, caption = null;
            if (nameStudent != null)
            {
                message = $"Вы действительно хотите удалить студента '{nameStudent}'";
                caption = "Подтверждение удаление записи";
            }
            if (nameStudent == null)
            {
                message = "Вы действительно хотите удалить выбранных студентов";
                caption = "Подтверждение удаление записи";
            }
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);

            return result == DialogResult.OK;
        }

        private bool ChekAvailabilityFiles()
        {
            return DataFromXmlFilesAdvanxedDataGrid.RowCount > 0;
        }

        private void DataFromXmlFilesAdvanxedDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditButton_Click(sender, e);
        }

        private void DataFromXmlFilesAdvanxedDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && DataFromXmlFilesAdvanxedDataGrid.RowCount > 0)
            {
                e.Handled = true;
                EditButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Delete && DataFromXmlFilesAdvanxedDataGrid.RowCount > 0)
            {
                DeleteButton_Click(sender, e);
            }

            if (e.KeyCode == Keys.Insert)
            {
                AddButton_Click(sender, e);
            }
        }

        private void DataFromXmlFilesAdvanxedDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String columnName = DataFromXmlFilesAdvanxedDataGrid.Columns[e.ColumnIndex].Name;
            bindingsourcestudent.Sort = "[" + columnName + "] ASC";
        }
    }
}