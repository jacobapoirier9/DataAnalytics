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
            var currentHref = unvisitedHrefs[0];
            if (visitedHrefs.Contains(currentHref))
            {
                unvisitedHrefs.RemoveAt(0);
                continue;
            }

            var (title, hrefs) = ExtractPageContents(currentHref);

            visitedHrefs.Add(currentHref);
            dictionary.Add(title, currentHref);
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

    private static void RecursiveCrawl(string currentHref, Dictionary<string, string> dictionary)
    {
        if (dictionary.ContainsValue(currentHref))
            return;

        var (title, hrefs) = ExtractPageContents(currentHref);

        dictionary.Add(title, currentHref);
        foreach (var href in hrefs)
        {
            RecursiveCrawl(href, dictionary);
        }
    }

    private static (string title, List<string> hrefs) ExtractPageContents(string href)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, href);

        using (var response = client.Send(request))
        using (var stream = response.Content.ReadAsStream())
        using (var reader = new StreamReader(stream))
        {
            var html = reader.ReadToEnd();

            var title = Regex.Match(html, @"<title>(?<Title>.+)</title>").Groups["Title"].Value;
            var pageHrefs = Regex.Matches(html, @"<a\s.*href=['""](?<Href>[^'""<>:#]*)['""]>.*<\/a>") // Regex will not return an href that contains the ':' character (filter out http links)
                    .Select(match => _rootsite + match.Groups["Href"].Value)
                    .Where(href =>
                    {
                        if (href.EndsWith(".pdf") || href.EndsWith(".png")) // Filter out PDF and PNG documents
                            return false;

                        else if (href.Contains('#')) // Filter out links where the URL contains an ID to auto scroll to - Page has already been downloaded.
                            return false;

                        return true;
                    }).ToList();

            return (title, pageHrefs);
        }
    }
}