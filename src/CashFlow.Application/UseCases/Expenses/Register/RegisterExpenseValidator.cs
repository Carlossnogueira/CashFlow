using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson> 
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required");
            RuleFor(expense => expense.Amout).GreaterThan(0).WithMessage("The amount is required and must be greater than zero.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The date must be in the past.");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment Type is not valid.");
        }
    }
}
