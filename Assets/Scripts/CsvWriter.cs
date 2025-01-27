using System.IO;
using UnityEngine;

public class CsvWriter : MonoBehaviour
{
    // File name and path for the CSV
    private string filePath = "Test_CSV.csv";
    private string csvContent = "";

    void Start()
    {
        AddValue("raw confidence, filtered confidence, word, word recognized,");
        NextRow();
    }

    // Method to add values to the current row
    public void AddValue(string value)
    {
        if (!string.IsNullOrEmpty(csvContent) && csvContent[csvContent.Length - 1] != '\n')
        {
            csvContent += ",";
        }
        csvContent += value;
    }

    // Method to append a newline
    public void NextRow()
    {
        csvContent += "\n";
    }

    public void WriteCsv()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(csvContent);
        }

        Debug.Log($"CSV file created at: {filePath}");
    }
}
