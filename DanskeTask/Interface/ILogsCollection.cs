using DanskeTask.Models;

namespace DanskeTask.Interface
{
    public interface ILogsCollection
    {
        public List<Record> LogsRecords { get; set; }
    }
}
