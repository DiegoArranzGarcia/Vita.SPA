﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Goals.Commands;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Sql.Goals.Commands
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Guid>
    {
        private readonly IGoalsRepository _goalsRepository;

        public CreateGoalCommandHandler(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<Guid> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = new Goal(request.Title, request.Description, request.CreatedBy, request.AimDate);

            await _goalsRepository.Add(goal);
            await _goalsRepository.UnitOfWork.SaveEntitiesAsync();

            return goal.Id;
        }
    }
}
