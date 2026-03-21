using BusinessLogiclayer.Requests;
using BusinessLogiclayer.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogiclayer
{
    public class StudentService
    {
        public async Task<bool> Register(Student data)
        {
            string apiUrl = "https://localhost:44355/api/student/create";
            using (HttpClient client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return  JsonConvert.DeserializeObject<bool>(result);
                }

                return false;
            }
        }
    }
}
