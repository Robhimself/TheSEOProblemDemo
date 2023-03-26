namespace WordCounterApp;

public class FileHandler
{
    public void WriteToFile(List<string> stringList)
    {
        try
        {
            var path = "output.csv";
            if (File.Exists(path))
            {
                var extension = Path.GetExtension(path);
                var fileName = Path.GetFileNameWithoutExtension(path);
                var newFileName = fileName + "_" + GenerateRandomString(5) + extension;
                var newFilePath = Path.Combine(Path.GetDirectoryName(path), newFileName);

                path = newFileName;
            }
            
            using var writer = new StreamWriter(path);
            for (var i = 0; i < stringList.Count; i++)
            {
                if (i == stringList.Count-1)
                {
                    writer.WriteLine(stringList[i]);
                }
                else
                {
                    stringList[i] += ",";
                    writer.WriteLine(stringList[i]);
                }
            }

            Console.WriteLine($"{path} has been created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}