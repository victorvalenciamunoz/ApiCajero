using ApiCajero.IntegrationModels;
using ApiCajero.Models;

namespace ApiCajero.Services;

public class AccountService : IAccountService
{
    private readonly IPersonService personService;
    
    private decimal maxIn = 3000;
    private decimal maxOut = 1000;
    private static List<Account> accounts = null;

    public AccountService(IPersonService personService)
    {
        if (accounts == null)
        {
            accounts = new List<Account>();
            accounts.Add(new Account { Id = 1, AccountNumber = "11111", PersonId = 1, Balance = 1000 });
            accounts.Add(new Account { Id = 2, AccountNumber = "22222", PersonId = 2, Balance = 2000 });
            accounts.Add(new Account { Id = 3, AccountNumber = "22222", PersonId = 3, Balance = 3000 });
        }
                
        this.personService = personService;
    }

    public ServiceResultSingleElement<decimal> PutMoney(string accountNumber, string dni, decimal amount)
    {
        ServiceResultSingleElement<decimal> result = new ServiceResultSingleElement<decimal>();
        if (amount > maxIn)
        {
            result.Errors.Add("The amount exceeds the limit");
            return result;
        }

        string validationResult = ValidateInput(dni, accountNumber, amount);
        if (!string.IsNullOrWhiteSpace(validationResult))
        {
            result.Errors.Add(validationResult);
            return result;
        }

        var account = accounts.Where(c => c.AccountNumber.Equals(accountNumber)).FirstOrDefault();
        account.Balance += amount;

        result.Element = account.Balance;
        return result;

    }

    private string ValidateInput(string dni, string accountNumber, decimal amount)
    {
        if (amount < 0)
            return "Amount must be greater than zero";

        var account = accounts.Where(c => c.AccountNumber.Equals(accountNumber)).FirstOrDefault();
        if (account == null)
            return "Account not found";

        var personResult = personService.Get(dni);
        if (personResult.HasErrors)
        {
            return personResult.Errors[0];
        }

        var personBd = personResult.Element;
        if (personBd == null)
        {
            return $"Person with document {dni} not found";
        }
        if (!personBd.Dni.Equals(dni))
        {
            return $"{dni} does not match with person document";
        }
        if (!account.Id.Equals(personBd.Id))
        {
            return $"{account} does not belongs to document {dni}";
        }
        return string.Empty;
    }
}
