using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Numbers
{
    class Rational//:Number
    {
        protected int numenator, denominator, intPart;
        protected bool sign;
        public Rational(int num1, int num2)
        {
            if (num2 != 0)
            {
                numenator = num1;
                denominator = num2;
                sign = true;
                intPart = 0;
                this.GetIntPart();
                this.Cancellation();
            }
            else
            {
                Console.WriteLine("denominator can't be null, it is 1");
                intPart = num1;
                numenator = 0;
                denominator = 1;
                sign = true;
                this.GetIntPart();
                this.Cancellation();

            }
        }

        public Rational(char sign, int num1, int num2)
        {
            if (num2 != 0)
            {
                intPart = 0;
                numenator = num1;
                denominator = num2;
                this.sign = sign == '+' ? true : false;

                this.GetIntPart();
                this.Cancellation();
            }
            else
            {
                Console.WriteLine("denominator can't be null, it is 1");
                intPart = num1;
                numenator = 0;
                denominator = 1;
                this.sign = sign == '+' ? true : false;
                this.GetIntPart();
                this.Cancellation();
            }
        }
        public Rational(int num)
        {

            intPart = num;
            numenator = 0;
            denominator = 1;
            sign = true;
        }
        public Rational()
        {
            intPart = numenator = 0;
            sign = true;
            denominator = 1;
        }
        void GetMixedView()
        {
            numenator += intPart * denominator;
            intPart = 0;
        }
        void Cancellation()
        {
            if (numenator < denominator && numenator != 0)
            {
                for (int i = 2; i <= numenator; i++)
                {
                    if (numenator % i == 0 && denominator % i == 0)
                    {
                        numenator /= i;
                        denominator /= i;
                        i--;
                    }

                }
            }

        }//сокращать только правильную дробь
        void GetIntPart()
        {
            if (numenator >= denominator)
            {
                numenator -= denominator;
                intPart++;
                this.GetIntPart();
            }
        }
        public override string ToString()
        {
            if (this.intPart != 0 && this.sign)
                return this.intPart.ToString() + " + " + this.numenator.ToString() + "/" + this.denominator.ToString();
            else
            {
                if (sign)
                    return this.numenator.ToString() + "/" + this.denominator.ToString();
                else
                {
                    if (this.intPart != 0)
                        return "-" + this.intPart.ToString() + " + " + "-" + this.numenator.ToString() + "/" + this.denominator.ToString();
                    else
                        return "-" + this.numenator.ToString() + "/" + this.denominator.ToString();
                }
            }
        }

        public static Rational operator +(Rational obj1, Rational obj2)
        {
            obj1.GetMixedView();
            obj2.GetMixedView();
            int i;
            for (i = 1; (obj1.denominator * i % obj2.denominator != 0); i++) ;
            obj1.denominator *= i;
            obj1.numenator *= i;
            i = obj1.denominator / obj2.denominator;
            obj2.denominator *= i;
            obj2.numenator *= i;
            if (obj1.sign && obj2.sign)
            { 
                Rational obj = new Rational(obj1.numenator + obj2.numenator, obj1.denominator);
                obj.GetIntPart();
                obj.Cancellation();
                return obj;
            }
            else
            {
                if (!obj1.sign)
                {
                    Rational obj = new Rational(-1 * obj1.numenator + obj2.numenator, obj1.denominator);
                    obj.GetIntPart();
                    obj.Cancellation();
                    return obj;
                }
                else
                {
                    Rational obj = new Rational(obj1.numenator + -1 * obj2.numenator, obj1.denominator);
                    obj.GetIntPart();
                    obj.Cancellation();
                    return obj;
                }
            }
        
        }
        public static Rational operator +(int x, Rational obj)
        {
            obj.GetMixedView();
            if (x>=0 && obj.sign)
            {
                obj.numenator += x*obj.denominator;
                obj.GetIntPart();
                obj.Cancellation();
                return obj;
            }
            else
            {
                if (obj.sign)
                {
                    obj.numenator -= x * obj.denominator;
                    obj.sign = (obj.numenator < 0) ? false: true;
                    obj.numenator *= (obj.numenator < 0) ? -1 : 1;
                    obj.GetIntPart();
                    obj.Cancellation();
                    return obj;
                }
                else
                {
                    if (x>=0)
                    {
                        obj.numenator -= x * obj.denominator;
                        obj.sign = (obj.numenator < 0) ? false : true;
                        obj.numenator *= (obj.numenator < 0) ? -1 : 1;
                        obj.GetIntPart();
                        obj.Cancellation(); 
                        return obj;
                    }
                    else
                    {
                        obj.numenator += x * obj.denominator;
                        obj.GetIntPart();
                        obj.Cancellation(); 
                        return obj;
                    }
                }
            }
        }
        public static Rational operator +(Rational obj, int x)
        {
            obj.GetMixedView();
            if (x >= 0 && obj.sign)
            {
                obj.numenator += x * obj.denominator;
                obj.GetIntPart();
                obj.Cancellation();
                return obj;
            }
            else
            {
                if (obj.sign)
                {
                    obj.numenator -= x * obj.denominator;
                    obj.sign = (obj.numenator < 0) ? false : true;
                    obj.numenator *= (obj.numenator < 0) ? -1 : 1;
                    obj.GetIntPart();
                    obj.Cancellation();
                    return obj;
                }
                else
                {
                    if (x >= 0)
                    {
                        obj.numenator -= x * obj.denominator;
                        obj.sign = (obj.numenator < 0) ? false : true;
                        obj.numenator *= (obj.numenator < 0) ? -1 : 1;
                        obj.GetIntPart();
                        obj.Cancellation();
                        return obj;
                    }
                    else
                    {
                        obj.numenator += x * obj.denominator;
                        obj.GetIntPart();
                        obj.Cancellation();
                        return obj;
                    }
                }
            }
        }
        public static Rational operator *(Rational obj1, Rational obj2)
        {
            obj1.GetMixedView();
            obj2.GetMixedView();
            Rational obj = new Rational(obj1.numenator * obj2.numenator, obj1.denominator * obj2.denominator);
            if ((obj1.sign && obj2.sign) || (!obj1.sign && !obj2.sign))
            {
                obj.sign = true;
            }
            else
            {
                obj.sign = false;
            }
            obj.GetIntPart();
            obj.Cancellation();
            return obj;
        }
        public static Rational operator *(int x, Rational obj)
        {
            obj.sign = (x < 0) ? obj.sign : !obj.sign;
            obj.GetMixedView();
            obj.numenator *= Math.Abs(x);
            obj.GetIntPart();
            obj.Cancellation();
            return obj;
        }
        public static Rational operator *(Rational obj, int x)
        {
            obj.sign = (x < 0) ? obj.sign : !obj.sign;
            obj.GetMixedView();
            obj.numenator *= Math.Abs(x);
            obj.GetIntPart();
            obj.Cancellation();
            return obj;
        }
        public bool Abs
        {
            set
            {
                sign = true;
            }
        }
        public void Degree(int x)
        {
            if (!this.sign && x % 2 != 0)
                this.sign = false;
            if (x > 0)
            {
                this.GetMixedView();
                int num = this.numenator, denum = this.denominator;
                for (int i = 0; i < x; i++)
                {
                    this.numenator *= num;
                    this.denominator *= denum;
                }
                this.GetIntPart();
                this.Cancellation();
            }
            else 
                if (x == 0)
                {
                    this.GetMixedView();
                    this.numenator = 1;
                    this.denominator = 1;
                    this.GetIntPart();
                    this.Cancellation();
                }
                else
                {
                    this.GetMixedView();
                    this.numenator += this.denominator;
                    this.denominator = this.numenator - this.denominator;
                    this.numenator -= this.denominator;
                    int num = this.numenator, denum = this.denominator;
                    for (int i = 0; i < x; i++)
                    {
                        this.numenator *= num;
                        this.denominator *= denum;
                    }
                    this.GetIntPart();
                    this.Cancellation();
                }
        }//to do log-method;
        public int Numenator
        {
            get
            {
                return numenator;
            }
            set
            {
                this.numenator = Math.Abs(value);
                sign = (value < 0) ? !sign : sign;
            }
        }//property
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                denominator = Math.Abs(value);
                sign = (value < 0) ? !sign : sign;
            }
        }
        public int IntPart
        {
            get
            {
                return intPart;
            }
            set
            {
                intPart = value;
            }
        }
        public bool Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = value;
            }
        }
        
    }
}
