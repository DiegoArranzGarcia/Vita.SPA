﻿using Dapper;
using MediatR;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Configuration;

namespace Vita.Api.Application.Goals.Queries
{
    public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, GoalDto>
    {
        private const string sql = "Select Id, Title, Description, CreatedOn from Goals where Id = @Id";
        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetGoalByIdQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<GoalDto>(sql, new { request.Id });
        }
    }
}