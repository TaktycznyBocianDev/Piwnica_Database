using System;
using System.Windows.Forms;
using System.Configuration;

namespace Piwnica
{
    public partial class Form1 : Form
    {

        ViewModel viewModel;

        public Form1()
        {
            InitializeComponent();
            viewModel = new ViewModel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewModel.GetAllFromListToListBox(DataReader.LoadConteners(), Contener_LBx);
        }

        private void Contener_LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shelfs_LBx.Items.Clear();

            int selectedIndex = Contener_LBx.SelectedIndex;

            viewModel.GetAllFromListToListBox(DataReader.LoadShelfs(selectedIndex), Shelfs_LBx);
        }


        private void ExtBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oApkBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mój pierwszy projekt w Windows Forms + SQLite + C# <3", "O Aplikacji", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}

