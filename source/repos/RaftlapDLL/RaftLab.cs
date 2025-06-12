using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using RaftlapDLL.Models;

namespace RaftlapDLL
{
    public class RaftLab
    {
        private readonly HttpClient _httpClient;
        private IMemoryCache _cache;

        public RaftLab()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://reqres.in/api/");
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<User> getUserDetails(int UserId)
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");
            Singleuser result = new Singleuser();

            string cacheKey = "01" + UserId;

            try
            {
                if (_cache.TryGetValue<Singleuser>(cacheKey, out result))
                {
                    //Console.WriteLine("✅ Retrieved from cache.");
                }
                else
                {
                    HttpResponseMessage response = await _httpClient.GetAsync("users/" + UserId);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsondata = await response.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<Singleuser>(jsondata, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    }
                     

                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                    };

                    _cache.Set(cacheKey, result, cacheOptions);

                }

            }
            catch (Exception ex)
            {
                

            }

            return result?.data;
        }

        public async Task<List<User>> getUserPageDetails(int PageId)
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");

            string cacheKey = "02" + PageId;
            MultipleUsers result = new MultipleUsers();

            try
            {
                if (_cache.TryGetValue<MultipleUsers>(cacheKey, out result))
                {
                    //Console.WriteLine("✅ Retrieved from cache.");
                }
                else
                {
                    HttpResponseMessage response = await _httpClient.GetAsync("users?page=" + PageId);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsondata = await response.Content.ReadAsStringAsync();
                        result = JsonSerializer.Deserialize<MultipleUsers>(jsondata, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }

                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                    };

                    _cache.Set(cacheKey, result, cacheOptions);
                }

            }
            catch (Exception ex)
            {

            }

            return result?.data;
        }
    }
}
