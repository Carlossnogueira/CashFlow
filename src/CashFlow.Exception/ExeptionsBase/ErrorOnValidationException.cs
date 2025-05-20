namespace CashFlow.Exception.ExeptionsBase
{
    public class ErrorOnValidationException : CashFlowException
    {
        public List<string> Errors { get; set; }

        public ErrorOnValidationException(List<string> errorMessages)
        { 
            this.Errors = errorMessages;
        }
        
    }
}
