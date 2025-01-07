﻿using Dima.Api.Commom.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/", HandleAsync)
        .WithName("Categories: Get All")
        .WithSummary("Retorna todas as categorias de um usuário")
        .WithDescription("Retorna todas as categorias de um usuário")
        .WithOrder(5)
        .Produces<PagedResponse<List<Category>?>>();

    public static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICategoryHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}