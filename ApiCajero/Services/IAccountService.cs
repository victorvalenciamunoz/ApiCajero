using ApiCajero.IntegrationModels;

namespace ApiCajero.Services
{
    public interface IAccountService
    {
        ServiceResultSingleElement<decimal> PutMoney(string accountNumber, string dni, decimal amount);
    }
}