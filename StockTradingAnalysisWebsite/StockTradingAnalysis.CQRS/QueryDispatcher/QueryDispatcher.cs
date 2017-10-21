﻿using StockTradingAnalysis.Core.Common;
using StockTradingAnalysis.CQRS.Exceptions;
using StockTradingAnalysis.Interfaces.Queries;
using StockTradingAnalysis.Interfaces.Services;

namespace StockTradingAnalysis.CQRS.QueryDispatcher
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IDependencyService _dependencyService;
        private readonly IPerformanceMeasurementService _performanceMeasurementService;

        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="dependencyService">The dependency service</param>
        /// <param name="performanceMeasurementService">The performance measurement service</param>
        public QueryDispatcher(
            IDependencyService dependencyService,
            IPerformanceMeasurementService performanceMeasurementService)
        {
            _dependencyService = dependencyService;
            _performanceMeasurementService = performanceMeasurementService;
        }

        /// <summary>
        /// Delegates the specified query to a <see cref="IQueryHandler{TQuery,TResult}" /> implementation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>The result generated by the <see cref="IQueryHandler{TQuery,TResult}" /></returns>
        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            using (new TimeMeasure(ms => _performanceMeasurementService.CountQuery(ms)))
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

                dynamic handler = _dependencyService.GetService(handlerType);

                if (handler == null)
                    throw new QueryDispatcherException(handlerType);

                return handler.Execute((dynamic)query);
            }
        }
    }
}