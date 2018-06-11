using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }

        [Test]
        public void Test2()
        {
            Assert.Catch(() =>
            { var x = new Mitarbeiter(0, "Peter"); });
        }

        [Test]
        public void Test3()
        {
            var y = new Mitarbeiter(1000, "Hugo");
            Assert.IsTrue(y.Gehaltt == 1000);
        }

        [Test]
        public void Test4()
        {
            Assert.Catch(() =>
            { var b = new Kunden("name", 16); });
        }

        [Test]
        public void Test5()
        {
            Assert.Catch(() =>
            { var y = new Mitarbeiter(1000, ""); });
        }

        [Test]
        public void Test6()
        {
            var t = new Mitarbeiter(1500,"Klaus");
            Assert.IsTrue(t.Gehaltt == 1500);
            Assert.IsTrue(t.Namee == "Klaus");
        }

        [Test]
        public void Test7()
        {
            Assert.Catch(() => { var h = new Kunden("", 0); });
            Assert.Catch(() => { var h = new Kunden("h", 0); });
            Assert.Catch(() => { var h = new Kunden("", 14); });

        }

        [Test]
        public void Test8()
        {
            Assert.Catch(() =>
            { var b = new Kunden("Martha", 0); });
        }

    }
}
