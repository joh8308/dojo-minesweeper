using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minesweeper.UnitTest
{
    [TestClass]
    public class MineSweeperUnitTest
    {
        [TestMethod]
        public void Should_Initialize_Col_And_Row()
        {
            var obj = new Minesweeper(2, 5);
            Assert.AreEqual(2, obj.ColsNb);
            Assert.AreEqual(5, obj.RowsNb);
        }

        [TestMethod]
        public void Should_Allow_To_Add_Row()
        {
            var obj = new Minesweeper(2, 5);
            obj.AddRow(".*");
            Assert.AreEqual(".*", obj.Current);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Should_Throw_Exception_When_Inputs_More_Than_Expected()
        {
            var obj = new Minesweeper(2, 5);
            obj.AddRow(".*.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Should_Throw_Exception_When_Inputs_Less_Than_Expected()
        {
            var obj = new Minesweeper(2, 5);
            obj.AddRow(".");
        }

        [TestMethod]
        public void Should_Find_One_Mine()
        {
            var obj = new Minesweeper(2, 1);
            obj.AddRow("*.");
            var result = obj.SolveField();
            Assert.AreEqual("*1", result);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Should_Throw_Exception_When_Field_Mismatch_Excepted()
        {
            var obj = new Minesweeper(2, 2);
            obj.AddRow("*.");
            var result = obj.SolveField();
        }

        [TestMethod]
        public void Should_Solve_With_Multiple_Rows()
        {
            var obj = new Minesweeper(3,3);
            obj.AddRow("*..");
            obj.AddRow(".*.");
            obj.AddRow(".*.");
            var result = obj.SolveField();
            Assert.AreEqual(@"*21
3*2
2*2", result);
        }

        [TestMethod]
        public void Should_Solve_With_Multiple_Fields()
        {
            var result = Minesweeper.Resolve(@"4 4
*...
....
.*..
....
3 5
**...
.....
.*...
0 0");
            Assert.AreEqual(@"Field #1:
*100
2210
1*10
1110
Field #2:
**100
33200
1*100", result);
        }

    }
}
