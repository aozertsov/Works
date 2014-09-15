using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {

        static string[] faces = new string[] { "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        static string[] lears = new string[] { "tref", "chervi", "pikki", "bubbi" };

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
        static void PutOnHand(params Hand[] ob)
        {
            if (ob.Length == 1)
                ob[0].PutOnHand(CreatorCard(ob[0]));
            else
                ob[1].PutOnHand(CreatorCard(ob[0], ob[1]));
        }
        static void Main(string[] args)
        {
            Hand hand = new Hand();
            Competitor comp = new Competitor();
            Random r = new Random();
            string answer = "yes";
            do
            {
                PutOnHand(hand);
                hand.WriteCard();
                Console.WriteLine("put cards on your hand?");
                do
                {
                    if (answer != "yes" && answer != "no")
                        Console.WriteLine("enter correct answer: \"yes\" or \"no\"");
                answer = Console.ReadLine();
                }
                while (answer != "yes" && answer != "no");
            }
            while (answer != "no");
            for (int i = 0; i < r.Next(1, 10); i++)
            {
                PutOnHand(hand, comp);
            }
            Console.WriteLine("your result:" + hand.Summa());
            comp.WriteCard();
            Console.WriteLine("competitor result:" + comp.Summa());
        }
    }
}
