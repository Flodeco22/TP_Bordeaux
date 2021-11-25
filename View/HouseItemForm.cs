using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDB.View
{
    public partial class HouseItemForm : UserControl
    {
        public HouseItemForm()
        {
            InitializeComponent();
            //showData(title, imageUrl, price);
        }

        internal void showData(string title, string imageUrl, string price, string dispo)
        {
            titleLabel.Text = title;
            pictureBox.ImageLocation = imageUrl;
            priceLabel.Text = price + "€";
            dispoLabel.Text = dispo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
