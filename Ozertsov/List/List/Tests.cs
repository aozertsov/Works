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
    }
}
