using ApiCajero.IntegrationModels;
using ApiCajero.Models;

namespace ApiCajero.Services
{
    public interface IPersonService
    {
        ServiceResultSingleElement<Person> Get(int id);
        ServiceResultSingleElement<Person> Get(string Dni);
    }
}