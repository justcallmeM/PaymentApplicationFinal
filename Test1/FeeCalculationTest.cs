using System;
using System.Collections.Generic;
using System.Text;
using Solution;
using Xunit;

namespace TestsForFeeCalculation
{
    public class FeeCalculationTest
    {
        [Fact]
        public void CalculatingFee_ExpectedActual()
        {
            //Arrange
            double expected = 31;

            //Act
            double actual = Program.FeeCalculation(200, 29);

            //Assert
            Assert.Equal(expected, actual);

            //Test edge cases:
            /*
             * Max value
             * Wacky values: -15 or even a different data type...
             */
        }
    }
}
