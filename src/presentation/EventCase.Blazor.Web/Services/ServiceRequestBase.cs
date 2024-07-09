namespace EventCase.Blazor.Web.Services
{
    public class ServiceRequestBase
    {
        public string Url { get; set; } = "https://localhost:7274/";
        public HttpContent? Object { get; set; }
    }
}
