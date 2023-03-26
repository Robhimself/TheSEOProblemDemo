namespace WordCounterApp;

public class StringGenerator
{
    private readonly List<string> _tests = new();
    public List<string> GenerateTestStrings(int numStrings, int maxLength)
    {
        var strings = new List<string>();
        var random = new Random();

        for (var i = 0; i < numStrings; i++)
        {
            var length = random.Next(5, maxLength + 1);
            var chars = new char[length];

            for (var j = 0; j < length; j++)
            {
                var charCode = random.Next(97, 123);
                chars[j] = (char)charCode;
            }
            var randomString = new string(chars);
            strings.Add(randomString);
        }
        return strings;
    }
    
}