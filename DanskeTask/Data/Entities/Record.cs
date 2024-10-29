using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeTask.Data.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public int SearchResultId { get; set; }
        public string SignatureId { get; set; }
        public string DeviceVendor { get; set; }
        public string DeviceProduct { get; set; }
        public string DeviceVersion { get; set; }
        public int Severity { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Rt { get; set; }
        public string Msg { get; set; }
        public string Shost { get; set; }
        public string Smac { get; set; }
        public string Dhost { get; set; }
        public string Dmac { get; set; }
        public string Suser { get; set; }
        public string Suid { get; set; }
        public string ExternalId { get; set; }
        public string Ss1Label { get; set; }
        public string Cs1 { get; set; }

        public SearchResult SearchResult { get; set; }
    }
}
