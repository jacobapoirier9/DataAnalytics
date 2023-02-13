using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataAnalytics.Lab4;

public static class Lab4Runner
{
    private const string _rootsite = "http://citelms.net/Internships/Summer_2018/Fan_Site/";

    public static void RunListStrategy()
    {
        var dictionary = new Dictionary<string, string>();

        var unvisitedHrefs = new List<string>() { _rootsite + "index.html" };
        var visitedHrefs = new List<string>();

        while (unvisitedHrefs.Count > 0)
        {
            var currentUrl = unvisitedHrefs[0];
            if (visitedHrefs.Contains(currentUrl))
            {
                unvisitedHrefs.RemoveAt(0);
                continue;
            }

            var (title, hrefs) = ExtractPageContents(currentUrl);

            visitedHrefs.Add(currentUrl);
            dictionary.Add(title, currentUrl);
            unvisitedHrefs.AddRange(hrefs);
        }
        
        BeginOutputProcess(dictionary);
    }

    public static void RunRecursiveStrategy()
    {
        var dictionary = new Dictionary<string, string>();
        RecursiveCrawl(_rootsite + "index.html", dictionary);
        BeginOutputProcess(dictionary);
    }

    private static void BeginOutputProcess(Dictionary<string, string> dictionary)
    {
        foreach (var record in dictionary)
        {
            Console.WriteLine($"{record.Key.PadRight(20, ' ')}{record.Value}");
        }
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter search term >> ");
            var searchTerm = Console.ReadLine();

            if (string.IsNullOrEmpty(searchTerm))
                break;

            var searchResults = dictionary.Where(record => record.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (searchResults.Any())
            {
                foreach (var record in searchResults)
                {
                    Console.WriteLine($"{record.Key.PadRight(20, ' ')}{record.Value}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
            Console.WriteLine();
        }
    }

    private static void RecursiveCrawl(string currentUrl, Dictionary<string, string> dictionary)
    {
        if (dictionary.ContainsValue(currentUrl))
            return;

        var (title, hrefs) = ExtractPageContents(currentUrl);

        dictionary.Add(title, currentUrl);
        foreach (var href in hrefs)
        {
            RecursiveCrawl(href, dictionary);
        }
    }

    private static (string title, List<string> hrefs) ExtractPageContents(string currentUrl)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, currentUrl);

        using (var response = client.Send(request))
        using (var stream = response.Content.ReadAsStream())
        using (var reader = new StreamReader(stream))
        {
            var html = reader.ReadToEnd();

            var title = Regex.Match(html, @"<title>(?<Title>.+)</title>").Groups["Title"].Value;
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

            return (title, pageUrls);
        }
    }
}