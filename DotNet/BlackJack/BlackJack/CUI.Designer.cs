using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace BlackJack
{
    //delegate void Pict(Card c);

    partial class CUI
    {
        
      /*  public static event Pict Event;
        public static void OnSomeEvent(Card c)
        {
            if (Event != null)
            {
                Event(c);
            }
        }*/

        public static Bitmap CombineBitmap(IEnumerable<string> files)
        {
            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    // create a Bitmap from the file and add it to the list
                    Bitmap bitmap = new Bitmap(image);

                    // update the size of the final bitmap
                    width += bitmap.Width/2;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                // create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                // get a graphics object from the image so we can draw on it
                using (Graphics g = Graphics.FromImage(finalImage))
                {
                    // set background color
                    g.Clear(Color.Transparent);

                    // go through each image and draw it on the final image
                    foreach (Bitmap image in images)
                    {
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                }

                return finalImage;
            }
            catch (Exception)
            {
                if (finalImage != null) finalImage.Dispose();
                throw;
            }
            finally
            {
                // clean up memory
                foreach (Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUI));

            this.hand = new Hand();
            this.comp = new Competitor();
            this.pw = new PicWr(CUI.WriteCards);
            this.Start = new System.Windows.Forms.Button();
            this.CardReverse = new System.Windows.Forms.PictureBox();
            this.HandCard = new System.Windows.Forms.PictureBox();
            this.CardCompetitor = new System.Windows.Forms.PictureBox();
            this.YES = new System.Windows.Forms.Button();
            this.NO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CardReverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardCompetitor)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(315, 294);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(208, 63);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // CardReverse
            // 
            this.CardReverse.Image = ((System.Drawing.Image)(resources.GetObject("CardReverse.Image")));
            this.CardReverse.Location = new System.Drawing.Point(12, 255);
            this.CardReverse.Name = "CardReverse";
            this.CardReverse.Size = new System.Drawing.Size(123, 183);
            this.CardReverse.TabIndex = 1;
            this.CardReverse.TabStop = false;
            this.CardReverse.Visible = false;
            this.CardReverse.Click += new System.EventHandler(this.CardReverse_Click);
            // 
            // HandCard
            // 
            this.HandCard.Location = new System.Drawing.Point(12, 521);
            this.HandCard.Name = "HandCard";
            this.HandCard.Size = new System.Drawing.Size(859, 183);
            this.HandCard.TabIndex = 2;
            this.HandCard.TabStop = false;
            // 
            // CardCompetitor
            // 
            this.CardCompetitor.Location = new System.Drawing.Point(12, 15);
            this.CardCompetitor.Name = "CardCompetitor";
            this.CardCompetitor.Size = new System.Drawing.Size(859, 183);
            this.CardCompetitor.TabIndex = 3;
            this.CardCompetitor.TabStop = false;
            // 
            // YES
            // 
            this.YES.Location = new System.Drawing.Point(315, 464);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(75, 23);
            this.YES.TabIndex = 4;
            this.YES.Text = "YES";
            this.YES.UseVisualStyleBackColor = true;
            this.YES.Visible = false;
            this.YES.Click += new System.EventHandler(this.YES_Click);
            // 
            // NO
            // 
            this.NO.Location = new System.Drawing.Point(448, 464);
            this.NO.Name = "NO";
            this.NO.Size = new System.Drawing.Size(75, 23);
            this.NO.TabIndex = 5;
            this.NO.Text = "NO";
            this.NO.UseVisualStyleBackColor = true;
            this.NO.Visible = false;
            // 
            // CUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 716);
            this.Controls.Add(this.NO);
            this.Controls.Add(this.YES);
            this.Controls.Add(this.CardCompetitor);
            this.Controls.Add(this.HandCard);
            this.Controls.Add(this.CardReverse);
            this.Controls.Add(this.Start);
            this.Name = "CUI";
            this.Text = "GUI";
            ((System.ComponentModel.ISupportInitialize)(this.CardReverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardCompetitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Start;
        private PictureBox CardReverse;
        private PictureBox HandCard;
        private PictureBox CardCompetitor;
        private Button YES;
        private Button NO;
        private Hand hand;
        private Competitor comp;
        public PicWr pw;
    }
}