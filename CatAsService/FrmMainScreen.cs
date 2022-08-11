using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatAsService
{
    public partial class FrmMainScreen : Form
    {
        public FrmMainScreen()
        {
            InitializeComponent();
        }

        private void searchBreedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSearchBreeds frmSearch = new FrmSearchBreeds();
            frmSearch.ShowDialog();
        }

        private void myFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFavoritesReport frmFavorites = new FrmFavoritesReport();
            frmFavorites.ShowDialog();
        }
    }
}
