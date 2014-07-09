using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo2.Test
{
    [TestClass]
    public class MineSweeperTest
    {
        [TestMethod]
        public void EmptyParamThenEmpty()
        {
            var result = MineSweeper.ResolveMineField(string.Empty);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void OneEmptyCellThenZero()
        {
            var result = MineSweeper.ResolveMineField(".");
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void OneMinedCellThenStar()
        {
            var result = MineSweeper.ResolveMineField("*");
            Assert.AreEqual("*", result);
        }

        [TestMethod]
        public void OneLineThenOneLineResult()
        {
            var result = MineSweeper.ResolveMineField("1 5\n..*..\n0 0");
            Assert.AreEqual("Field #1:\n01*10", result);
        }

        [TestMethod]
        public void TwoLineThenTwoLineResult()
        {
            var result = MineSweeper.ResolveMineField("2 5\n..*..\n*...*\n0 0");
            Assert.AreEqual("Field #1:\n12*21\n*212*", result);
        }

        [TestMethod]
        public void OneDelimitedMatrixThenFieldResult()
        {
            var result = MineSweeper.ResolveMineField("2 5\n..*..\n*...*\n0 0");
            Assert.AreEqual("Field #1:\n12*21\n*212*", result);
        }

        [TestMethod]
        public void FinalExerciceMatrixThenFieldResult()
        {
            var result = MineSweeper.ResolveMineField("4 4\n*...\n....\n.*..\n....\n3 5\n**...\n.....\n.*...\n0 0");
            Assert.AreEqual("Field #1:\n*100\n2210\n1*10\n1110\nField #2:\n**100\n33200\n1*100", result);
        }
    }
}
