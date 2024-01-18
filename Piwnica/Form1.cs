using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;

namespace Piwnica
{

    public interface IListView<IData>
    {
        public List<string> CreateListOfStrings(List<IData> list);
        //IListView<ItemModel>, IListView<ShelfModel>, IListView<ContenerModel>
    }

    public partial class Form1 : Form
    {

        ViewModel viewModel;
        DataReader reader;

        public Form1()
        {
            InitializeComponent();
            reader = new DataReader(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            viewModel = new ViewModel(reader);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Contener_LBx.DisplayMember = "AsString";
            foreach (ContenerModel contener in viewModel.GetAllConteenrs())
            {
                Contener_LBx.Items.Add(contener);
            }

           
        }

        private void Contener_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetListBoxReady(Shelfs_LBx);

            if (Contener_LBx.SelectedItem != null)
            {
                ContenerModel model = (ContenerModel)Contener_LBx.SelectedItem;
                int contenerId = model.id;

                foreach(ShelfModel shelf in viewModel.GetAllShelfByContener(contenerId))
                {
                    Shelfs_LBx.Items.Add(shelf);
                }
            }
        }

        private void Shelfs_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetListBoxReady(Stuff_LBx);

            if (Shelfs_LBx.SelectedItem != null)
            {
                ShelfModel model = (ShelfModel)Shelfs_LBx.SelectedItem;
                int shelfId = model.id;

                foreach (ItemModel item in viewModel.GetAllItemByShelf(shelfId))
                {
                    Stuff_LBx.Items.Add(item);
                }
            }
        }

        private void ExtBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oApkBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mój pierwszy projekt w Windows Forms + SQLite + C# <3", "O Aplikacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void GetListBoxReady(ListBox listbox)
        {
            listbox.Items.Clear();
            listbox.DisplayMember = "AsString";
        }

    }
}

