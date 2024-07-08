using Lib_DatabaseEntity.Repository;
using Lib_Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Project4_Net8_Api.Service
{
    public class MiddlewareAddAccessTokenInHeader
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MiddlewareAddAccessTokenInHeader(RequestDelegate next, IHttpContextAccessor httpContextAccessor,
                                                 IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var endpoint = context.GetEndpoint();
                if (endpoint?.Metadata.GetMetadata<AuthorizeAttribute>() != null)
                {
                    var accessToken = _httpContextAccessor.HttpContext!.Request.Cookies["accesstoken"];

                    if (accessToken == null)
                    {
                        SetUnauthorizedResponse(context, 401, "Null Access Token");
                        return;
                    }
                    try
                    {
                        context.Request.Headers["Authorization"] = "Bearer " + accessToken;
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                        SetUnauthorizedResponse(context, 500, ex.Message);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                SetUnauthorizedResponse(context, 500, ex.Message);
                return;
            }
            await _next(context);
        }

        // Hàm để thiết lập phản hồi cho trạng thái Unauthorized
        private void SetUnauthorizedResponse(HttpContext context, int statusCode, string errorMessage)
        {
            context.Response.StatusCode = statusCode; // Unauthorized

            //var errorResponse = new { error = errorMessage };
            //var json = JsonSerializer.Serialize(errorResponse);

            //context.Response.ContentType = "application/json";
            //context.Response.WriteAsync(json, Encoding.UTF8);
        }
    }
}
