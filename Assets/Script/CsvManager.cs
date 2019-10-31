using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvManager
{
    public static CsvManager Instance
    {
        get
        {
            if (instance == null)
                instance = new CsvManager();
            return instance;
        }
    }

    private static CsvManager instance;
    private const string fileName = "\\Leaderboard.csv";
  
    public void CsvDelete(string path)
    {
        if (path == null)
            return;
        path += fileName;
        if (File.Exists(path))
            File.Delete(path);
    }

    public void CsvCreate(string path)
    {
        if (path == null)
            return;
        path += fileName;
        if (!File.Exists(path))
            File.CreateText(path);
    }

    public List<string[]> ReadCsv(string path)
    {
        List<string[]> list = new List<string[]>();     
        string line;
        StreamReader stream = Read(path);
        while ((line = stream.ReadLine()) != null)
        {
            list.Add(line.Split(','));
        }
        stream.Close();
        stream.Dispose();
        return list;
    }
    public void WriteCsv(string[] strs, string path)
    {
        StreamWriter stream = Write(path);
        for (int i = 0; i < 10; i++)
        {
            if (strs[i] != null)
                stream.WriteLine($"{(i + 1).ToString()},{strs[i]}");
        }
        stream.Close();
        stream.Dispose();
    }
    private StreamReader Read(string path)
    {
        if (path == null)
            return null;
        path += fileName;
        if (!File.Exists(path))
            File.CreateText(path);
        return new StreamReader(path);
    }

    private StreamWriter Write(string path)
    {
        if (path == null)
            return null;
        path += fileName;
        if (!File.Exists(path))
            File.CreateText(path);
        return new StreamWriter(path);
    }
}
