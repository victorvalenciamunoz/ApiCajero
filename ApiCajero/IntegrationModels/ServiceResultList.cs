namespace ApiCajero.IntegrationModels
{
    public class ServiceResultList<T> : ServiceResult
    {
        public List<T> Elements { get; set; }
    }
}
