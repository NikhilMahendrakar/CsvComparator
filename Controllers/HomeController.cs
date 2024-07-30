using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CsvComparator.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvComparator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompareCsv(IFormFile file1, IFormFile file2)
        {
            if (file1 == null || file2 == null)
            {
                ModelState.AddModelError("", "Please upload both CSV files.");
                return View("Index");
            }

            var csvData1 = ParseCsv(file1);
            var csvData2 = ParseCsv(file2);

            var discrepancyReport = CompareCsvData(csvData1, csvData2);

            return View("Report", discrepancyReport);
        }

        private CsvData ParseCsv(IFormFile file)
        {
            var csvData = new CsvData();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var headers = reader.ReadLine().Split(',').ToList();
                csvData.Headers = headers;

                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine().Split(',');
                    var rowDict = new Dictionary<string, string>();
                    for (int i = 0; i < headers.Count; i++)
                    {
                        rowDict[headers[i]] = row[i];
                    }
                    csvData.Rows.Add(rowDict);
                }
            }
            return csvData;
        }

        private DiscrepancyReport CompareCsvData(CsvData csvData1, CsvData csvData2)
        {
            var report = new DiscrepancyReport();

            var rows1 = csvData1.Rows.Select(row => string.Join(",", row.Values)).ToList();
            var rows2 = csvData2.Rows.Select(row => string.Join(",", row.Values)).ToList();

            report.MissingRows = rows1.Except(rows2).ToList();
            report.MissingRows.AddRange(rows2.Except(rows1).ToList());

            report.MissingColumns = csvData1.Headers.Except(csvData2.Headers).ToList();
            report.MissingColumns.AddRange(csvData2.Headers.Except(csvData1.Headers).ToList());

            return report;
        }
    }
}
