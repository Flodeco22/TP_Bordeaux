
namespace MongoDB.View
{
    partial class HouseDetails
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.hostGroupBox = new System.Windows.Forms.GroupBox();
            this.hostPictureBox = new System.Windows.Forms.PictureBox();
            this.hostLocationLabel = new System.Windows.Forms.Label();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.nightNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.exitViewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.hostGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nightNumberNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(6, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 250);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(3, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(31, 15);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Titre";
            // 
            // hostGroupBox
            // 
            this.hostGroupBox.Controls.Add(this.hostPictureBox);
            this.hostGroupBox.Controls.Add(this.hostLocationLabel);
            this.hostGroupBox.Location = new System.Drawing.Point(6, 284);
            this.hostGroupBox.Name = "hostGroupBox";
            this.hostGroupBox.Size = new System.Drawing.Size(159, 164);
            this.hostGroupBox.TabIndex = 2;
            this.hostGroupBox.TabStop = false;
            this.hostGroupBox.Text = "Hote";
            // 
            // hostPictureBox
            // 
            this.hostPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostPictureBox.Location = new System.Drawing.Point(6, 19);
            this.hostPictureBox.Name = "hostPictureBox";
            this.hostPictureBox.Size = new System.Drawing.Size(147, 121);
            this.hostPictureBox.TabIndex = 4;
            this.hostPictureBox.TabStop = false;
            // 
            // hostLocationLabel
            // 
            this.hostLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostLocationLabel.AutoSize = true;
            this.hostLocationLabel.Location = new System.Drawing.Point(6, 143);
            this.hostLocationLabel.Name = "hostLocationLabel";
            this.hostLocationLabel.Size = new System.Drawing.Size(84, 15);
            this.hostLocationLabel.TabIndex = 0;
            this.hostLocationLabel.Text = "Emplacement";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(6, 454);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(399, 143);
            this.descriptionRichTextBox.TabIndex = 3;
            this.descriptionRichTextBox.Text = "";
            // 
            // priceLabel
            // 
            this.priceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceLabel.Location = new System.Drawing.Point(171, 284);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(234, 38);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Prix par nuit";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Réserver";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(174, 350);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(231, 36);
            this.totalPriceLabel.TabIndex = 6;
            this.totalPriceLabel.Text = "Prix total";
            this.totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nightNumberNumericUpDown
            // 
            this.nightNumberNumericUpDown.Location = new System.Drawing.Point(314, 327);
            this.nightNumberNumericUpDown.Name = "nightNumberNumericUpDown";
            this.nightNumberNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.nightNumberNumericUpDown.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(183, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre de nuits";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitViewButton
            // 
            this.exitViewButton.Location = new System.Drawing.Point(280, 2);
            this.exitViewButton.Name = "exitViewButton";
            this.exitViewButton.Size = new System.Drawing.Size(125, 23);
            this.exitViewButton.TabIndex = 9;
            this.exitViewButton.Text = "Retour à la liste";
            this.exitViewButton.UseVisualStyleBackColor = true;
            this.exitViewButton.Click += new System.EventHandler(this.exitViewButton_Click);
            // 
            // HouseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exitViewButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nightNumberNumericUpDown);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.hostGroupBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HouseDetails";
            this.Size = new System.Drawing.Size(413, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.hostGroupBox.ResumeLayout(false);
            this.hostGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hostPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nightNumberNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox hostGroupBox;
        private System.Windows.Forms.Label hostLocationLabel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.PictureBox hostPictureBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.NumericUpDown nightNumberNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitViewButton;
    }
}
