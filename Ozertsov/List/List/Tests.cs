using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace List
{
    [TestFixture]
    class Tests
    {
        [Test]
        public static void AdditionSimpleTest()
        {
            Lst port = new Lst(1);
            Lst port1 = new Lst(1);
            Lst result = new Lst(2);
            Assert.AreEqual(result, port + port1);
        }
        [Test]
        public static void AdditionSaveRankTest()
        {
            Lst port = new Lst(11);
            Lst port1 = new Lst(1);
            Lst result = new Lst(12);
            Assert.AreEqual(result, port + port1);
        }
        [Test]
        public static void AdditionSimpleModificationRankTest()
        {
            Lst l1 = new Lst(111);
            Lst l2 = new Lst(9);
            Lst l3 = new Lst(120);
            Assert.AreEqual(l3, l1 + l2);
        }
        [Test]
        public static void AdditionNotFirstModificationRankTest()
        {
            Lst l1 = new Lst(111);
            Lst l2 = new Lst(90);
            Lst l3 = new Lst(201);
            Assert.AreEqual(l3, l1 + l2);
        }
        [Test]
        public static void AdditionSameModificationRankTest()
        {
            Lst l1 = new Lst(121);
            Lst l2 = new Lst(99);
            Lst l3 = new Lst(220);
            Assert.AreEqual(l3, l1 + l2);
        }
        [Test]
        public static void AdditionNullTest()
        {
            Lst l1 = new Lst(121);
            Lst l2 = new Lst();
            Lst l3 = new Lst(121);
            Assert.AreEqual(l3, l1 + l2);
        }
        
        [Test]
        public static void AdditionPosNegSimpleTest()
        {
            Lst l1 = new Lst(21);
            Lst l2 = new Lst(-11);
            Lst l3 = new Lst(10);
            Assert.AreEqual(l3, l1 + l2);
            Assert.AreEqual(l3, l1 + l2);
        }
        [Test]
        public static void AdditionNegPosSimpleTest()
        {
            Lst l1 = new Lst(21);
            Lst l2 = new Lst(-11);
            Lst l3 = new Lst(10);
            Console.WriteLine(l2 + l1);
            l2 += l1;
            Assert.AreEqual(l3, l2);

            Assert.AreEqual(l3, l2);
        }
        [Test]
        public static void SubtractionSimpleTest()
        {
            Lst l1 = new Lst(-1);
            Lst l2 = new Lst(-1);
            Lst l3 = new Lst();
            Assert.AreEqual(l3, l1 - l2);
        }
        [Test]
        public static void AdditionRandomTest()
        {
            Random x = new Random();
            Random y = new Random();
            int op1 = x.Next(-1000, 1000);
            int op2 = x.Next(-1000, 1000);
            int result = op1 + op2;
            Lst l1 = new Lst(op1);
            Lst l2 = new Lst(op2);
            Lst l3 = new Lst(result);
            Console.WriteLine(op1 + " + " + op2 + " = " + result);
            Console.WriteLine(l1 + " + " + l2 + " = " + (l1 + l2) + "but must be" + l3);
            Assert.AreEqual(l3, l1 + l2);
        }
        [Test]
        public static void SubtractionSignificantNullsTest()
        {
            Lst l1 = new Lst(100);
            Lst l2 = new Lst(99);
            Lst l3 = new Lst(1);
            Assert.AreEqual(l3, l1 - l2);
        }
        [Test]
        public static void MultiplicationTest()
        {
            Lst l1 = new Lst(13);
            int p = 9;
            Lst res = new Lst(117);
            Assert.AreEqual(res, p * l1);
            Assert.AreEqual(res, p * l1);
        }
        [Test]
        public static void MultiplicationListTest()
        {
            Lst l1 = new Lst(11);
            Lst l2 = new Lst(12);
            Lst res = new Lst(132);
            Assert.AreEqual(res, l1 * l2);
            Assert.AreEqual(res, l1 * l2);
        }
        [Test]
        public static void MultiplicationRandomTest()
        {
            Random x = new Random();
            Random y = new Random();
            int op1 = x.Next(-1000, 1000);
            int op2 = x.Next(-1000, 1000);
            int result = op1 * op2;
            Lst l1 = new Lst(op1);
            Lst l2 = new Lst(op2);
            Lst l3 = new Lst(result);
            Console.WriteLine(op1 + " + " + op2 + " = " + result);
            Console.WriteLine(l1 + " + " + l2 + " = " + (l1 * l2) + "but must be" + l3);
            Assert.AreEqual(l3, l1 * l2);
        }
    }
}
