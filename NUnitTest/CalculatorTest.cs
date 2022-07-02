using ConsoleDependencyInjection;
using NUnit.Framework;
using System;

namespace NUnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void AddMethodTest()
        {
            // Arrange
            Calculator add = new Calculator();

            // Act
            int result = add.Add(15, 65);

            // Assert
            Assert.AreEqual(80, result);
        }

        [Test]
        [TestCase(15, 35, 50)]
        [TestCase(10, 45, 55)]
        [TestCase(20, 50, 70)]
        public void AddMethodTest(int num1, int num2, int expected)
        {
            // Arrange
            Calculator add = new Calculator();

            // Act
            int result = add.Add(num1, num2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(15, 5, 3)]
        [TestCase(10, 2, 5)]
        public void DivideMethodTest(int num1, int num2, int expected)
        {
            // Arrange
            Calculator add = new Calculator();

            // Act
            int result = add.Divide(num1, num2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(10, 0)]
        public void DivideMethodTest_Throw_Exception(int num1, int num2)
        {
            // Arrange
            Calculator add = new Calculator();

            // Act + Assert
            Assert.Throws<DivideByZeroException>(() => add.Divide(num1, num2));
        }
    }
}
