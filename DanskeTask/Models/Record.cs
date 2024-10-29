using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DanskeTask.Models
{
    //Can make with dictionary, then if we add new column we dont need to change code
    public class Record
    {
        [Name("signatureId")]
        public string SignatureId { get; set; }
        [Name("deviceVendor")]
        public string DeviceVendor { get; set; }
        [Name("deviceProduct")]
        public string DeviceProduct { get; set; }
        [Name("deviceVersion")]
        public string DeviceVersion { get; set; }
        [Name("severity")]
        public int Severity { get; set; }
        [Name("name")]
        public string Name { get; set; }
        [Name("start")]
        public string Start { get; set; }
        [Name("rt")]
        public string Rt { get; set; }
        [Name("msg")]
        public string Msg { get; set; }
        [Name("shost")]
        public string Shost { get; set; }
        [Name("smac")]
        public string Smac { get; set; }
        [Name("dhost")]
        public string Dhost { get; set; }
        [Name("dmac")]
        public string Dmac { get; set; }
        [Name("suser")]
        public string Suser { get; set; }
        [Name("suid")]
        public string Suid { get; set; }
        [Name("externalId")]
        public string ExternalId { get; set; }
        [Name("cs1Label")]
        public string Cs1Label { get; set; }
        [Name("cs1")]
        public string Cs1 { get; set; }
    }
}
