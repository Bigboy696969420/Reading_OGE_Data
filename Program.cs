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
    public bool CloudLifecycleState { get; set; }
    public string IdentityId { get; set; }
    public bool IsManager { get; set; }
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
        Console.WriteLine($"Total inactive records: {CSVReadWriter.CountInactive(records).Count()}");
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

            s.ReadLine();

            while ((line = s.ReadLine()) != null)
            {
                string[] fields = line.Split(',');

                // IdentityReacord added by AI
                // Map CSV columns -> struct properties by index.
                // If your CSV columns are in a different order, adjust the indices below.
                IdentityRecord r = new IdentityRecord
                {
                    DisplayName = fields[0],
                    FirstName = fields[1],
                    LastName = fields[2],
                    WorkEmail = fields[3],
                    CloudLifecycleState = (fields[4] == "active") ? true : false,
                    IdentityId = fields[5],
                    IsManager = (fields[6] == "TRUE") ? true : false,
                    Department = fields[7],
                    JobTitle = fields[8],
                    Uid = fields[9],
                    AccessType = fields[10],
                    AccessSourceName = fields[11],
                    AccessDisplayName = fields[12],
                    AccessDescription = fields[13],
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

    private static string GetField(ref string[] fields, int index)
    {
        if (fields.Length == 0) return string.Empty;

        string OfField = "";



        return OfField;
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

    public static List<IdentityRecord> CountInactive(List<IdentityRecord> records)
    {
        return records
        .Where(r => !r.CloudLifecycleState)
        .ToList();
    }
}