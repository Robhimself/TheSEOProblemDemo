using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WordCounterApp;

public class WebScraper
{
    private readonly List<string> _list = new();
    
    public List<string> GetContent(string html)
    {
        var web = new HtmlWeb();
        var htmlDoc = web.Load(html);
        var parsedText = htmlDoc.DocumentNode.OuterHtml;
        
        DecodeHtml(parsedText);
        
        return _list;
    }

    private void DecodeHtml(string html)
    {
        var subcriterionCritiqueDecode = WebUtility.HtmlDecode(html);
        var doc = new HtmlDocument { OptionFixNestedTags = false };
        
        doc.LoadHtml(subcriterionCritiqueDecode);
        
        var parsedText = doc.DocumentNode.InnerText;
        var cleanText = RemoveBadChars(parsedText);
        
        HtmlToList(cleanText);
    }

    private void HtmlToList(string str)
    {
        var splitString = str.Split(' ');
            
        foreach (var word in splitString)
        {
            var cleanWord = RemoveBadChars(word.ToLower());
            if (cleanWord == "" || cleanWord == " ") continue;
            
            _list.Add(cleanWord);
        }
    }

    private static string RemoveBadChars(string word)
    {
        var str = Regex.Replace(word, "[^a-zA-Z0-9'øæå]", " ", RegexOptions.Compiled);
        str = str.TrimStart('\'');
        str = str.TrimEnd('\'');
        return str;
    }
}