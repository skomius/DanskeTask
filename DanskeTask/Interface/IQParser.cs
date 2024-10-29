using DanskeTask.ValueObjects;

namespace DanskeTask.Interface
{
    public interface IQParser 
    {
        public SearchQuery QueryParser(string query);
    }
}
