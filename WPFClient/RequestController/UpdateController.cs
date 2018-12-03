using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.RequestController
{
    class UpdateController
    {
        public static async Task<bool> Update<T>(string name, T view)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55924/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync("api/" + name, view);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    return result;
                }
                throw new Exception("Fuck");
            }
        }
    }
}
