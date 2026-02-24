namespace Reading_OGE_Data;

using System;
using System.Collections.Generic;
using System.IO;

// IdentityReacord added by AI
public struct IdentityRecord
{
    public string DisplayName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string WorkEmail { get; set; }
    public string CloudLifecycleState { get; set; }
    public string IdentityId { get; set; }
    public string IsManager { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
    public string Uid { get; set; }
    public string AccessType { get; set; }
    public string AccessSourceName { get; set; }
    public string AccessDisplayName { get; set; }
    public string AccessDescription { get; set; }
}

class Program
{
    static void Main()
    {
        List<IdentityRecord> records = CSVReadWriter.Read(AppDomain.CurrentDomain.BaseDirectory + "\\FrancisTuttleIdentities.csv");

        Console.WriteLine($"Total records read: {records.Count}");
    }
}

static class CSVReadWriter
{
    public static List<IdentityRecord> Read(string path)
    {
        List<IdentityRecord> records = new();
        string? line;

        try
        {
            using StreamReader s = new StreamReader(path);

            _ = s.ReadLine();

            while ((line = s.ReadLine()) != null)
            {
                string[] fields = SplitCsvLine(line); // Add The method for this to work

                // IdentityReacord added by AI
                // Map CSV columns -> struct properties by index.
                // If your CSV columns are in a different order, adjust the indices below.
                IdentityRecord r = new IdentityRecord
                {
                    DisplayName = GetField(fields, 0), // Add GetField method later
                    FirstName = GetField(fields, 1), // Add GetField method later
                    LastName = GetField(fields, 2), // Add GetField method later
                    WorkEmail = GetField(fields, 3), // Add GetField method later
                    CloudLifecycleState = GetField(fields, 4), // Add GetField method later
                    IdentityId = GetField(fields, 5), // Add GetField method later
                    IsManager = GetField(fields, 6), // Add GetField method later
                    Department = GetField(fields, 7), // Add GetField method later
                    JobTitle = GetField(fields, 8), // Add GetField method later
                    Uid = GetField(fields, 9), // Add GetField method later
                    AccessType = GetField(fields, 10), // Add GetField method later
                    AccessSourceName = GetField(fields, 11), // Add GetField method later
                    AccessDisplayName = GetField(fields, 12), // Add GetField method later
                    AccessDescription = GetField(fields, 13), // Add GetField method later
                };

                records.Add(r);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return records;
    }

    private static string GetField(string[] fields, int index)
    {
        // Trim whitespace
        string value = fields[index].Trim();

        if (value.Length >= 2 && value.StartsWith(',') && value.EndsWith(','))
        {
            value = value.Substring(1, value.Length - 2);
        }

        return value;
    }

    private static string[] SplitCsvLine(string line)
    {
        List<string> fields = new();
        var current = new System.Text.StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == ',')
            {
                if (i + 1 < line.Length && line[i + 1] == ',')
                {
                    current.Append(',');
                    i++;
                }
            }
            else
            {
                current.Append(c);
            }
        }

        fields.Add(current.ToString());
        return fields.ToArray();
    }
}