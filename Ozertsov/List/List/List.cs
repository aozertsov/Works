using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Lst:List<int>
    {
        public Lst()
        {
            this.Capacity = 2;
            base.Add(1);
            base.Add(0);
        }
        public Lst(int x)
        {
            this.Capacity = 2;
            base.Add((x >= 0) ? 1 : -1);
            this.Reverse();
            x = Math.Abs(x); 
            while (x>0)
            {
                base.Add(x % 10);
                x = x / 10;
            }
            this.Reverse(1, this.Count - 1);
        }

        public void Add(int x)
        {
            if (this[1] == 0)
            {
                for (int l = 1; l < this.Capacity - 1; l++)
                {
                    this[l] = this[l + 1];
                }
                this[this.Capacity - 1] = x;
            }
            else
                base.Add(x);
        }
        public override string ToString()
        {
            string s = "";
            s += (this[0] == 1) ? "+" : "-";
            for (int i = 1; i < this.Count; i++)
            {
                s += this[i].ToString();
                
            }
            return s;
        }
        static bool Comprassion (Lst l1, Lst l2)
        {
            if (l1[0] == l2[0])
            {
                if (l1.Count > l2.Count)
                    return true;
                else if (l1.Count < l2.Count)
                    return false;
                else
                {
                    for (int i = 1; ; i++)
                    {
                        if (i != l1.Count - 1)
                        {
                            if (l1[i] > l2[i])
                                return true;
                            else if (l1[i] < l2[i])
                                return false;
                            else
                                continue;
                        }
                        else if (l1[i] >= l2[i])
                            return true;
                        else
                            return false;
                    }
                }
            }
            else if (l1[0] == 1)
                return true;
            else
                return false;
        }
        void MyInsert(int i, int k)
        {
            if (this.Count != 0 && i < this.Count && this[i] == 0)
                this[i] = k;
            else if (i < this.Count && this[i] != 0)
                this[i] += k;
            else
                this.Insert(i, k);

        }
        public static Lst operator +(Lst l1, Lst l2)
        {
            Lst lst = new Lst();
            if (l1[0] == l2[0])
            {
                lst[0] = l1[0];
                int i = l1.Count - l2.Count;
                if (i != 0)
                {
                    //add elements
                    while (i > 0)
                    {
                        l2.Insert(1, 0);
                        i--;
                    }
                    while (i < 0)
                    {
                        l1.Insert(1, 0);
                        i++;
                    }
                }
                lst.Reverse(1,lst.Count-1);
                //Console.WriteLine(lst);
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                Console.WriteLine(l2);
                for(i = 1; i < l1.Count - 1; i++)
                {
                    lst.MyInsert(i, l1[i] + l2[i]);
                    if (lst[i] > 9)
                    {
                        lst[i] -= 10;
                        lst.MyInsert(i+1, 1);//почему ошибка???
                    }
                    Console.WriteLine(lst);
                }
                lst.MyInsert(i, l1[i] + l2[i]);
                if (lst[i] > 9)
                {
                    lst[i] -= 10;
                    lst.MyInsert(i + 1, 1);
                }
                lst.Reverse(1,lst.Count-1);
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                return lst;
            }
            else if (Comprassion(l1, l2))
            {
                l2[0] *= -1;
                return l1 - l2;
            }
            else
            {
                l1[0] *= -1;
                return l2 - l1;
            }

        }
        public static Lst operator -(Lst l1, Lst l2)
        {
            Lst lst = new Lst();
            if (l1[0] == l2[0])
            {   
                int i = l1.Count - l2.Count;
                if (i != 0)
                {
                    while (i > 0)
                    {
                        l2.Insert(1, 0);
                        i--;
                    }
                    while (i < 0)
                    {
                        l1.Insert(1, 0);
                        i++;
                    }
                }
                lst.Reverse(1, lst.Count - 1);
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                if (Comprassion(l1, l2))
                {
                    lst[0] = l1[0];
                    for (i = 1; i < l1.Count - 1; i++)
                    {
                        lst.MyInsert(i, l1[i] - l2[i]);
                        if (lst[i] < 0)
                        {
                            lst[i] += 10;
                            lst.MyInsert(i, -1);
                        }
                    }
                    lst.MyInsert(i, l1[i] - l2[i]);
                }
                else
                {
                    lst[0] = l2[0];
                    for (i = 1; i < l1.Count - 1; i++)
                    {
                        lst.MyInsert(i, l2[i] - l1[i]);
                        if (lst[i] < 0)
                        {
                            lst[i] += 10;
                            lst.MyInsert(i + 1, -1);
                        }
                    }
                lst.MyInsert(i, l2[i] - l1[i]);
                }
                lst.Reverse(1, lst.Count - 1);
                while (lst.Count > 2 & lst[1] == 0)
                {
                    lst.RemoveAt(1);
                }
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                return lst;
                
            }
            else
            {
                l2[0] *= -1;
                return l1 + l2;
            }
        }
                
    }
}
