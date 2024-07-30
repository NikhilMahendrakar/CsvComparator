namespace CsvComparator.Models
{
    public class DiscrepancyReport
    {
        public List<string> MissingRows { get; set; }
        public List<string> MissingColumns { get; set; }

        public DiscrepancyReport()
        {
            MissingRows = new List<string>();
            MissingColumns = new List<string>();
        }
    }
}
