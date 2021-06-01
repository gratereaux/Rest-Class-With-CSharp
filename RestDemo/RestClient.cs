using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestDemo
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }


    class RestClient
    {
        public string endPoint { get; set; }
        public string AccessToken { get; set; }

        public string data1 { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public RestClient()
        {
            endPoint = string.Empty;
            AccessToken = string.Empty;
            data1 = string.Empty;
        }

        public string MakeGet()
        {
            if (AccessToken.Length > 0)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            Task<string> t = client.GetStringAsync(endPoint);
            string result = t.Result;
            return result;
        }

        public string MakePost()
        {
            if (AccessToken.Length > 0)
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var parameters = new Dictionary<string, string>();
            parameters["data1"] = data1;

            var response = client.PostAsync(endPoint, new FormUrlEncodedContent(parameters)).Result;
            var contents = response.Content.ReadAsStringAsync().Result;

            return contents;
        }

        public string MakePut()
        {
            if (AccessToken.Length > 0)
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var parameters = new Dictionary<string, string>();
            parameters["data1"] = data1;

            var response = client.PutAsync(endPoint, new FormUrlEncodedContent(parameters)).Result;
            var contents = response.Content.ReadAsStringAsync().Result;

            return contents;
        }

        public string MakeDelete()
        {
            if (AccessToken.Length > 0)
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var parameters = new Dictionary<string, string>();
            parameters["data1"] = data1;

            var response = client.DeleteAsync(endPoint).Result;
            var contents = response.Content.ReadAsStringAsync().Result;

            return contents;
        }

    }
}
