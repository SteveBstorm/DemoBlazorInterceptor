using Microsoft.JSInterop;

namespace DemoBlazorInterceptor.Client.Infrastructure
{
    public class TokenInterceptor : DelegatingHandler
    {
        private IJSRuntime _js;
        public TokenInterceptor(IJSRuntime js)
        {
            _js = js;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string token;
            token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("Authorization", "Bearer " + token);
            }
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
