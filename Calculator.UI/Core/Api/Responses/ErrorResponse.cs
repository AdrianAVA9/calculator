﻿namespace Calculator.UI.Core.Api.Responses
{
    public class ErrorResponse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
    }
}
