namespace Calculator.UI.Models.Api
{
    public class ErrorResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
    }
}
