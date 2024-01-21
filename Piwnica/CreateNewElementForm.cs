using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piwnica
{
    public partial class CreateNewElementForm : Form
    {

        DataCreator creator;
        DataModifier modifier;

        ContenerModel? contenerModel;
        ShelfModel? shelfModel;
        ItemModel? itemModel;

        bool willAdd = true;

        public CreateNewElementForm(ContenerModel contenerModel, bool willAdd)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            modifier = new DataModifier(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.contenerModel = contenerModel;

            if (willAdd)
            {
                AddBtn.Enabled = true;
                AddBtn.Visible = true;
                ModBtn.Enabled = false;
                ModBtn.Visible = false;
            }
            else
            {
                AddBtn.Enabled = false;
                AddBtn.Visible = false;
                ModBtn.Enabled = true;
                ModBtn.Visible = true;
            }

        }

        public CreateNewElementForm(ShelfModel shelfModel, bool willAdd)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            modifier = new DataModifier(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.shelfModel = shelfModel;

            if (willAdd)
            {
                AddBtn.Enabled = true;
                AddBtn.Visible = true;
                ModBtn.Enabled = false;
                ModBtn.Visible = false;
            }
            else
            {
                AddBtn.Enabled = false;
                AddBtn.Visible = false;
                ModBtn.Enabled = true;
                ModBtn.Visible = true;
            }
        }
        public CreateNewElementForm(ItemModel itemModel, bool willAdd)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            modifier = new DataModifier(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.itemModel = itemModel;

            if (willAdd)
            {
                AddBtn.Enabled = true;
                AddBtn.Visible = true;
                ModBtn.Enabled = false;
                ModBtn.Visible = false;
            }
            else
            {
                AddBtn.Enabled = false;
                AddBtn.Visible = false;
                ModBtn.Enabled = true;
                ModBtn.Visible = true;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                if (contenerModel != null)
                {
                    contenerModel.name = textBox1.Text;
                    creator.Create(contenerModel);
                }
                else if (shelfModel != null)
                {
                    shelfModel.name = textBox1.Text;
                    creator.Create(shelfModel);
                }
                else if (itemModel != null)
                {
                    itemModel.name = textBox1.Text;
                    creator.Create(itemModel);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Koniecznie nazwij nowy obiekt, inaczej to głupio tak :(",
                    "Brak nazwy dla nowego obiektu!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                if (contenerModel != null)
                {
                    modifier.Modify(contenerModel, textBox1.Text);
                }
                else if (shelfModel != null)
                {
                    modifier.Modify(shelfModel, textBox1.Text);
                }
                else if (itemModel != null)
                {
                    modifier.Modify(itemModel, textBox1.Text);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Koniecznie nazwij nowy obiekt, inaczej to głupio tak :(",
                    "Brak nazwy dla nowego obiektu!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
