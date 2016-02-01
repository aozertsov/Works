using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    class Hand
    {
        protected List<Card> onthehand = new List<Card>();
        public int OnHand()
        {
            return onthehand.Count;
        }
        public Card this[int i]
        {
            get
            {
                return onthehand[i];
            }
        }

        public void PutOnHand(Card ob)
        {
            onthehand.Add(ob);

        }
        public bool IsOnHand(Card ob)
        {
            for (int i = 0; i < onthehand.Count(); i++)
            {
                if (onthehand[i] == ob)
                    return true;
            }
            return false;
        }

        public virtual void WriteCard()
        {
            Console.WriteLine("cards on your hand:");
            for (int i = 0; i< onthehand.Count;i++)
            {
                Console.WriteLine(onthehand[i]);
            }
        }
        public int Summa()
        {
            int sum = 0;
            for (int i = 0; i < onthehand.Count(); i++)
            {
                sum += onthehand[i].Cost;
            }
            return sum;
        }
    }
}
