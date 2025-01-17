﻿using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class Response<TData>
{
    private readonly int _statusCode;

    public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        Message = message;
        _statusCode = code;
    }

    [JsonConstructor]
    public Response() => _statusCode = Configuration.DefaultStatusCode;

    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _statusCode is >= 200 and <= 299;
}
