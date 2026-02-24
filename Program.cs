namespace Reading_OGE_Data;

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
        CSVReadWriter CSVRW = new CSVReadWriter();
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
}