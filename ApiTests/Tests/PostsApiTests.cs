
using Xunit;
using FluentAssertions;
using ApiTests.Clients;
using ApiTests.DTOs;

namespace ApiTests.Tests;

public class PostsApiTests

{
    private readonly PostsClient _client = new();

    [Fact]
    public void Get_Post_Should_Return_200()
    {
        var response = _client.GetPost(1);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public void Create_Post_Should_Return_201()
    {
        var response = _client.CreatePost(new { title = "test", body = "body", userId = 1 });
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

    [Fact]
    public void Delete_Post_Should_Return_200()
    {
        var response = _client.DeletePost(1);
        response.IsSuccessful.Should().BeTrue();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(99999)]
    public void Get_Invalid_Post_Should_Not_Be_200(int id)
    {
        var response = _client.GetPost(id);
        response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.OK);
    }
}
