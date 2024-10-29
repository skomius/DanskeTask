using DanskeTask.Dto;
using DanskeTask.Interface;
using DanskeTask.Models;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using DanskeTask.Extentions;

namespace DanskeTask.Components
{
    public class FileImporter : IFileImporter
    {
        private readonly ILogsCollection _logsCollection;

        public FileImporter(ILogsCollection logsCollection)
        {
            _logsCollection = logsCollection ?? throw new ArgumentNullException(nameof(logsCollection));
        }

        public void ImportFile(IEnumerable<string> paths, int minSeverity = int.MaxValue)
        {
            foreach (var path in paths)
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Record>();
                        _logsCollection.LogsRecords.Add(record);

                        if (record.Severity <= minSeverity)
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(record, Formatting.Indented));
                        }
                    }
                }
            }

            _logsCollection.LogsRecords = _logsCollection.LogsRecords.Distinct(new RecordsComparer()).ToList();
        }
    }
}
