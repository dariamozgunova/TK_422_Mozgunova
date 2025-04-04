using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK;

namespace UnitTestProject
{
    [TestClass]
    public class NegativeTests
    {
        [TestMethod]
        public void EmptyInput()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.Results("", "", "", out int total, out string grade));
        }

        [TestMethod]
        public void EmptyInputNull()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.Results("", "25", "15", out int total, out string grade));
        }

        [TestMethod]
        public void NonNumericInput()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.Results("привет", "15", "20", out int total, out string grade));
        }

        [TestMethod]
        public void NegativeInput()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.Results("-2", "0", "20", out int total, out string grade));
        }

        [TestMethod]
        public void ExceedingMaxScore()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.Results("50", "41", "27", out int total, out string grade));
        }
    }
}