using ApiCajero.Services;

namespace ApiCajero.Test;

public class AccountServiceShould
{
    private readonly IAccountService accountService;
    
    [Fact]
    public void ReturnPersonNotFound()
    {
        AccountService accountService = new AccountService(new PersonService());
        var dni = "jjjjjj";
        var result = accountService.PutMoney("11111", dni, 12);
        Assert.Equal(result.Errors[0], $"Person not found");
    }
}