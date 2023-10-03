using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoProject.Model;

namespace UmbracoProject.Controller;

public class SearchEngineController : UmbracoApiController
{
    // GET
    public List<SearchModel> GetContent(string? title)
    {

        string jsonString = @"[
           {
               ""userId"": 1,
               ""id"": 1,
               ""title"": ""sunt aut facere repellat provident occaecati excepturi optio reprehenderit"",
               ""body"": ""quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto""
           },
           {
               ""userId"": 1,
               ""id"": 2,
               ""title"": ""qui est esse"",
               ""body"": ""est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla""
           }
        ]";
        List<SearchModel> myModels = JsonConvert.DeserializeObject<List<SearchModel>>(jsonString);
        if (!string.IsNullOrEmpty(title) || title != null)
        {
            var response = myModels.Where(x =>
                x.Title.Trim().Contains(title.Trim()) || x.Body.Trim().Contains(title.Trim()));
            myModels = response.ToList();
        }

        var _response = myModels.ToList();




        return _response;
    }
}
