using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.Data.ViewModel;
using Lab9.Data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Lab9.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetController.GetAll().Wait();
            Console.ReadKey();
        }

        public static async Task Do()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55924/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Department");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Yes");
                    var result = await response.Content.ReadAsAsync<IEnumerable<DepartmentView>>();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.dname);
                    }
                }
            }
        }
    }

    public class GetController
    {
        private string _controllerName;

        public GetController(string controllerName)
        {
            _controllerName = controllerName;
        }

        public static async Task GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55924/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Department");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Yes");
                    var result = await response.Content.ReadAsAsync<IEnumerable<DepartmentView>>();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.dname);
                    }
                }
            }
        }
    }
}
