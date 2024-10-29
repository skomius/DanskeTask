using DanskeTask.Dto;
using DanskeTask.ValueObjects;

namespace DanskeTask.Interface
{
    public interface ISearcher
    {
        public SearchResult? Search(string query);
    }
}
