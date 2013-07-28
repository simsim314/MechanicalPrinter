using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MatrixOperator;

namespace STLManagerTest
{
    [TestFixture]
    class TestMatrix
    {
        [Test]
        public void MatrixSimple()
        {
            // solving system of linear equations ... A * x = b
            Matrix A = Matrix.Parse("1 0\r\n1 1"); // \r\n is newline in textbox
            Matrix b = Matrix.Parse("-1\r\n-3");
            Matrix x = A.SolveWith(b);

            Assert.AreEqual(-1, x[0,0], "failed");
            Assert.AreEqual(-2, x[1,0], "failed");
        }
    }
}
