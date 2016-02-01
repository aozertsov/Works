using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Competitor: Hand
    {        
        public override void WriteCard()
        {
            Console.WriteLine("cards on competitor's hand:");
            for (int i = 0; i < onthehand.Count; i++)
            {
                Console.WriteLine(onthehand[i]);
            }
        }
    }
}
