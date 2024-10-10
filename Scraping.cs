using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Service
{
    public class ScrapingService
    {
        public async Task<(string ProductName, decimal Price)> GetProductFromSiteAsync(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var productElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div/div[3]/div/div/div[2]/div/div[2]/div/div");
            var productName = productElement?.InnerText.Trim() ?? "Produto não encontrado";

           
            var priceElement = htmlDocument.DocumentNode.SelectSingleNode("/html/body/section/div[4]/div/div[3]/div/div/div[1]/div/div[1]/div/div/span");
            var priceText = priceElement?.InnerText.Trim();

         
            decimal price;
            if (!decimal.TryParse(priceText, out price))
            {
             
                price = 0m;
            }

            return (productName, price);
        }
    }
}
