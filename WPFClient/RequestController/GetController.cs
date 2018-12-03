using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Lab9.Data.ViewModel;
using System.Windows;

namespace WPFClient.RequestController
{
    public class GetController
    {
        private string _controllerName;

        public GetController(string controllerName)
        {
            _controllerName = controllerName;
        }

        public static async Task<IEnumerable<T>> GetAll<T>(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55924/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/" + name);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<T>>();
                    return result;
                }
                throw new Exception("Fuck");
            }
        }
    }
}
