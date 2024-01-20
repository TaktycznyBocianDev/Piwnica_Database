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

        ContenerModel? contenerModel;
        ShelfModel? shelfModel;
        ItemModel? itemModel;

        public CreateNewElementForm(ContenerModel contenerModel)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.contenerModel = contenerModel;

        }

        public CreateNewElementForm(ShelfModel shelfModel)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.shelfModel = shelfModel;

        }
        public CreateNewElementForm(ItemModel itemModel)
        {
            InitializeComponent();
            creator = new DataCreator(new SQLiteConnection(ConnectionManager.LoadConnectionString()));
            this.itemModel = itemModel;

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
                else if(itemModel !=null)
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
    }
}
