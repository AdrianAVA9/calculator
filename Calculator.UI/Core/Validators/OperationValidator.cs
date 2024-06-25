using System.ComponentModel.DataAnnotations;

namespace Calculator.UI.Core.Validators
{
    public class OperationValidator
    {
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int FirstNumber { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int SecondNumber { get; set; }

        [Required]
        [RegularExpression("[-+x/]", ErrorMessage = "Invalid operation")]
        public string? Operation { get; set; }
    }
}
