using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Model;
using MongoDB.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDB
{
    public partial class MainForm : Form
    {
        List<HouseModel> houseList = new List<HouseModel>();
        MongoClient dbClient = new MongoClient("mongodb+srv://admin:bamboula@bamboula.7akyx.mongodb.net/test");

        // Parametres
        const int nbItemByPage = 12;
        int currentPageIndex = 0;
        int maxPage = 1; // Nombre de pages possible selon le nombre de maisons dispo sur la DB

        public MainForm()
        {
            InitializeComponent();
            getDataFromDB(0);
            refreshItemsLayout();
            refreshPageLabel();
        }

        void getDataFromDB(int page) //Get all data (no filter)
        {
            houseList = new List<HouseModel>();
            var database = dbClient.GetDatabase("tp");
            var collection = database.GetCollection<BsonDocument>("bordeaux");
            var documents = collection.Find(new BsonDocument()).Skip(page * nbItemByPage).Limit(nbItemByPage).ToList();
            addItemsToHouseList(documents);
            int docCount = (int)collection.CountDocuments(new BsonDocument());

            int remainder;
            int quotient = Math.DivRem(docCount, nbItemByPage, out remainder);
            maxPage = remainder == 0 ? quotient : quotient + 1;
            Console.WriteLine("Max Page : " + maxPage);
        }

        void getDataFromDB(float minPrice, float maxPrice, string textToSearch) // TODO : Get filtered data
        { 

        }

        void addDataIntoDB() // TODO
        {
            var document = new BsonDocument {
                {
                    "student_id", 10000
                },
                {
                    "class_id", 480 }
                };

            //collection.InsertOne(document);
        }        

        void addItemsToHouseList(List<BsonDocument> documents) // Petite lecture des résultats reçus de la DB
        {
            foreach (var item in documents) 
            {
                houseList.Add(new HouseModel
                {
                    Name = item.GetValue("name").AsString,
                    Description = item.GetValue("description").AsString,
                    Price = double.Parse(item.GetValue("price").AsString.Trim('$').Replace('.', ',')),
                    PictureUrl = item.GetValue("picture_url").AsString,
                    HostName = item.GetValue("host_name").AsString,
                    HostPictureUrl = item.GetValue("host_picture_url").AsString,
                    HostLocation = item.GetValue("host_location").AsString
                });;
            }
        }

        void refreshItemsLayout() // Ajoute les maisons dans le "flowLayoutPanel"
        {
            flowLayoutPanel.Controls.Clear(); // On vide le layout histoire de pas avoir 150 000 maisons sur une page
            foreach (var item in houseList) // Dois-je l'expliquer ?
            {
                HouseItemForm houseItemForm = new HouseItemForm(); // Un nouveau petit Form qui va contenir les infos basiques d'une maison
                houseItemForm.showData(item.Name, item.PictureUrl, item.Price.ToString()); // On donne les infos à la Form pour qu'elle puisse les afficher
                flowLayoutPanel.Controls.Add(houseItemForm); // Et hop, on l'ajoute dans notre beau Panel plein de FLOWWW
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            float minPrice = 0;
            float maxPrice = 0;

            float.TryParse(minPriceTextBox.Text, out minPrice);
            float.TryParse(maxPriceTextBox.Text, out maxPrice);

            getDataFromDB(minPrice, maxPrice, descriptionTextBox.Text);
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if(currentPageIndex > 0)
            {
                getDataFromDB(--currentPageIndex);
                refreshPageLabel();
                refreshItemsLayout();
                nextPageButton.Enabled = true;
            }
            refreshPageButtonState();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if(currentPageIndex < maxPage)
            {
                previousPageButton.Enabled = true;
                getDataFromDB(++currentPageIndex);
                refreshPageLabel();
                refreshItemsLayout();
            }
            refreshPageButtonState();
        }

        void refreshPageButtonState() // Refresh de la cliquabilité des boutons Précédent et Suivant
        {
            if (currentPageIndex == 0) // Si on est sur la première page, on désactive le bouton précédent
                previousPageButton.Enabled = false;
            else
                previousPageButton.Enabled = true;


            if (currentPageIndex == maxPage - 1) // On a atteint la limite de l'univers des maison, donc on désactive le bouton !
                nextPageButton.Enabled = false;
            else
                nextPageButton.Enabled = true;
        }

        void refreshPageLabel()
        {
            pageIndexLabel.Text = (currentPageIndex + 1).ToString() + "/" + maxPage;
        }
        
        private void InitializeComponent()
        {
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.addHouseButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.pageIndexLabel = new System.Windows.Forms.Label();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.searchGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchGroupBox.Controls.Add(this.groupBox1);
            this.searchGroupBox.Controls.Add(this.searchButton);
            this.searchGroupBox.Controls.Add(this.searchTextBox);
            this.searchGroupBox.Location = new System.Drawing.Point(7, 3);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(380, 135);
            this.searchGroupBox.TabIndex = 0;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Rechercher une location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minPriceTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maxPriceTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prix";
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minPriceTextBox.Location = new System.Drawing.Point(66, 19);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(99, 20);
            this.minPriceTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "et";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Entre";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(6, 98);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(368, 31);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Lancer la recherche";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(6, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(368, 20);
            this.searchTextBox.TabIndex = 0;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(662, 416);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.searchGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nextPageButton);
            this.splitContainer1.Panel2.Controls.Add(this.previousPageButton);
            this.splitContainer1.Panel2.Controls.Add(this.pageIndexLabel);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 450);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 2;
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxPriceTextBox.Location = new System.Drawing.Point(253, 19);
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(99, 20);
            this.maxPriceTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.addHouseButton);
            this.groupBox2.Controls.Add(this.titleTextBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ajouter une location";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.priceTextBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prix";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceTextBox.Location = new System.Drawing.Point(6, 22);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(124, 20);
            this.priceTextBox.TabIndex = 7;
            // 
            // addHouseButton
            // 
            this.addHouseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addHouseButton.Location = new System.Drawing.Point(148, 212);
            this.addHouseButton.Name = "addHouseButton";
            this.addHouseButton.Size = new System.Drawing.Size(226, 33);
            this.addHouseButton.TabIndex = 1;
            this.addHouseButton.Text = "Ajouter";
            this.addHouseButton.UseVisualStyleBackColor = true;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.Location = new System.Drawing.Point(6, 20);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(368, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.descriptionTextBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 142);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(6, 19);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(356, 117);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // pageIndexLabel
            // 
            this.pageIndexLabel.AutoSize = true;
            this.pageIndexLabel.Location = new System.Drawing.Point(317, 429);
            this.pageIndexLabel.Name = "pageIndexLabel";
            this.pageIndexLabel.Size = new System.Drawing.Size(35, 15);
            this.pageIndexLabel.TabIndex = 2;
            this.pageIndexLabel.Text = "page";
            this.pageIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousPageButton
            // 
            this.previousPageButton.Enabled = false;
            this.previousPageButton.Location = new System.Drawing.Point(259, 424);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(52, 23);
            this.previousPageButton.TabIndex = 3;
            this.previousPageButton.Text = "<";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(358, 424);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(52, 23);
            this.nextPageButton.TabIndex = 4;
            this.nextPageButton.Text = ">";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1082, 474);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Airbnb via MongoDB";
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
