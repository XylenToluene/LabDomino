using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabDomino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDomino.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void CheckArrayNullTest()
        {
            Game game = new Game();

            string[] AllKosty1 = {};

            bool expected = false;

            bool result = game.CheckArrayNull(AllKosty1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckArrayNullTest2()
        {
            Game game = new Game();

            string[] AllKosty1 = {"1","2","3"};

            bool expected = true;

            bool result = game.CheckArrayNull(AllKosty1);

            Assert.AreEqual(expected, result);
        }
    }
}