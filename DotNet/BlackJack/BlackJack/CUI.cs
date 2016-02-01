using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJack.Properties;

namespace BlackJack
{
    partial class CUI : Form
    {
        public event PicWr Writter;
        public CUI()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Visible = false;
            CardReverse.Visible = true;
            YES.Visible = true;
            NO.Visible = true;
        }

        private void CardReverse_Click(object sender, EventArgs e)
        {
            CardReverse.Image = null;
            PictureBox pictureBox2 = new PictureBox
            {
                // задаем размер контейнера, как у родительского контейнера
                Size = CardReverse.Size,
                // можно управлять положением слоя, относительно родительского контейнера
                Location = new Point(31, 11),
                // задаем прозрачность фону
                BackColor = Color.Transparent,
                // изображение слоя

                //Image = (resources.GetObject("CardReverse.Image"))
            };
            Bitmap bitmap = new Bitmap(@"D:\Repositore\Works\Ozertsov\BlackJack\cardreverse.png");

            pictureBox2.Image = bitmap;

            // добавляем слой в родительский контейнер
            CardReverse.Controls.Add(pictureBox2);
        }

        public void IsEvent(Hand ob, PictureBox pb)
        {
            if (Writter != null)
                Writter(ob, pb);
        }
        public static void WriteCards(Hand ob, PictureBox pb)
        {
            pb.Image = null;
            pb.Controls.Clear();
            int number = ob.OnHand();
            pb.Update();

            PictureBox pictureBox2 = new PictureBox
            {
                // задаем размер контейнера, как у родительского контейнера
                Size = new System.Drawing.Size(121, 183),
                //Location = new Point(369 - 55 * (number - 1), 1),
                // задаем прозрачность фону
                BackColor = Color.Transparent,
                // изображение слоя

            };
            Point point = new Point(269 - 55 * (number - 1), 1);
            for (int i = 0; i < number; i++)
            {
                //pictureBox2.Image = null;
                pictureBox2.BackColor = Color.Transparent;
                //задаем начальную точку отрисовки изображения
                pictureBox2.Image = null;
                pictureBox2.Controls.Clear();
                //задаем смещение
                point.Offset(100, 0);
                pictureBox2.Location = point;
                Bitmap bitmap = new Bitmap(@"D:\Repositore\Works\Ozertsov\BlackJack\Cards\" + ob[i].ToString() + ".png");

                pictureBox2.Image = bitmap;
                // добавляем слой в родительский контейнер
                pb.Controls.Add(pictureBox2);
            }
        }

        private void YES_Click(object sender, EventArgs e)
        {
            Program.PutOnHand(hand);
            pw(hand, HandCard);
            //hand.WriteCard();
        }

    }
}
