using DanskeTask.ValueObjects;

namespace DanskeTask.Interface
{
    public interface IExpressionBuilder
    {
        public Func<T, bool> GetExpression<T>(SearchQuery filters);
    }
}
