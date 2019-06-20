using System;
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
            DateTime expectedDate = new DateTime(2018, 09, 01);
            string expectedString = "7-ELEVEN";
            decimal expectedDouble = 100;

            //Act
            Tuple<DateTime, string, decimal> actual = Program.DataSeparation(new string[] { "2018-09-01 7-ELEVEN 100" }, 0);

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
