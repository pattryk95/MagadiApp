using HtmlAgilityPack;
using MagadiApp.Services.ProductAPI.DbContexts.Models;

namespace MagadiApp.Services.ProductAPI
{
    public static class DataScraper
    {
        private const string BaseUrl = "https://studiourodymagadi.pl/cennik/";

        public static IEnumerable<Category> GetCategory()
        {

            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);

            var tableRows = document.QuerySelectorAll(".cennik-box > .offer-title2");

            foreach (var row in tableRows)
            {
               yield return new Category()
                {
                    Name = row.InnerText.Replace("&nbsp;", " ").ToUpper().Trim(),
                };
            }
        }
    }
}
