using System.Xml.Linq;

namespace indoeuropean.Services
{
    public class SitemapService
    {
        public void Generate(string baseUrl, List<string> urls, string filePath)
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

            var sitemap = new XElement(ns + "urlset",
                urls.Select(url => new XElement(ns + "url",
                    new XElement(ns + "loc", $"{baseUrl}/{url}".TrimEnd('/')),
                    new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                    new XElement(ns + "changefreq", "weekly"),
                    new XElement(ns + "priority", "0.8")
                ))
            );

            var doc = new XDocument(sitemap);

            var tempFile = filePath + ".tmp";
            doc.Save(tempFile);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Move(tempFile, filePath);
        }
    }
}
