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

            // Extrair o nome do produto
            var productElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div/div[3]/div/div/div[2]/div/div[2]/div/div");
            var productName = productElement?.InnerText.Trim() ?? "Produto não encontrado";

            // Aqui você deveria encontrar o XPath correto para o preço do produto
            // Vamos supor que o preço está em um elemento diferente
            var priceElement = htmlDocument.DocumentNode.SelectSingleNode("/html/body/section/div[4]/div/div[3]/div/div/div[1]/div/div[1]/div/div/span");
            var priceText = priceElement?.InnerText.Trim();

            // Conversão do preço para decimal
            decimal price;
            if (!decimal.TryParse(priceText, out price))
            {
                // Caso não consiga encontrar ou converter o preço, define um valor padrão
                price = 0m;
            }

            return (productName, price);
        }
    }
}