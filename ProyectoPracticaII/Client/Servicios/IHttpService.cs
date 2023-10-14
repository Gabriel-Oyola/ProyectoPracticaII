namespace ProyectoPracticaII.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRepuesta<T>> Get<T>(string url);
        Task<HttpRepuesta<object>> Post<T>(string url, T enviar);
        Task<HttpRepuesta<object>> Put<T>(string url, T enviar);
    }
}