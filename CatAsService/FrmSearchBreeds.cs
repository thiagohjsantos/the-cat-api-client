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
    public partial class FrmSearchBreeds : Form
    {
        private APIService.ClsCatAsService ApiCatAsService;

        public FrmSearchBreeds()
        {
            InitializeComponent();
            ApiCatAsService = new APIService.ClsCatAsService();
        }

        private void FrmSearchBreeds_Load(object sender, EventArgs e)
        {
            cbListBreeds.SelectedIndex = 0;
            LoadBreeds(ApiCatAsService.GetBreeds());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbListBreeds.SelectedIndex > 0)
            {
                string idBreed = ((ComboBoxItem)cbListBreeds.SelectedItem).HiddenValue;
                string idImage = ((ComboBoxItem)cbListBreeds.SelectedItem).ImageId;
                LoadScreenResult(ApiCatAsService.GetCharacteristicsByID(idBreed));
                LoadImage(ApiCatAsService.GetImages(idImage));
            }
            else
                MessageBox.Show("Select a breed");
        }

        private void LoadBreeds(List<CatModel> Result)
        {
            List<CatModel> cats = new List<CatModel>();
            cats.AddRange(Result);

            foreach (var item in cats)
            {
                cbListBreeds.Items.Add(new ComboBoxItem(item.Name, item.Id, item.ReferenceImageId));
            }
            
        }

        private void LoadScreenResult(CatModel Result)
        {
            txtOrigin.Text = Result.Origin;
            txtDescription.Text = Result.Description;
            txtTemperament.Text = Result.Temperament;
        }

        private void LoadImage(CatModel Result)
        {
            if (Result == null)
            {
                pictureBox1.Image = Properties.Resources._default;
            }
            else
                pictureBox1.ImageLocation = Result.Url;
        }

        private void CleanResults()
        {
            pictureBox1.Image = Properties.Resources._default;
            txtDescription.Text = "";
            txtOrigin.Text = "";
            txtTemperament.Text = "";
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            if (cbListBreeds.SelectedIndex > 0)
            {
                string idImage = ((ComboBoxItem)cbListBreeds.SelectedItem).ImageId;
                bool success = ApiCatAsService.AddFavorite(idImage);

                if (success == true)
                {
                    MessageBox.Show($"{cbListBreeds.SelectedItem} breed has been successfully favorited!");
                }
            }
            else
            {
                MessageBox.Show("Select a breed");
            }
        }

        private void cbListBreeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListBreeds.SelectedIndex >= 0)
            {
                CleanResults();
            }
        }     
    }
}
