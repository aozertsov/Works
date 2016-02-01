using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack
{
    class Card
    {
        string face;
        string lear;
        int cost;
        public int Cost
        {
            get
            {
                return cost;
            }
        }
        public Card(string face, string lear)
        {
            this.face = face;
            this.lear = lear;
            switch (face)
            {
                case "6":
                    cost = 6;
                    break;
                case "7":
                    cost = 7;
                    break;
                case "8":
                    cost = 8;
                    break;
                case "9":
                    cost = 9;
                    break;
                case "10":
                    cost = 10;
                    break;
                case "Jack":
                    cost = 2;
                    break;
                case "Queen":
                    cost = 3;
                    break;
                case "King":
                    cost = 4;
                    break;
                case "Ace":
                    cost = 11;
                    break;
                default:
                    cost = 0;
                    break;
            }
        }
        public override string ToString()
        {
            string str = lear + face;
            return str;
        }

        public static bool operator ==(Card ob1, Card ob2)
        {
            if ((ob1.face == ob2.face) && (ob1.lear == ob2.lear))
                return true;
            return false;
        }
        public static bool operator !=(Card ob1, Card ob2)
        {
            if ((ob1.face == ob2.face) && (ob1.lear == ob2.lear))
                return false;
            return true;
        }
    }
}
