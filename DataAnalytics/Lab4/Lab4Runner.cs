using System.Text.RegularExpressions;

namespace DataAnalytics.Lab4;

public static class Lab4Runner
{
    private const string _rootsite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";

    public static void Run()
    {
        var dictionary = new Dictionary<string, string>();
        CrawlUrlRecursive(_rootsite + "index.html", dictionary);

        foreach (var record in dictionary)
        {
            Console.WriteLine($"{record.Key.PadRight(20, ' ')}{record.Value}");
        }
    }

    private static void CrawlUrlRecursive(string currentUrl, Dictionary<string, string> dictionary)
    {
        if (dictionary.ContainsValue(currentUrl))
            return;

        var html = GetRootPageHtml(currentUrl);

        var title = Regex.Match(html, @"<title>(?<Title>.+)</title>").Groups["Title"].Value;
        dictionary.Add(title, currentUrl);

        var pageUrls = Regex.Matches(html, @"<a\s.*href=['""](?<Url>[^'""<>:#]*)['""]>.*<\/a>") // Regex will not return an href that contains the ':' character (filter out http links)
                .Select(match => _rootsite + match.Groups["Url"].Value)
                .Where(href =>
                {
                    if (href.EndsWith(".pdf") || href.EndsWith(".png")) // Filter out PDF and PNG documents
                        return false;

                    else if (href.Contains('#')) // Filter out links where the URL contains an ID to auto scroll to - Page has already been downloaded.
                        return false;

                    return true;
                }).ToList();

        foreach (var pageUrl in pageUrls)
        {
            CrawlUrlRecursive(pageUrl, dictionary);
        }
    }

    private static string GetRootPageHtml(string url)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        using (var response = client.Send(request))
        using (var stream = response.Content.ReadAsStream())
        using (var reader = new StreamReader(stream))
        {
            var html = reader.ReadToEnd();
            return html;
        }
    }
}