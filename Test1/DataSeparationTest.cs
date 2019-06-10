using System;
using System.Collections.Generic;
using System.Text;
using Solution;
using Xunit;

namespace TestsForDataSeparation
{
    public class DataSeparationTest
    {
        [Fact]
        public void DataSeparation_PassingFictionalDataStrings()
        {
            //Arrange
            DateTime expectedDate = new DateTime(2018,09,16);
            string expectedString = "TELIA";
            double expectedDouble = 100;

            //Act
            Tuple<DateTime, string, double> actual = Program.DataSeparation("transactions.txt", 5);

            //Assert
            Assert.Equal(expectedDate, actual.Item1);
            Assert.Equal(expectedString, actual.Item2);
            Assert.Equal(expectedDouble, actual.Item3);

            //Test edge cases:
            /*
             * Right names misspelled.
             */
        }
    }
}
