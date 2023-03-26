namespace WordCounterApp;

public class MessageHandler
{
    
    public void ClearWindow()
    {
        Console.Clear();
    }
    
    public void Show(string message)
    {
        Console.Write(message);
    }
    
    public void ShowBanner()
    {
        Console.WriteLine(@" +-+-+-+-+  +-+-+-+-+-+-+-+  +-+-+-+-+
 |W|o|r|d|  |C|o|u|n|t|e|r|  |v|1|.|0|
 +-+-+-+-+  +-+-+-+-+-+-+-+  +-+-+-+-+");
    }
    
    public void ShowError(string code)
    {
        var inputError = @"Input error!";
        var urlError = @"Error! Please use the full name of the web address...
Example: https://www.example.com";
        
        var message = code == "input" ? inputError : urlError;
        Console.WriteLine(message);
    }
    
    public void ShowInput(string url)
    {
        Console.WriteLine($@"
You have chosen to scan: {url}");
        Console.WriteLine(@"Continue?

 [1] Yes
 [2] No

Exit:
 [0] Exit Program");
    }
    
    public void ShowOptions()
    {
        Console.WriteLine(@"
Show:
 [1] Top Words
 [2] All Unique Words
 [3] All Unique Words And Frequency (Descending Order)
 [4] All Words As Read

Save:
 [5] Save to file

Exit:
 [0] Exit Program");
    }
    
    public void ShowSaveOptions()
    {
        Console.WriteLine(@"
How do you wish to save the CSV-file?

Sort words:
 [1] By Frequency (Descending)
 [2] Alphabetically
 [3] Chronologically - As Scanned (No sorting and the same word may appear more than once)

Exit:
 [0] Don't Save and Exit Program");
    }
    
    public void ShowScanSuccessful()
    {
        Console.WriteLine();
        Console.WriteLine(@"Scan was Successful!");
    }
    
    // Printing to screen
    public void ShowTopWords(Dictionary<string, int> list)
    {
        var previewAmount = list.Count > 5 ? 5 : list.Count;
        var topResults = list.OrderByDescending(x => x.Value).Take(previewAmount);
        
        Console.WriteLine($"Showing Top {previewAmount} most used words: ");
        
        for (int i = 0; i < previewAmount; i++)
        {
            var item = topResults.ElementAt(i);
            Console.WriteLine($"{i+1}. \"{item.Key}\" : {item.Value}");
        }
    }
    
    public void ShowAllWords(Dictionary<string, int> list)
    {
        var previewAmount = list.Count;
        var topResults = list.OrderByDescending(x => x.Value).Take(previewAmount);
        
        Console.WriteLine($"Showing All Unique words ({previewAmount}): ");
        
        for (int i = 0; i < previewAmount; i++)
        {
            var item = topResults.ElementAt(i);
            Console.WriteLine($"{i+1}. \"{item.Key}\" ");
        }
    }
    
    public void ShowAllWordsAndFrequency(Dictionary<string, int> list)
    {
        var previewAmount = list.Count;
        var topResults = list.OrderByDescending(x => x.Value).Take(previewAmount);
        
        Console.WriteLine($"Showing All words ({previewAmount}): ");
        
        for (int i = 0; i < previewAmount; i++)
        {
            var item = topResults.ElementAt(i);
            Console.WriteLine($"{i+1}. \"{item.Key}\" : {item.Value}");
        }
    }
    
    public void ShowAllWordsAsRead(List<string> list)
    {
        var previewAmount = list.Count;
        
        Console.WriteLine($"Showing All Words As Read ({previewAmount}): ");

        foreach (var word in list)
        {
            Console.WriteLine(word);
        }
    }
    public void ShowWelcome()
    {
        Console.Write(@"
Find out how many words there are on a web page - and how often they are used.
- Write 'speedtest' to test algorithms,
- Write 'exit' or press <ctrl + c> to exit Program 

Enter the FULL URL of the web page you wish to scan: ");
    }
    
    // Performance Mode
    public void ShowPerformanceInfo()
    {
        Console.WriteLine(@"--- TESTING MODE ---

Test-data is generated as a List<string> containing 10 000 strings made from random lowercase letters (ASCII 97-122) 
consisting of 5 - 10 characters.
- How it's being done:
Calling Method(List<string>) in Sorting Class -> Stopwatch.Start() -> Algorithm -> Stopwatch.Stop() -> Console.WriteLine(Milliseconds)

Choose Algorithm:
 [1] Bubble-Sort
 [2] LinqSortByAlpha ( used in this program )
 [3] LinqSortByFreq ( used in this program )
 [4] Insertion-Sort
 [5] .NET Built-in .Sort()-algorithm

 [0] Exit Program...
");
    }
    
    public void PrintSample(List<string> sampleList)
    {
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(sampleList[i]);
        }
    }
}

