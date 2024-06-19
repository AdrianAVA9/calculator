using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.Models
{
    public class CalculatorTest
    {
        public UI.Models.Calculator Calculator { get; set; }
        public CalculatorTest()
        {
            Calculator = new UI.Models.Calculator();
        }

        [Fact]
        public void Add_TheNumbersAre4_ShouldReturn8()
        {
            var firstNumber = 4;
            var secondNumber = 4;
            var result = Calculator.Add(firstNumber, secondNumber);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_TheNumbersAre2And4_ShouldReturn2Negative()
        {
            var firstNumber = 2;
            var secondNumber = 4;
            var result = Calculator.Subtract(firstNumber, secondNumber);

            Assert.Equal(-2, result);
        }

        [Fact]
        public void Subtract_TheNumbersAre2NegativeAnd4_ShouldReturn2()
        {
            var firstNumber = -2;
            var secondNumber = 4;
            var result = Calculator.Subtract(firstNumber, secondNumber);

            Assert.Equal(-2, result);
        }

        [Fact]
        public void Multiply_TheNumbersAre10And3_ShouldReturn30()
        {
            var firstNumber = 10;
            var secondNumber = 3;
            var result = Calculator.Multiply(firstNumber, secondNumber);

            Assert.Equal(30, result);
        }

        [Fact]
        public void Divide_TheNumbersAre9And3_ShouldReturn3()
        {
            var firstNumber = 9;
            var secondNumber = 3;
            var result = Calculator.Divide(firstNumber, secondNumber);

            Assert.Equal(3, result);
        }

        [Fact]
        public void Divide_TheNumbersAre2And0_ShouldThrowArgumentException()
        {
            var firstNumber = 2;
            var secondNumber = 0;
            var exception = Record.Exception(() => Calculator.Divide(firstNumber, secondNumber));

            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void Divide_TheNumbersAre10And5_ShouldReturn2()
        {
            var firstNumber = 10;
            var secondNumber = 5;
            var result = Calculator.Divide(firstNumber, secondNumber);

            Assert.Equal(2, result);
        }
    }
}
