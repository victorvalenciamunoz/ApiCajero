using ApiCajero.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCajero.Controllers;

[Route("api/cashier")]
[ApiController]
public class CashierController : ControllerBase
{
    private readonly IAccountService accountService;

    public CashierController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [Route("/fund")]
    [HttpPut]
    public ActionResult<decimal> Fund(string dni, string account, decimal amount)
    {
        var result = accountService.PutMoney(account,dni, amount);
        if (result.HasErrors)
        {
            return BadRequest(result.Errors[0]);
        }

        return Ok(result.Element);
    }
}
