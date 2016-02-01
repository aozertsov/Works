using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{

    delegate void PicWr(Hand ob, PictureBox pb);
    class Program
    {
        //CUI c = new CUI();

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        /// <summary>
        /// Frees the console.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        static string[] faces = new string[] { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        static string[] lears = new string[] { "Clubs"/*, "chervi", "pikki", "bubbi"*/ };

        static Card CreatorCard(params Hand[] ob)
        {
            Random r = new Random();
            Random p = new Random();
            Card card = new Card(faces[r.Next(0, faces.Length)], lears[r.Next(0, lears.Length)]);
            if (ob.Length == 1)
            {
                if (!ob[0].IsOnHand(card))
                    return card;
            }
            else
                if (!ob[0].IsOnHand(card) & !ob[1].IsOnHand(card))
                    return card;
            return CreatorCard(ob);
        }
        public static void PutOnHand(params Hand[] ob)
        {
            if (ob.Length == 1)
            {
                Card cr;
                cr = CreatorCard(ob[0]);
                ob[0].PutOnHand(cr);
            }
            else
                ob[1].PutOnHand(CreatorCard(ob[0], ob[1]));
        }
        static void Main(string[] args)
        {
            CUI c = new CUI();

            System.Windows.Forms.MessageBox.Show("The application "
         + "is running now, but no forms have been shown.");
            
            // Show the instance of the form modally.
            c.ShowDialog();


            AllocConsole();
            Random r = new Random();
            string answer = "yes";
            //do
            //{
            //    PutOnHand(hand);
            //    hand.WriteCard();
            //    Console.WriteLine("put cards on your hand?");
            //    do
            //    {
            //        if (answer != "yes" && answer != "no")
            //            Console.WriteLine("enter correct answer: \"yes\" or \"no\"");
            //    answer = Console.ReadLine();
            //    }
            //    while (answer != "yes" && answer != "no");
            //}
            //while (answer != "no");
            //for (int i = 0; i < r.Next(1, 10); i++)
            //{
            //    PutOnHand(hand, comp);
            //}
            //Console.WriteLine("your result:" + hand.Summa());
            //comp.WriteCard();
            //Console.WriteLine("competitor result:" + comp.Summa());
            ////Console.WriteLine(hand[0]);
            ////string str = Console.ReadLine();
        }
    }
}
