using System.Net.Http;

public interface IServiceClient
{
    HttpClient HttpClient { get; }
}
