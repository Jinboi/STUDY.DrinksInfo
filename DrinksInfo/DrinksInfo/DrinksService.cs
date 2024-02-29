using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.Models;

namespace DrinksInfo
{
    internal class DrinksService
    {
        public void GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            List<Category> categories = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                categories = serialize.CategoriesList;
                TableVisualizationEngine.ShowTable(categories, "Categories Menu");


            }
        }
    }
}
