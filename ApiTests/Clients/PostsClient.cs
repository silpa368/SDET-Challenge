
using RestSharp;
using ApiTests.Config;

namespace ApiTests.Clients;

public class PostsClient
{
    private readonly RestClient _client;

    public PostsClient()
    {
        _client = new RestClient(ApiSettings.BaseUrl);
    }

    public RestResponse GetPost(int id)
        => _client.Execute(new RestRequest($"/posts/{id}", Method.Get));

    public RestResponse CreatePost(object payload)
        => _client.Execute(new RestRequest("/posts", Method.Post).AddJsonBody(payload));

    public RestResponse UpdatePost(int id, object payload)
        => _client.Execute(new RestRequest($"/posts/{id}", Method.Put).AddJsonBody(payload));

    public RestResponse DeletePost(int id)
        => _client.Execute(new RestRequest($"/posts/{id}", Method.Delete));
}
