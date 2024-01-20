using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;
using System.ComponentModel.Design.Serialization;

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
        DataCreator creator;




        public Form1()
        {
            InitializeComponent();
            reader = new DataReader(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            viewModel = new ViewModel(reader, creator);

            DataCreator.OnAdded += ReloadConteners;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Contener_LBx.DisplayMember = "AsString";
            foreach (ContenerModel contener in viewModel.GetAllConteenrs())
            {
                Contener_LBx.Items.Add(contener);
            }
        }

        private void ReloadConteners()
        {
            int tmp = Contener_LBx.SelectedIndex;

            GetListBoxReady(Contener_LBx);

            foreach (ContenerModel contener in viewModel.GetAllConteenrs())
            {
                Contener_LBx.Items.Add(contener);
            }

            if (Contener_LBx.SelectedItem != null)
            {
                GetListBoxReady(Shelfs_LBx);
                ContenerModel model = (ContenerModel)Contener_LBx.SelectedItem;
                int contenerId = model.id;

                foreach (ShelfModel shelf in viewModel.GetAllShelfByContener(contenerId))
                {
                    Shelfs_LBx.Items.Add(shelf);
                }
            }

            if (Shelfs_LBx.SelectedItem != null)
            {
                GetListBoxReady(Stuff_LBx);

                    ShelfModel model = (ShelfModel)Shelfs_LBx.SelectedItem;
                    int shelfId = model.id;

                    foreach (ItemModel item in viewModel.GetAllItemByShelf(shelfId))
                    {
                        Stuff_LBx.Items.Add(item);
                    }
            }

            Contener_LBx.SelectedIndex = tmp;
        }

        private void Contener_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetListBoxReady(Shelfs_LBx);

            if (Contener_LBx.SelectedItem != null)
            {
                ContenerModel model = (ContenerModel)Contener_LBx.SelectedItem;
                int contenerId = model.id;

                foreach (ShelfModel shelf in viewModel.GetAllShelfByContener(contenerId))
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

        private void ContenerAdd_Btn_Click(object sender, EventArgs e)
        {

            if ((ContenerModel?)Contener_LBx.SelectedItem != null)
            {
                CreateNewElementForm elementForm = new CreateNewElementForm((ContenerModel)Contener_LBx.SelectedItem);
                elementForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wybierz dowolny kontener!", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void ShelfAdd_Btn_Click(object sender, EventArgs e)
        {

            if (Contener_LBx.SelectedItem != null)
            {
                ContenerModel contener = (ContenerModel)Contener_LBx.SelectedItem;
                ShelfModel shelf = new ShelfModel(contener.id, contener.name);

                CreateNewElementForm elementForm = new CreateNewElementForm(shelf);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz nadrzêdny kontener", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void StuffAdd_Btn_Click(object sender, EventArgs e)
        {
            if (Shelfs_LBx.SelectedItem != null)
            {
                ShelfModel shelf = (ShelfModel)Shelfs_LBx.SelectedItem;
                ItemModel item = new ItemModel(shelf.idContener, shelf.id, shelf.name);

                CreateNewElementForm elementForm = new CreateNewElementForm(item);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz nadrzêdny kontener", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

