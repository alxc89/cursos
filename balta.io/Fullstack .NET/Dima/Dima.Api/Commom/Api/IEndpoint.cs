namespace Dima.Api.Commom.Api;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
