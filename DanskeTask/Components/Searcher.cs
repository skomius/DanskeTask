using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeTask.Dto;
using DanskeTask.Interface;
using DanskeTask.Models;
using DanskeTask.ValueObjects;

namespace DanskeTask.Components
{
    public class Searcher : ISearcher
    {
        private readonly IQParser _qParser;
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly ILogsCollection _logsCollection;
        private readonly ILogger _logger;

        public Searcher(IQParser qParser, IExpressionBuilder expressionBuilder, ILogsCollection logsCollection, ILogger logger)
        {
            _qParser = qParser ?? throw new ArgumentNullException(nameof(qParser));
            _expressionBuilder = expressionBuilder ?? throw new ArgumentNullException(nameof(expressionBuilder));
            _logsCollection = logsCollection ?? throw new ArgumentNullException(nameof(logsCollection));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public SearchResult? Search(string query)
        {
            var searchQuery = _qParser.QueryParser(query);

            if (searchQuery == null)
            {
                throw new InvalidOperationException("Query parsing failed");
            }

            foreach (var field in searchQuery.Fields)
            {
                if (typeof(Record).GetProperty(field.Property) == null)
                {
                    _logger.Log($"Column by name {field.Property} not found");
                    return null;
                }
            }

            Record[] results;

            var expression = _expressionBuilder.GetExpression<Record>(searchQuery);
            results = _logsCollection.LogsRecords.Where(expression).ToArray();

            return
                new SearchResult
                {
                    SearchQuery = query,
                    Count = results.Count(),
                    Results = results
                };
        }
    }
}
