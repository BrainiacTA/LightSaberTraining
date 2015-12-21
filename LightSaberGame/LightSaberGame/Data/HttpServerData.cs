namespace LightSaberGame.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Windows.Web.Http;
    using Model;
    public class HttpServerData : IData
    {
        public HttpServerData(string url)
        {
            this.Url = url;
        }

        public string Url { get; set; }

        public HeroModel AddHero(HeroModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HeroModel>> GetHeroes()
        {
            var client = new HttpClient();

            var endPointUrl = this.Url;
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(endPointUrl));
            client.DefaultRequestHeaders.Accept.Add(new Windows.Web.Http.Headers.HttpMediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendRequestAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<HeroGetResponse>(content);

            return result.Result;
        }

    }
}
