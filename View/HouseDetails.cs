using MongoDB.Model;
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
    public partial class HouseDetails : UserControl
    {
        public HouseDetails()
        {
            InitializeComponent();
        }

        internal void showData(HouseModel houseModel)
        {
            titleLabel.Text = houseModel.Name;
            descriptionRichTextBox.Text = houseModel.Description;
            priceLabel.Text = houseModel.Price.ToString() + "€";
            pictureBox1.ImageLocation = houseModel.PictureUrl;
            hostGroupBox.Text = houseModel.HostName;
            hostPictureBox.ImageLocation = houseModel.HostPictureUrl;
            hostLocationLabel.Text = houseModel.HostLocation;
        }

        private void exitViewButton_Click(object sender, EventArgs e)
        {
            
        }

        /*public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public String PictureUrl { get; set; }
        public String HostName { get; set; }
        public String HostPictureUrl { get; set; }
        public String HostLocation { get; set; }*/
    }
}
