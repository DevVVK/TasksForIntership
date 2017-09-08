using System.ComponentModel;
using System.Windows.Forms;
using CheckArcanoidLibrary.Models;
using CheckArcanoidLibrary.Properties;
using CheckArcanoidLibrary.Serialization;

namespace CheckArcanoidLibrary.Forms
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
            InitializeStatistic();
        }

        private void InitializeStatistic()
        {
            var serializer = new JsonSerializer<UserListModel>(Resources.FilePathUsers);

            if (!serializer.ExistsFile()) return;

            var deserializationDataList = serializer.Deserialize();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = deserializationDataList.Users;
            dgvStatisticGame.DataSource = bindingSource;
            dgvStatisticGame.Columns[0].HeaderText = "Имя";
            dgvStatisticGame.Columns[1].HeaderText = "Время (в секундах)";
            bindingSource.Sort = "[" + dgvStatisticGame.Columns[1].Name + "] ASC";
        }
    }
}
