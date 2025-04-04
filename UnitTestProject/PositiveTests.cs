using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK;

namespace UnitTestProject
{
    [TestClass]
    public class PositiveTests
    {
        [TestMethod]
        public void ValidScores()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.Results("22", "38", "20", out int total, out string grade));
            Assert.AreEqual(80, total);
            Assert.AreEqual("5", grade);
        }

        [TestMethod]
        public void MinScores()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.Results("0", "0", "0", out int total, out string grade));
            Assert.AreEqual(0, total);
            Assert.AreEqual("2", grade);
        }

        [TestMethod]
        public void AverageScores()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.Results("10", "20", "5", out int total, out string grade));
            Assert.AreEqual(35, total);
            Assert.AreEqual("4", grade);
        }

        [TestMethod]
        public void BorderlinePass()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.Results("8", "5", "3", out int total, out string grade));
            Assert.AreEqual(16, total);
            Assert.AreEqual("3", grade);
        }

        [TestMethod]
        public void OneModuleMaxOtherZero()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.Results("16", "0", "0", out int total, out string grade));
            Assert.AreEqual(16, total);
            Assert.AreEqual("3", grade);
        }
    }
}