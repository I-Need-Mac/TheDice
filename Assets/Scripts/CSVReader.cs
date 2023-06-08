using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile;
    public char fieldSeparator = ',';

    public List<List<string>> csvData;

    private void Start()
    {
        ReadCSVFile();
    }

    private void ReadCSVFile()
    {
        csvData = new List<List<string>>();

        string[] lines = csvFile.text.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(fieldSeparator);
            List<string> rowData = new List<string>();

            for (int j = 0; j < fields.Length; j++)
            {
                rowData.Add(fields[j]);
            }
            csvData.Add(rowData);
        }
    }
}
