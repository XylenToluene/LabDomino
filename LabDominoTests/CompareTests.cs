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
    public class CompareTests
    {
        [TestMethod()]
        public void CompareEndRoundKTest()
        {
            Player player = new Player();
            Compare compare = new Compare();

            player.KInHand.Add("1|2");
            player.KInHand.Add("6|6");

            int expected = 15;

            compare.CompareEndRoundK(player);

            int result = player.Score;

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void CompareEndRoundKTest2()
        {
            Player player = new Player();
            Compare compare = new Compare();

            player.KInHand.Add("0|0");

            int expected = 0;

            compare.CompareEndRoundK(player);

            int result = player.Score;

            Assert.AreEqual(expected, result);

        }

        [TestMethod()]
        public void ConvertKOnTableTest()
        {
            Compare compare = new Compare();
            Game game = new Game();

            Game.KOnTable.Add("5|6");

            int expected = 6;

            compare.ConvertKOnTable();

            int result = compare.z2T;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertKOnTableTest2()
        {
            Compare compare = new Compare();
            Game game = new Game();

            Game.KOnTable.Add("0|0");

            int expected = 0;

            compare.ConvertKOnTable();

            int result = compare.z2T;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConvertKOnTableTest3()
        {
            Compare compare = new Compare();
            Game game = new Game();

            Game.KOnTable.Add("2|1");

            int expected = 1;

            compare.ConvertKOnTable();

            int result = compare.z2T;

            Assert.AreEqual(expected, result);
        }
    }
}