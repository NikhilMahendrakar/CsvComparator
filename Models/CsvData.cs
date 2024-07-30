public class CsvData
{
    public List<string> Headers { get; set; }
    public List<Dictionary<string, string>> Rows { get; set; }

    public CsvData()
    {
        Headers = new List<string>();
        Rows = new List<Dictionary<string, string>>();
    }
}
