using WordCounterApp;

var input = new InputValidator();
var msg = new MessageHandler();
var saver = new FileHandler();
var scrape = new WebScraper();
var sort = new SortingHandler();
var strGen = new StringGenerator();

var words = new List<string>();

var startScan = false;
var goToSave = false;
var exitProgram = false;
var performanceMode = false;

while (!startScan)
{
    msg.ClearWindow();
    msg.ShowBanner();
    msg.ShowWelcome();
    
    var requestedUrl = Console.ReadLine().Trim();

    if (requestedUrl == "exit") Environment.Exit(0);

    // for testing purposes
    if (requestedUrl == "speedtest")
    {
        startScan = true;
        goToSave = true;
        exitProgram = true;
        performanceMode = true;

        break;
    }
    
    if (input.IsValidUrl(requestedUrl))
    {
        msg.ShowInput(requestedUrl);
    }
    else
    {
        msg.ShowError("url");
        
        msg.Show("Press any key to continue...");
        Console.ReadKey();
        continue;
    }
    
    var correct = Console.ReadKey(true);

    if (correct.Key == ConsoleKey.D0) Environment.Exit(0);
    
    startScan = correct.Key == ConsoleKey.D1;
    if (startScan)
    {
        words = scrape.GetContent(requestedUrl);
        if (words.Count < 5)
        {
            msg.ClearWindow();
            msg.Show("Scan was unsuccessful...");
            Console.ReadKey();
            return;
        }
    }
}

while (!goToSave)
{
    msg.ClearWindow();
    msg.ShowBanner();
    msg.ShowScanSuccessful();
    msg.ShowOptions();
    
    var choice = input.Options();
    msg.ClearWindow();
    msg.ShowBanner();
    // top words
    if (choice == 1)
    {
        var list = sort.GetAsDict(words);
        msg.ShowTopWords(list);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 

    // all unique
    if (choice == 2)
    {
        var list = sort.GetAsDict(words);
        msg.ShowAllWords(list);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
        
    } 

    // all unique and freq.
    if (choice == 3)
    {
        var list = sort.GetAsDict(words);
        msg.ShowAllWordsAndFrequency(list);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
        
    }
    
    if (choice == 4)
    {
        msg.ShowAllWordsAsRead(words);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    }

    // go to save procedure
    if (choice == 5) goToSave = true;

    if (choice == 0) Environment.Exit(0);
}

// Saving Procedure
while (!exitProgram)
{
    msg.ClearWindow();
    msg.ShowBanner();
    msg.ShowSaveOptions();
    
    var choice = input.Options();

    // Frequency: word,amount,word2,amount2
    if (choice == 1)
    {
        var sorted = sort.SortByFreq(words);
        saver.WriteToFile(sorted);
        exitProgram = true;
    } 

    // alphabetically: Aword,Aamount,Bword,Bamount
    if (choice == 2)
    {
        var sorted = sort.SortByAlpha(words);
        saver.WriteToFile(sorted);
        exitProgram = true;
        
    } 

    // Chron, as read.
    if (choice == 3)
    {
        saver.WriteToFile(words);
        exitProgram = true;
    } 
    
    if (choice == 0) Environment.Exit(0);
}

while (performanceMode)
{
    msg.ClearWindow();
    msg.ShowBanner();
    msg.ShowPerformanceInfo();

    var data = strGen.GenerateTestStrings(10000, 10);
    var choice = Console.ReadLine();
    
    // BubbleSort
    if (choice == "1")
    {
        msg.Show("Unsorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        sort.BubbleSort(data);
        msg.Show("Sorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 

    // SortByAlpha
    if (choice == "2")
    {
        msg.Show("Unsorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        var received = sort.LinqSortByAlpha(data);
        msg.Show("Sorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(received);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 

    // SortByFreq
    if (choice == "3")
    {
        msg.ClearWindow();
        msg.Show("Unsorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        var received = sort.LinqSortByFreq(data);
        msg.Show("Sorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(received);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 
    
    // InsertionSort
    if (choice == "4")
    {
        msg.ClearWindow();
        msg.Show("Unsorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        sort.InsertionSort(data);
        msg.Show("Sorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 
    
    // .NET Built-in .Sort()
    if (choice == "5")
    {
        msg.ClearWindow();
        msg.Show("Unsorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        sort.DotNetSort(data);
        msg.Show("Sorted sample of data: ");
        Console.WriteLine();
        msg.PrintSample(data);
        msg.Show("Press any key to continue...");
        Console.ReadKey();
    } 

    // Exit
    if (choice == "0")
    {
        performanceMode = false;
        return;
    }
}

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();