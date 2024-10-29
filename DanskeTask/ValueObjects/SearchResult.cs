using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeTask.Models;

namespace DanskeTask.Dto
{
    public class SearchResult
    {
        public string SearchQuery { get; set; }
        public int Count { get; set; }
        public Record[] Results { get; set; }
    }
}
