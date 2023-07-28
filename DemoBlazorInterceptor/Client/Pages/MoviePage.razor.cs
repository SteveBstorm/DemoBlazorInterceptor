using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DemoBlazorInterceptor.Client.Pages
{
    public partial class MoviePage
    {
        [Inject]
        public IHttpClientFactory Factory{ get; set; }
        private HttpClient _client;
        protected override async Task OnInitializedAsync()
        {
            _client = Factory.CreateClient("apiServer");
            using(HttpResponseMessage response = await _client.GetAsync("api/movie/500rror"))

            {
                Console.WriteLine(response.StatusCode.ToString());
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("toto");
                }
                //await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
