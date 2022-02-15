using HtmlAgilityPack;
using MagadiApp.Services.ProductAPI.DbContexts.Models;

namespace MagadiApp.Services.ProductAPI
{
    public class DataScraper
    {
        private const string BaseUrl = "https://studiourodymagadi.pl/cennik/";

         public List<Category> categories { get; set; } = new List<Category>();


        public void GetData()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);

            // document.QuerySelectorAll(".cennik-box h2.offer-title2");
            var tableRows = document.QuerySelectorAll(".cennik-box h2, p");

         /*   
            foreach (var row in tableRows)
            {
                if (row.Attributes["class"].Value == "offer-title2")
                {
                    var cat = new Category { Name = row.InnerText };

                    categories.Add(cat);
                }
            }
           */ 
            
            var newTab = tableRows
                .Select((x, i) => new { Index = i, Value = x })
                .ToList();
            
        }

        private List<T> makeSeeds(IGrouping elements)
        {

        }

    }
}
