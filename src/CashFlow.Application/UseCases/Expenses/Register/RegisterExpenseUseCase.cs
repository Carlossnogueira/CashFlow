using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
           
            Validate(request);
            return new ResponseRegisteredExpenseJson();
        }


        private void Validate(RequestRegisterExpenseJson request)
        {
            var tittleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if(tittleIsEmpty)
            {
                throw new ArgumentException("The title is required.");
            }

            if(request.Amout <= 0)
            {
                throw new ArgumentException("The amount is required and must be greater than zero.");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if(result > 0)
            {
                throw new ArgumentException("The date must be in the past.");
            }

            var PaymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
            if(PaymentTypeIsValid == false)
            {
                throw new ArgumentException("Payment Type is not valid.");
            }
        }
    }
}
