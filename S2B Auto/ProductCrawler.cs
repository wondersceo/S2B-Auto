using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace S2B_Auto
{
    public class ProductCrawler
    {
        private readonly HttpClient _httpClient;

        public ProductCrawler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ProductInfo> GetProductInfoAsync(string url)
        {
            try
            {
                var html = await _httpClient.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var productInfo = new ProductInfo();

                if (url.Contains("ownerclan"))
                {
                    await ParseOwnerClanAsync(doc, productInfo);
                }
                else if (url.Contains("domemedb"))
                {
                    await ParseDomemeAsync(doc, productInfo);
                }
                else
                {
                    throw new ArgumentException("지원하지 않는 도매사이트입니다.");
                }

                return productInfo;
            }
            catch (Exception ex)
            {
                throw new Exception($"상품 정보 크롤링 중 오류: {ex.Message}");
            }
        }

        private Task ParseOwnerClanAsync(HtmlAgilityPack.HtmlDocument doc, ProductInfo productInfo)
        {
            try
            {
                // 물품명
                var nameNode = doc.DocumentNode.SelectSingleNode("//h3[@class='product-title']");
                productInfo.ProductName = nameNode?.InnerText.Trim() ?? "";

                // 가격
                var priceNode = doc.DocumentNode.SelectSingleNode("//div[@class='product-price']//span[@class='price']");
                if (priceNode != null)
                {
                    string priceText = priceNode.InnerText.Replace("원", "").Replace(",", "").Trim();
                    if (int.TryParse(priceText, out int price))
                    {
                        productInfo.Price = price.ToString();
                    }
                }

                // 상품 이미지 URL
                var imageNode = doc.DocumentNode.SelectSingleNode("//div[@class='product-image']//img");
                productInfo.MainImagePath = imageNode?.GetAttributeValue("src", "") ?? "";

                // 제조사
                var manufacturerNode = doc.DocumentNode.SelectSingleNode("//td[contains(text(),'제조사')]/following-sibling::td");
                productInfo.Manufacturer = manufacturerNode?.InnerText.Trim() ?? "";

                // 모델명
                var modelNode = doc.DocumentNode.SelectSingleNode("//td[contains(text(),'모델명')]/following-sibling::td");
                productInfo.ModelName = modelNode?.InnerText.Trim() ?? "";

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception($"오너클랜 파싱 중 오류: {ex.Message}");
            }
        }

        private Task ParseDomemeAsync(HtmlAgilityPack.HtmlDocument doc, ProductInfo productInfo)
        {
            try
            {
                // 물품명
                var nameNode = doc.DocumentNode.SelectSingleNode("//div[@class='title']");
                productInfo.ProductName = nameNode?.InnerText.Trim() ?? "";

                // 가격
                var priceNode = doc.DocumentNode.SelectSingleNode("//div[@class='price']//strong");
                if (priceNode != null)
                {
                    string priceText = priceNode.InnerText.Replace("원", "").Replace(",", "").Trim();
                    if (int.TryParse(priceText, out int price))
                    {
                        productInfo.Price = price.ToString();
                    }
                }

                // 상품 이미지 URL
                var imageNode = doc.DocumentNode.SelectSingleNode("//div[@class='product-image']//img");
                productInfo.MainImagePath = imageNode?.GetAttributeValue("src", "") ?? "";

                // 제조사
                var manufacturerNode = doc.DocumentNode.SelectSingleNode("//th[contains(text(),'제조사')]/following-sibling::td");
                productInfo.Manufacturer = manufacturerNode?.InnerText.Trim() ?? "";

                // 모델명
                var modelNode = doc.DocumentNode.SelectSingleNode("//th[contains(text(),'모델명')]/following-sibling::td");
                productInfo.ModelName = modelNode?.InnerText.Trim() ?? "";

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception($"도매매 파싱 중 오류: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}