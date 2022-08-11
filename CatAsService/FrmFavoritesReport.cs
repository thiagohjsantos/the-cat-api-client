using CatAsService.APIService;
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
    public partial class FrmFavoritesReport : Form
    {
        private APIService.ClsCatAsService ApiCatAsService;

        public FrmFavoritesReport()
        {
            InitializeComponent();
            ApiCatAsService = new APIService.ClsCatAsService();
        }

        private void FrmFavoritesReport_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFavorites(ApiCatAsService.GetFavorites());
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }

        private void LoadFavorites(List<Tuple<CatModel, CatModel>> Result)
        {
            List<Tuple<CatModel, CatModel>> favorites = new List<Tuple<CatModel, CatModel>>();
            favorites.AddRange(Result);

            foreach (var cat in favorites)
            {
                listMyFavorites.Items.Add(new ComboBoxItem(cat.Item1.Name, cat.Item2.Id));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listMyFavorites.SelectedIndex >= 0)
            {
                string Id = ((ComboBoxItem)listMyFavorites.SelectedItem).HiddenValue;

                DialogResult result = MessageBox.Show("Delete item?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bool success = ApiCatAsService.DeleteFavorite(Id);

                    if (success == true)
                    {
                        MessageBox.Show($"The {listMyFavorites.SelectedItem} breed has been deleted!");
                        listMyFavorites.Items.RemoveAt(listMyFavorites.SelectedIndex);
                    }
                }
            }
            else
                MessageBox.Show("Select a breed");
        }
        
    }
}
