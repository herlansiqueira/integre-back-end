using Dapper;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using Integre.Domain.Repositories;
using Integre.Infra.Contexts;
using Integre.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Integre.Infra.Repositories
{
    public class RolesRepository : IRolesRepository
    {

        private readonly DataContext _context;

        public RolesRepository(DataContext context)
        {
            _context = context;
        }

        public Roles Get(Guid id)
        {
            return _context
                .roles
                .FirstOrDefault(x => x.Id == id);
        }

        public Roles GetByCode(string code)
        {
            return _context
                .roles
                .AsNoTracking()
                .FirstOrDefault(x => x.Code == code);
        }

        public void Save(Roles roles)
        {
            _context.roles.Add(roles);
        }

        public void Update(Roles roles)
        {
            _context.Entry(roles).State = EntityState.Modified;
        }

        public bool RolesExists(string codigo)
        {
            return _context.roles.Any(x => x.Code == codigo);
        }

        public IEnumerable<GetRolesCommandResult> Get()
        {
            var query = "SELECT * FROM [Roles]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetRolesCommandResult>(query);
            }
        }

        public GetRolesCommandResult Get(string code)
        {
            var query = "SELECT  [Id] ,[Code] ,[Description] FROM [Roles] WHERE [Code] = @code";

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetRolesCommandResult>(query,
                    new { Code = code })
                    .FirstOrDefault();
            }
        }
    }
}
