using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeTask.Data.Entities
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public int Count { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
