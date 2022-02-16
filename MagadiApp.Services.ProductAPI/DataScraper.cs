using HtmlAgilityPack;
using MagadiApp.Services.ProductAPI.DbContexts.Models;

namespace MagadiApp.Services.ProductAPI
{
    public static class DataScraper
    {
        private const string BaseUrl = "https://studiourodymagadi.pl/cennik/";

        public static IEnumerable<Category> GetCategory()
        {

            var tableRows = getTableRows(".cennik-box > .offer-title2");

            foreach (var row in tableRows)
            {
               yield return new Category()
                {
                    Name = row.InnerText.Replace("&nbsp;", " ").ToUpper().Trim(),
                };
            }
        }

        public static IEnumerable<Product> GetProducts() 
        {
            var tableRows = getTableRows(".cennik-box > .p3");

            foreach (var row in tableRows)
            {
                var spans = row.QuerySelectorAll("span");
                   
                // Get Name
                var endOfNamePosition = spans[0].InnerText.IndexOf("\n");
                var productName = (endOfNamePosition == -1) ? spans[0].InnerText.ToUpper().Trim() : spans[0].InnerText.Substring(0, endOfNamePosition).ToUpper().Trim();

                // Get description
                var description = default(string);
                if(endOfNamePosition == -1)
                {
                    description = null;
                }
                else
                {
                    description = spans[0].InnerText.Substring(endOfNamePosition).ToUpper().Trim();
                }


                // Get price
                var endOfPricePosition = spans[1].InnerText.IndexOf("PLN") - 1;
                var price = spans[1].InnerText.Substring(0, endOfPricePosition).Trim();
                var productPrice = refactorPrice(price);


                yield return new Product()
                {
                    Name = productName,
                    Price = productPrice,
                    Description = description,
                };
            }
        }

        private static double refactorPrice(string price)
        {
            var priceInDouble = default(double);
            if (price.Contains("-"))
            {
                var arrayOfPrices = price.Split('-');
                priceInDouble = calAvg(arrayOfPrices);
            }
            else if (price.Contains("/"))
            {
                var arrayOfPrices = price.Split("/");
                priceInDouble = double.Parse(arrayOfPrices[0]);
            }
            else
            {
                priceInDouble = double.Parse(price);
            }

            return priceInDouble;
        }

        private static double calAvg(string[] arrayOfPrices)
        {
            return (double.Parse(arrayOfPrices[0]) + double.Parse(arrayOfPrices[1])) / arrayOfPrices.Length;
        }

        private static IList<HtmlNode> getTableRows(string cssSelectorsNames)
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);

            var tableRows = document.QuerySelectorAll(cssSelectorsNames);

            return tableRows;
        }
    }
}
