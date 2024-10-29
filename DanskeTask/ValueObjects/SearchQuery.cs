using static DanskeTask.QParser;

namespace DanskeTask.ValueObjects
{
    public class SearchQuery
    {
        public LogicalOperator Operator { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
}
