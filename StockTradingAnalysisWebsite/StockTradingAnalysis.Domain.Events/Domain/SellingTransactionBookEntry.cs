﻿using System;
using System.Diagnostics;
using StockTradingAnalysis.Interfaces.Domain;

namespace StockTradingAnalysis.Domain.Events.Domain
{
    [DebuggerDisplay("Sell {Shares} x {PricePerShare} on {OrderDate} of stock {StockId}")]
    public class SellingTransactionBookEntry : TransactionBookEntry, ISellingTransactionBookEntry
    {
        /// <summary>
        /// Gets the taxes paid
        /// </summary>
        public decimal Taxes { get; }

        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="stockId">The id of a stock</param>
        /// <param name="transactionId">The id of a transaction</param>
        /// <param name="orderDate">The orderdate</param>
        /// <param name="shares">The amount of shares</param>
        /// <param name="pricePerShare">The price per share</param>
        /// <param name="orderCosts">The order costs</param>
        /// <param name="taxes">Taxes paid</param>
        public SellingTransactionBookEntry(Guid stockId, Guid transactionId, DateTime orderDate, decimal shares, decimal pricePerShare, decimal orderCosts, decimal taxes)
            : base(stockId, transactionId, orderDate, shares, pricePerShare, orderCosts)
        {
            Taxes = taxes;
        }

        /// <summary>
        /// Creates a copy of this instance
        /// </summary>
        /// <returns>Copy of this instance</returns>
        public new ITransactionBookEntry Copy()
        {
            return new SellingTransactionBookEntry(StockId, TransactionId, OrderDate, Shares, PricePerShare, OrderCosts, Taxes);
        }
    }
}