﻿using System;
using System.Collections.Generic;
using System.Linq;
using StockTradingAnalysis.Domain.CQRS.Query.Queries;
using StockTradingAnalysis.Interfaces.Domain;
using StockTradingAnalysis.Interfaces.Queries;
using StockTradingAnalysis.Interfaces.ReadModel;

namespace StockTradingAnalysis.Domain.CQRS.Query.QueryHandler
{
    public class FeedbackNameSearchQueryHandler : IQueryHandler<FeedbackNameSearchQuery, IEnumerable<string>>
    {
        private readonly IModelReaderRepository<IFeedback> _modelReaderRepository;

        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="modelReaderRepository">The model repository to read from</param>
        public FeedbackNameSearchQueryHandler(IModelReaderRepository<IFeedback> modelReaderRepository)
        {
            _modelReaderRepository = modelReaderRepository;
        }

        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IEnumerable<string> Execute(FeedbackNameSearchQuery query)
        {
            var items = _modelReaderRepository.GetAll().Select(t => t.Name);

            if (!query.SearchTerm.Equals(" "))
                items = items.Where(i => i.StartsWith(query.SearchTerm, StringComparison.InvariantCultureIgnoreCase));

            return items.Select(i => i).Distinct();
        }
    }
}