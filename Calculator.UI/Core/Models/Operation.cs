using System.ComponentModel.DataAnnotations;

namespace Calculator.UI.Core.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public string MathOperation { get; set; }
        public decimal Result { get; set; }
        public override string ToString()
        {
            return $"The operation {FirstNumber} {MathOperation} {SecondNumber} is equals to: {Result}";
        }
    }
}
