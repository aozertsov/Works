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
        static void DigitCorrect(Lst l1, Lst l2)
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
        }
        public new void Add(int x)
        {
            if (this[1] == 0)
            {
                for (int l = 1; l < this.Count - 1; l++)
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
        static void Subtraction(Lst op1, Lst op2, Lst result)
        {
            int i = 1;
            result.Reverse(1, result.Count - 1);
            op1.Reverse(1, op1.Count - 1);
            op2.Reverse(1, op2.Count - 1);
            for (i = 1; i < op1.Count - 1; i++)
            {
                result.MyInsert(i, op1[i] - op2[i]);
                if (result[i] < 0)
                {
                    result[i] += 10;
                    result.MyInsert(i + 1, -1);
                }
            }
            result.MyInsert(i, op1[i] - op2[i]);
            result.Reverse(1, result.Count - 1);
            while (result.Count > 2 & result[1] == 0)
            {
                result.RemoveAt(1);
            }
            op1.Reverse(1, op1.Count - 1);
            op2.Reverse(1, op2.Count - 1);
        }
        public static Lst operator +(Lst l1, Lst l2)
        {
            Lst lst = new Lst();
            if (l1[0] == l2[0])
            {
                lst[0] = l1[0];
                DigitCorrect(l1, l2);
                lst.Reverse(1,lst.Count-1);
                //Console.WriteLine(lst);
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                //Console.WriteLine(l2);
                for(int i = 1; i < l1.Count; i++)
                {
                    lst.MyInsert(i, l1[i] + l2[i]);
                    if (lst[i] > 9)
                    {
                        lst[i] -= 10;
                        lst.MyInsert(i+1, 1);//почему ошибка???
                    }
                    //Console.WriteLine(lst);
                }
                //lst.MyInsert(i, l1[i] + l2[i]);
                //if (lst[i] > 9)
                //{
                //    lst[i] -= 10;
                //    lst.MyInsert(i + 1, 1);
                //}
                lst.Reverse(1,lst.Count-1);
                l1.Reverse(1, l1.Count - 1);
                l2.Reverse(1, l2.Count - 1);
                if (lst.Count == 2 && lst[1] == 0)
                    lst[0] = 1;
                SignificantNulls(l1);
                SignificantNulls(l2);
                SignificantNulls(lst);
                return lst;
            }
            else
            {
                l2[0] *= -1;
                Lst l3 = l1 - l2;
                l2[0] *= -1;
                return l3;
            }

        }
        public static Lst operator -(Lst l1, Lst l2)
        {
            Lst lst = new Lst();
            if (l1[0] == l2[0])
            {
                DigitCorrect(l1, l2);
                if (Comprassion(l1, l2))
                {
                    lst[0] = l1[0];
                    Subtraction(l1, l2, lst);
                }
                else
                {
                    lst[0] = -1 * l2[0];
                    Subtraction(l2, l1, lst);
                }
                if (lst.Count == 2 && lst[1] == 0)
                    lst[0] = 1;
                SignificantNulls(l1);
                SignificantNulls(l2);
                SignificantNulls(lst);
                return lst;
            }
            else
            {
                l2[0] *= -1;
                Lst l3 = l1 + l2;
                l2[0] *= -1;
                return l3;
            }
        }
        protected static void SignificantNulls(Lst l1)
        {
            int i = 0;
            if (l1.Count > 2 && l1[1] == 0)
                i = 1; 
            while (i < l1.Count - 1 && l1[i] == 0)
                i++;
            if (i > 0)
                l1.RemoveRange(1, i-1);
                
        }
        public static Lst operator *(Lst l1, Lst l2)
        {
            Lst res = new Lst();

            l2.Reverse(1, l2.Count - 1);
            int i = 1;
            while (i < l2.Count)
            {
                Lst lst = new Lst();
                lst = l2[i] * l1;
                for(int rank = i - 1; rank > 0; rank--)
                {
                    lst.Add(0);
                }
                res +=lst;
                i++;
            }
            l2.Reverse(1, l2.Count - 1);
            res[0] = (l1[0] == l2[0]) ? 1 : -1;
            return res;
        }
        public static Lst operator *(int a, Lst l)
        {
            Lst result = new Lst();
            l.Reverse(1, l.Count - 1);
            for (int i = 1; i < l.Count; i++)
            {
                result.MyInsert(i, a * l[i]);
                if (result[i] > 9)
                {
                    result.MyInsert(i + 1, result[i] / 10);//почему ошибка???
                    result[i] %= 10;
                }
            }
            l.Reverse(1, l.Count - 1);
            result.Reverse(1, result.Count - 1);
            return result;
        }
    }
}
