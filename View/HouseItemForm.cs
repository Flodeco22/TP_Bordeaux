using MongoDB.Bson;
using MongoDB.Driver;
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
        private String id;
        private MongoClient dbClient;
        private MainForm mainF;
        
        public HouseItemForm()
        {
            InitializeComponent();
            //showData(title, imageUrl, price);
        }

        public HouseItemForm(String id, MongoClient dbClient, MainForm mainF)
        {
            InitializeComponent();
            this.id = id;
            this.dbClient = dbClient;
            this.mainF = mainF;

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

        private void supprimer_Click(object sender, EventArgs e)
        {
            var database = dbClient.GetDatabase("tp");
            var collection = database.GetCollection<BsonDocument>("bordeaux");

            var filter = Builders<BsonDocument>.Filter.Eq("id", id);

            collection.DeleteOne(filter);

            mainF.getDataFromDB();
            mainF.refreshPageLabel();
            mainF.refreshItemsLayout();
            

        }
    }
}
