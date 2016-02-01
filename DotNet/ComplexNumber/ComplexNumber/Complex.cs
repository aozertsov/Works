using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumber
{
    class Complex
    {
        public int x;
        public int y;

        public Complex()
        {
            this.x = this.y = 0;
        }
        public Complex(int x , int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Complex operator + (Complex op1, Complex op2)
        {
            Complex op3 = new Complex();
            op3.x = op1.x + op2.x;
            op3.y = op1.y + op2.y;
            return op3;
        }

        public static Complex operator * (Complex op1, Complex op2)
        {
            Complex op3 = new Complex();
            op3.x = op1.x*op2.x - op1.y*op2.y;
            op3.y = op1.x*op2.y + op1.y*op2.x;
            return op3;
        }
        public override string ToString()
        {
            string s = "";
            s += this.x.ToString();
            s += " + i";
            s += this.y.ToString();
            return s;
        }

        public Complex Degree(Complex op1, int k)
        {
            Complex op = new Complex();
            op.x = op1.x;
            op.y = op1.y;
            if (k == 0)
            {
                op.x = 1;
                op.y = 0;
                return op;
            }
            else
            {
                if (k == 1)
                    return op1;
                else
                {
                    return op*Degree(op, k - 1);
                }     
            }
        }

        public double Module(Complex op)
        {
            return Math.Sqrt(op.x*op.x + op.y*op.y);
        }


    }
}
