﻿using StockTradingAnalysis.Interfaces.Domain;
using StockTradingAnalysis.Interfaces.Queries;
using System.Collections.Generic;

namespace StockTradingAnalysis.Domain.CQRS.Query.Queries
{
    public class FeedbackProportionAllQuery : IQuery<IEnumerable<IFeedbackProportion>>
    {
    }
}