﻿using System;
using StockTradingAnalysis.Interfaces.Events;

namespace StockTradingAnalysis.Domain.Events.Events
{
    public class StockNameChangedEvent : DomainEvent
    {
        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name { get; private set; }

        public StockNameChangedEvent(Guid id, Type aggregateType, string name)
            : base(id, aggregateType)
        {
            Name = name;
        }
    }
}