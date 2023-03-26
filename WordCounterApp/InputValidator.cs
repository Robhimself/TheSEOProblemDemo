namespace WordCounterApp;

public class InputValidator
{
    
    public bool IsValidUrl(string url)
    {
        var result = (Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
                      (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps));
        return result;
    }

    public int Options()
    {
        var userKey = Console.ReadKey(true);

        return userKey.Key switch
        {
            ConsoleKey.D1 => 1,
            ConsoleKey.D2 => 2,
            ConsoleKey.D3 => 3,
            ConsoleKey.D4 => 4,
            ConsoleKey.D5 => 5,
            ConsoleKey.D0 => 0,
            _ => 9
        };
    }
}