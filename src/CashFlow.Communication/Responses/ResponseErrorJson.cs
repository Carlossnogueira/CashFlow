namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{

    public /*required*/ List<string> ErrorMessages { get; set; }

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = new List<string> { errorMessage };
        /*or ErrorMessages = [errorMessage]; */
    }

    public ResponseErrorJson(List<String> errorMessages) 
    { 
        this.ErrorMessages = errorMessages;
    }

    
}
