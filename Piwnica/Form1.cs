using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;

namespace Piwnica
{

    public interface IListView<T>
    {
        public List<string> CreateListOfStrings(List<T> list);

    }

    public partial class Form1 : Form, IListView<ItemModel>, IListView<ShelfModel>, IListView<ContenerModel>
    {

        ViewModel viewModel;
        DataReader reader;
        List<ContenerModel> contenerModels;
        List<ShelfModel> shelfModels;
        List<ItemModel> itemModels;

        public Form1()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            reader = new DataReader(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            contenerModels = new List<ContenerModel>();
            shelfModels = new List<ShelfModel>();
            itemModels = new List<ItemModel>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewModel.GetAllFromListToListBox(reader.LoadAllConteners(), Contener_LBx);
        }

        private void Contener_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shelfs_LBx.Items.Clear();

            int selectedIndex = Contener_LBx.SelectedIndex;

            viewModel.GetAllFromListToListBox(reader.LoadAllShelfsByContener(selectedIndex), Shelfs_LBx);
        }

        private void Shelfs_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stuff_LBx.Items.Clear();

            if (Shelfs_LBx.SelectedItem != null)
            {
                ShelfModel currentShelf = (ShelfModel)Shelfs_LBx.SelectedItem;
                int currentId = currentShelf.id;
                viewModel.GetAllFromListToListBox(reader.LoadItemsByShelf(currentId), Stuff_LBx);
            }
            else
            {
                MessageBox.Show("Database Error - Wybrany Shelf jest pusty. Uciekaj","", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public List<string> CreateListOfStrings(List<ItemModel> list)
        {
            List<string> result = new List<string>(); 
            foreach (var item in list)
            {
                result.Add(item.AsString);
            }
            return result;
        }

        public List<string> CreateListOfStrings(List<ShelfModel> list)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                result.Add(item.AsString);
            }
            return result;
        }

        public List<string> CreateListOfStrings(List<ContenerModel> list)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                result.Add(item.AsString);
            }
            return result;
        }
    }
}

