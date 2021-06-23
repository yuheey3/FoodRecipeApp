using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace FoodRecipeApp.Model
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class Manager
    {


        private string url = "https://www.themealdb.com";
        private HttpClient client = new HttpClient();

        public object Navigation { get; private set; }


        //search by name
        public async Task<List<Food>> GetFoodByName(string fName)
        {
        

            var response = await client.GetAsync(url + "/api/json/v1/1/search.php?s=" + fName);
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

        //search by first letter
        public async Task<List<Food>> GetFood(string fLetter)
        {
          

            var response = await client.GetAsync(url + "/api/json/v1/1/search.php?f=" + fLetter);
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

        //all category
        public async Task<List<Category>> GetCategory()
        {
        

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

        //search by category
        public async Task<List<Category2>> SearchByCategory(string category)
        {
        

            var response = await client.GetAsync(url + "/api/json/v1/1/filter.php?c=" + category);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Category2>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Category2>>(array.ToString());

            }

        }


       


        
    }
}
