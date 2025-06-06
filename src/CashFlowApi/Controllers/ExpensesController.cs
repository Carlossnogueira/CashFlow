﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExeptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public ActionResult Register([FromBody] RequestRegisterExpenseJson request) 
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Errors);
            
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("unknow error");
            
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
