namespace BlackJack
{
    delegate void Pict(Card c);

    partial class CUI
    {
        public static event Pict Event;
        public static void OnSomeEvent(Card c)
        {
            if (Event != null)
            {
                Event(c);
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
            this.Start = new System.Windows.Forms.Button();
            this.CardReverse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CardReverse)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(165, 180);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(164, 37);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // CardReverse
            // 
            this.CardReverse.Image = ((System.Drawing.Image)(resources.GetObject("CardReverse.Image")));
            this.CardReverse.Location = new System.Drawing.Point(12, 138);
            this.CardReverse.Name = "CardReverse";
            this.CardReverse.Size = new System.Drawing.Size(73, 107);
            this.CardReverse.TabIndex = 1;
            this.CardReverse.TabStop = false;
            // 
            // CUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 436);
            this.Controls.Add(this.CardReverse);
            this.Controls.Add(this.Start);
            this.Name = "CUI";
            this.Text = "CUI";
            ((System.ComponentModel.ISupportInitialize)(this.CardReverse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.PictureBox CardReverse;
        //bubbi
    }
}