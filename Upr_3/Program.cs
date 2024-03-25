using HtmlAgilityPack;
using System.Net;
using System.Text;


namespace Upr_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            MainAsync(args).Wait();
        }

        public static async Task MainAsync(string[] args)
        {
            //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Decimal format
            Console.OutputEncoding = Encoding.UTF8; // Cyrilic

            while (true)
            {
                //DisplayMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ExecuteWhois();
                        break;
                    case "2":
                        await ExecuteGetCurrentLocalTime();
                        break;
                    case "3":
                        await ExecuteScrapeNewsData();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private class NewsArticle
        {
            public string? Title { get; set; }
            public DateTime DateTime { get; set; }
        }

        static void DisplayMenu()
        {
            // Display menu options
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Whois");
            Console.WriteLine("2. Current Local Time");
            Console.WriteLine("3. Scrape data from a Website");
        }

        static void ExecuteWhois()
        {
            Console.Write("Enter an IP address: ");
            string? ip = Console.ReadLine();

            string countryCode = GetCountryCodeFromIP(ip);

            Console.WriteLine($"Country code: {countryCode}");
        }

        static string GetCountryCodeFromIP(string ip)
        {
            // Create HTTP request to retrieve country code from IP address
            HttpWebRequest? request = (HttpWebRequest)WebRequest.Create($"https://ipapi.co/{ip}/country/");
            request.UserAgent = "Mozilla/5.0";

            // Get HTTP response
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                // Read response and return country code
                return reader.ReadToEnd().Trim();
            }
        }

        static async Task ExecuteGetCurrentLocalTime()
        {
            // Get current local time in Sofia
            string dateTime = await GetCurrentLocalTime();

            // Display current local time
            Console.WriteLine($"Date and time in Sofia: {dateTime}");
        }

        static async Task<string> GetCurrentLocalTime()
        {
            // Create HTTP client
            using (HttpClient client = new HttpClient())
            {
                // Send request to get HTML content of time page
                string html = await client.GetStringAsync("https://www.timeanddate.com/worldclock/bulgaria/sofia");

                // Load HTML content into HtmlDocument
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // Extract time and date elements
                var timeElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='ct']");
                var dateElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@id='ctdat']");

                // Return formatted date and time
                return (timeElement != null && dateElement != null) ?
                    $"{dateElement.InnerText.Trim()}, {timeElement.InnerText.Trim()}" : "Unavailable";
            }
        }

        static async Task ExecuteScrapeNewsData()
        {
            // Scrape news data from website
            var newsArticles = await ScrapeNewsData();

            // Display scraped news articles
            foreach (var article in newsArticles)
            {
                Console.WriteLine($"Title: {article.Title}, Date and time: {article.DateTime:dd.MM.yyyy HH:mm}");
            }
        }

        static async Task<IEnumerable<NewsArticle>> ScrapeNewsData()
        {
            // Create HTTP client
            using (HttpClient client = new HttpClient())
            {
                // Send request to get HTML content of news website
                string html = await client.GetStringAsync("https://www.mediapool.bg/");

                // Load HTML content into HtmlDocument
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // Extract articles from HTML
                var articles = htmlDocument.DocumentNode.SelectNodes("//article");

                // Filter articles and extract relevant information
                var filteredArticles = articles?.Where(a =>
                    !a.InnerText.Contains("Covid-19") &&
                    !a.InnerText.Contains("корона вирус") &&
                    !a.InnerText.Contains("пандемия"))
                    .Select(article =>
                    {
                        var titleElement = article.SelectSingleNode(".//h3[@class='c-article-item__title']");
                        var dateTimeElement = article.SelectSingleNode(".//time[@class='c-article-item__date']");

                        return (titleElement != null && dateTimeElement != null) ?
                            new NewsArticle
                            {
                                Title = titleElement.InnerText.Trim(),
                                DateTime = DateTime.Parse(dateTimeElement.GetAttributeValue("datetime", ""))
                            } : null;
                    });

                // Remove null entries and return
                return filteredArticles?.Where(article => article != null);
            }
        }
    }


}
