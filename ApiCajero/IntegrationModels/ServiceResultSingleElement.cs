namespace ApiCajero.IntegrationModels
{
    public class ServiceResultSingleElement<T> : ServiceResult
    {
        public T Element { get; set; }
    }

}
