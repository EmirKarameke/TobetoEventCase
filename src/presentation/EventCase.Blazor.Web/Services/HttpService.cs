using EventCase.Application.Contract.ServiceTypes;
using Newtonsoft.Json;

namespace EventCase.Blazor.Web.Services;

public interface IHttpService
{
    Task<ServiceResponse<T>> GetListAsync<T>(ServiceRequestBase request);
    Task<ServiceResponse<T>> GetAsync<T>(ServiceRequestBase request);
    Task<ServiceResponse<T>> PostAsync<T>(ServiceRequestBase request);
    Task<ServiceResponse<T>> PutAsync<T>(ServiceRequestBase request);
    Task<ServiceResponse<T>> DeleteAsync<T>(ServiceRequestBase request);
}

public class HttpService : IHttpService
{
    HttpClient client;

    public HttpService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ServiceResponse<T>> DeleteAsync<T>(ServiceRequestBase request)
    {
        try
        {
            var response = await client.DeleteAsync(request.Url);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseContent);
            return result;
        }
        catch (Exception e)
        {

            throw;
        }
    }

    public async Task<ServiceResponse<T>> GetAsync<T>(ServiceRequestBase request)
    {
        try
        {
            var response = await client.GetAsync(request.Url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseContent);
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ServiceResponse<T>> GetListAsync<T>(ServiceRequestBase request)
    {
        try
        {
            var response = await client.GetAsync(request.Url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseContent);
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    public async Task<ServiceResponse<T>> PostAsync<T>(ServiceRequestBase request)
    {
        try
        {
            var response = await client.PostAsync(request.Url, request.Object);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseContent);
            return result;
        }
        catch (Exception e)
        {

            throw;
        }

    }

    public async Task<ServiceResponse<T>> PutAsync<T>(ServiceRequestBase request)
    {
        try
        {
            var response = await client.PutAsync(request.Url, request.Object);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<T>>(responseContent);
            return result;
        }
        catch (Exception e)
        {

            throw;
        }
    }
}