using Core.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Rest
{
    public class RestService : IRestService
    {
        private readonly IConfiguration _configuration;
        public RestService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<BaseResponse<T>> Get<T>(string url)
        {
            try
            {
                using (var clint = new HttpClient())
                {
                    var uri = new Uri(_configuration["BaseUrl"]);
                    var response = await clint.GetAsync($"{uri}{url}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
                    }
                    return new BaseResponse<T>().Fail("Servise bağlanırken hata oluştu");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<T>().Fail(e.Message);
            }

        }

        public async Task<BaseResponse<T>> Post<T>(string url, object data)
        {
            try
            {
                using (var clint = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var uri = new Uri(_configuration["BaseUrl"]);
                    var response = await clint.PostAsync($"{uri}{url}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<BaseResponse<T>>(responseString);
                    }
                    return new BaseResponse<T>().Fail("Servise bağlanırken hata oluştu");
                }
            }
            catch (Exception e)
            {
                return new BaseResponse<T>().Fail(e.Message);
            }
        }
    }

}
