using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace DemoBlazorInterceptor.Client.Infrastructure
{
    public class HttpErrorHandler : DelegatingHandler
    {
        private readonly NavigationManager _nav;
        private readonly ILogger<HttpErrorHandler> _logger;

        public HttpErrorHandler(NavigationManager nav, ILogger<HttpErrorHandler> logger)
        {
            _nav = nav;
            _logger = logger;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            response = await base.SendAsync(request, cancellationToken);

            
            Console.WriteLine(response.StatusCode.ToString());

            if (CheckHttpError(response))
            {
                Console.WriteLine(response.StatusCode.ToString());
            }
            return await Task.FromResult(response);
        }

        private bool CheckHttpError(HttpResponseMessage response)
        {
            
            if(!response.IsSuccessStatusCode)
            {
                HttpStatusCode code = response.StatusCode;
                Console.WriteLine(code);
                switch (code)
                {
                    case HttpStatusCode.NotFound:
                        _nav.NavigateTo("/404");
                        _logger.LogError(HttpStatusCode.NotFound.ToString());
                        break;
                    case HttpStatusCode.InternalServerError:
                        _nav.NavigateTo("/500");
                        break;
                    default:
                        _nav.NavigateTo("/");
                        break;
                }
            }
            
            return true;
        }
    }
}
