using System.Collections.Generic;
using System.IO;

public static class CsvManager
{
    public static void SaveToCSV(List<string> data, string filePath)
    {
        File.WriteAllLines(filePath, data);
    }

    public static List<string> LoadFromCSV(string filePath)
    {
        if (File.Exists(filePath))
        {
            return new List<string>(File.ReadAllLines(filePath));
        }
        else
        {
            return new List<string>();
        }
    }
}
