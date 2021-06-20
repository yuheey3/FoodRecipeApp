using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeApp.Model
{
    public class Manager
    {
       

        private string url = "https://www.themealdb.com";
        private HttpClient client = new HttpClient();


        public async Task<List<Food>> GetFood(string fLetter)
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url + "/api/json/v1/1/search.php?f="+fLetter);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Food>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Food>>(array.ToString());

            }

        }

        public async Task<List<Category>> GetCategory()
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url + "/api/json/v1/1/categories.php");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Category>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Category>>(array.ToString());

            }

        }
    }
}
