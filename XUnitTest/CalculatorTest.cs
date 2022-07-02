using ConsoleDependencyInjection;
using System;
using Xunit;

namespace XUnitTest
{
    public class CalculatorTest
    {
        [Fact]
        public void AddMethodTest()
        {
            // Arrange
            Calculator add = new Calculator();

            // Act
            int result = add.Add(15, 65);

            // Assert
            Assert.Equal(80, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 20, 30)]

        public void AddMethodTest_With_Parameter(int num1, int num2, int num3)
        {
            // Arrange
            Calculator add = new Calculator();

            // Act
            int result = add.Add(num1, num2);

            // Assert
            Assert.Equal(num3, result);
        }

        [Theory]
        [InlineData(10, 0)]
        public void DivideMethodTest_Throw_Exception(int num1, int num2)
        {
            // Arrange
            Calculator add = new Calculator();

            // Act + Assert
            Assert.Throws<DivideByZeroException>(() => add.Divide(num1, num2));
        }
    }
}