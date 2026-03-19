using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusinessLogiclayer.Requests;
using BusinessLogiclayer.Response;
using Newtonsoft.Json;

namespace BusinessLogiclayer
{
    public class Login
    {
        public async Task<UserInfo> GetLogin(string username1, string password1)
        {
            string apiUrl = "https://localhost:44355/api/auth/signin";
            UserInfo loginInfo =new UserInfo();
            using (HttpClient client = new HttpClient())
            {
                var data = new UserLogin
                {
                    Username = username1,
                    Password = password1,
                };

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    loginInfo = JsonConvert.DeserializeObject<UserInfo>(result);


                    return loginInfo;
                }

                return loginInfo;
            }
        }
    }
}

