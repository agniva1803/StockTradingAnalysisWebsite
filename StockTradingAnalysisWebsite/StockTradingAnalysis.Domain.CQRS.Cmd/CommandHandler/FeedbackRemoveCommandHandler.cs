﻿using StockTradingAnalysis.Domain.CQRS.Cmd.Commands;
using StockTradingAnalysis.Domain.CQRS.Cmd.Exceptions;
using StockTradingAnalysis.Domain.Events.Aggregates;
using StockTradingAnalysis.Interfaces.Commands;
using StockTradingAnalysis.Interfaces.DomainContext;

namespace StockTradingAnalysis.Domain.CQRS.Cmd.CommandHandler
{
    public class FeedbackRemoveCommandHandler : ICommandHandler<FeedbackRemoveCommand>
    {
        private readonly IAggregateRepository<FeedbackAggregate> _repository;

        /// <summary>
        /// Initializes this object
        /// </summary>
        /// <param name="repository">The repository for the aggregate</param>
        public FeedbackRemoveCommandHandler(IAggregateRepository<FeedbackAggregate> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        /// <exception cref="DomainValidationException">Thrown if validation fails</exception>
        public void Execute(FeedbackRemoveCommand command)
        {
            var aggregate = _repository.GetById(command.AggregateId);
            aggregate.Remove();

            _repository.Save(aggregate, command.OriginalVersion);
        }
    }
}