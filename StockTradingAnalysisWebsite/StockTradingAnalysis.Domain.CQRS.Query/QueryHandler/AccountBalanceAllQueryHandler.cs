﻿using System.Collections.Generic;
using System.Linq;
using StockTradingAnalysis.Domain.CQRS.Query.Queries;
using StockTradingAnalysis.Interfaces.Domain;
using StockTradingAnalysis.Interfaces.Queries;
using StockTradingAnalysis.Interfaces.ReadModel;

namespace StockTradingAnalysis.Domain.CQRS.Query.QueryHandler
{
    public class AccountBalanceAllQueryHandler : IQueryHandler<AccountBalanceAllQuery, IEnumerable<IAccountBalance>>
    {
        private readonly IModelReaderRepository<IAccountBalance> _modelReaderRepository;

        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="modelReaderRepository">The model repository to read from</param>
        public AccountBalanceAllQueryHandler(IModelReaderRepository<IAccountBalance> modelReaderRepository)
        {
            _modelReaderRepository = modelReaderRepository;
        }

        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IEnumerable<IAccountBalance> Execute(AccountBalanceAllQuery query)
        {
            return _modelReaderRepository.GetAll().OrderByDescending(t => t.Date);
        }
    }
}