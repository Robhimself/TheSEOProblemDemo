using System.Diagnostics;

namespace WordCounterApp;

public class SortingHandler
{
    private readonly Stopwatch _timer = new Stopwatch();

    public Dictionary<string, int> GetAsDict(List<string> list)
    {
        Dictionary<string, int> dict = new();
        
        foreach (var str in list)
        {
            if (!dict.ContainsKey(str))
            {
                dict.Add(str, 1);
            }
            else
            {
                dict[str]++;
            }
        }
        return dict;
    }

    public List<string> SortByAlpha(List<string> list)
    {
        var dict = GetAsDict(list).OrderBy(x => x.Key);
        var output = dict.Select( x => x.Key + "," + x.Value ).ToList();
        
        return output;
    }

    public List<string> SortByFreq(List<string> list)
    {
        var dict = GetAsDict(list).OrderByDescending(x => x.Value);
        var output = dict.Select( x => x.Key + "," + x.Value ).ToList();
        
        return output;
    }

    // --- SPEEDTEST METHODS AND ALGORITHMS ---
    public void BubbleSort(List<string> list)
    {
        var n = list.Count;
	    
        _timer.Start();
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.CompareOrdinal(list[j], list[j+1]) > 0)
                {
                    (list[j], list[j+1]) = (list[j+1], list[j]);
                }
            }
        }
        _timer.Stop();
        Console.WriteLine(@"
Algorithm: Bubble sort
Time: {0}ms

", _timer.ElapsedMilliseconds);
        
        _timer.Reset();
    }


    public void DotNetSort(List<string> list)
    {
        _timer.Start();
        
        list.Sort();
        
        _timer.Stop();
        Console.WriteLine(@"
Algorithm: .NET Built-in .Sort()
Time: {0}ms

", _timer.ElapsedMilliseconds);
        
        _timer.Reset();
    }
    
    public void InsertionSort(List<string> list)
    {
        var n = list.Count;
        _timer.Start();

        for (int i = 1; i < n; i++)
        {
            string current = list[i];
            int j = i - 1;
            while (j > -1 && (string.CompareOrdinal(current, list[j]) < 0))
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = current;
        }
        _timer.Stop();
        Console.WriteLine(@"
Algorithm: Insertion sort
Time: {0}ms

", _timer.ElapsedMilliseconds);
        
        _timer.Reset();  
    }
    
    
    public List<string> LinqSortByAlpha(List<string> list)
    {
        _timer.Start();
        var dict = GetAsDict(list).OrderBy(x => x.Key);
        var output = dict.Select( x => x.Key + "," + x.Value ).ToList();
        
        _timer.Stop();
        Console.WriteLine(@"
Algorithm: LinqSortByAlpha
Time: {0}ms
", _timer.ElapsedMilliseconds);
        
        _timer.Reset();
        return output;
    }

    public List<string> LinqSortByFreq(List<string> list)
    {
        _timer.Start();
        var dict = GetAsDict(list).OrderByDescending(x => x.Value);
        var output = dict.Select( x => x.Key + "," + x.Value ).ToList();
        
        _timer.Stop();
        Console.WriteLine(@"
Algorithm: LinqSortByFreq
Time: {0}ms
", _timer.ElapsedMilliseconds);
        
        _timer.Reset();
        return output;
    }
    
    // public void ForLoop(List<string> list){}
    
    // public void TwoPointer(List<string> list){}
}