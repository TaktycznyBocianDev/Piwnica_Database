using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;
using System.ComponentModel.Design.Serialization;
using System.Xml.Serialization;

namespace Piwnica
{

    public interface IListView<IData>
    {
        public List<string> CreateListOfStrings(List<IData> list);
        //IListView<ItemModel>, IListView<ShelfModel>, IListView<ContenerModel>
    }

    public partial class Form1 : Form
    {

        SQLiteConnection connection;

        ViewModel viewModel;
        DataReader reader;
        DataCreator creator;
        DataDestroyer destroyer;

        public Form1()
        {
            InitializeComponent();
            connection = new SQLiteConnection(ConnectionManager.LoadConnectionString());
            reader = new DataReader(connection);
            creator = new DataCreator(connection);
            destroyer = new DataDestroyer(connection);
            viewModel = new ViewModel(reader, creator, destroyer);

            DataCreator.OnAdded += ReloadConteners;
            DataDestroyer.OnDeleted += ReloadAfterDelete;
            DataModifier.OnModified += ReloadConteners;
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

        private void ReloadAfterDelete()
        {

            int tmp = Contener_LBx.SelectedIndex - 1;
            if (tmp < 0) { tmp = 1; }

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


            try
            {
                if (Contener_LBx.SelectedItems.Count != 0)
                {
                    Contener_LBx.SelectedIndex = tmp;
                }
                else
                {
                    Contener_LBx.SelectedItem = null;
                }
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Contener_LBx.SelectedItem = null;
                throw;
            }
            catch (Exception e)
            {

                Contener_LBx.SelectedItem = null;
                throw;

            }


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
                CreateNewElementForm elementForm = new CreateNewElementForm((ContenerModel)Contener_LBx.SelectedItem, true);
                elementForm.ShowDialog();
            }
            else
            {
                ContenerModel contener = new ContenerModel();
                CreateNewElementForm elementForm = new CreateNewElementForm(contener, true);
                elementForm.ShowDialog();
            }


        }

        private void ShelfAdd_Btn_Click(object sender, EventArgs e)
        {

            if (Contener_LBx.SelectedItem != null)
            {
                ContenerModel contener = (ContenerModel)Contener_LBx.SelectedItem;
                ShelfModel shelf = new ShelfModel(contener.id, contener.name);

                CreateNewElementForm elementForm = new CreateNewElementForm(shelf, true);
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
                ItemModel item = new ItemModel(shelf.ContenerId, shelf.id, shelf.name);

                CreateNewElementForm elementForm = new CreateNewElementForm(item, true);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz nadrzêdny kontener", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StuffRemove_Btn_Click(object sender, EventArgs e)
        {
            if ((ItemModel)Stuff_LBx.SelectedItem != null)
            {
                destroyer.Delete((ItemModel)Stuff_LBx.SelectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz przedmiot do usuniêcia", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShelfRemove_Btn_Click(object sender, EventArgs e)
        {
            if ((ShelfModel)Shelfs_LBx.SelectedItem != null)
            {
                destroyer.Delete((ShelfModel)Shelfs_LBx.SelectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz szafkê do usuniêcia", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ContenerRemove_Btn_Click(object sender, EventArgs e)
        {
            if ((ContenerModel)Contener_LBx.SelectedItem != null)
            {
                destroyer.Delete((ContenerModel)Contener_LBx.SelectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz szafkê do usuniêcia", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ContenerMod_Btn_Click(object sender, EventArgs e)
        {
            if (Contener_LBx.SelectedItem != null)
            {
                ContenerModel contener = (ContenerModel)Contener_LBx.SelectedItem;
                CreateNewElementForm elementForm = new CreateNewElementForm(contener, false);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz kontener do modyfikacji", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShelfsMod_Btn_Click(object sender, EventArgs e)
        {
            if (Shelfs_LBx.SelectedItem != null)
            {
                ShelfModel shelf = (ShelfModel)Shelfs_LBx.SelectedItem;
                CreateNewElementForm elementForm = new CreateNewElementForm(shelf, false);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz kontener do modyfikacji", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StuffMod_Btn_Click(object sender, EventArgs e)
        {
            if (Stuff_LBx.SelectedItem != null)
            {
                ItemModel item = (ItemModel)Stuff_LBx.SelectedItem;
                CreateNewElementForm elementForm = new CreateNewElementForm(item, false);
                elementForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wybierz kontener do modyfikacji", "B³¹d zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

