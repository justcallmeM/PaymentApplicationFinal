using System;
using System.Collections.Generic;
using System.Text;
using Solution;
using Xunit;

namespace TestsForDiscountProcesses
{
    public class DiscountProcessTest
    {
        [Fact]
        public void DiscountProcess_PassingCustomPercentages()
        {
            //Arrange
            double expected = 162; //180 - 18 (because 10% for TELIA)

            //Act
            double actual = Program.DiscountProcess("TELIA", 180);

            //Assert
            Assert.Equal(expected, actual);

            //Test edge cases:
            /*
             * Max values?
             */
        }
    }
}
