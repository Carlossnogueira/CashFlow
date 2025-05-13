namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public ResponseErrorJson(string error)
    {
        ErrorMessage = error;
    }

    public /*required*/ string ErrorMessage {get;set;} = string.Empty;
}
