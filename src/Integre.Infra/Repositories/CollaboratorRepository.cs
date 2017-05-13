using Dapper;
using Integre.Domain.Commands.Results;
using Integre.Domain.Entities;
using Integre.Domain.Repositories;
using Integre.Infra.Contexts;
using Integre.Shared;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace Integre.Infra.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {

        private readonly DataContext _context;

        public CollaboratorRepository(DataContext context)
        {
            _context = context;
        }

        public Collaborator Get(Guid id)
        {
            return _context
                .collaborators
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Collaborator GetByUsername(string username)
        {
            return _context
                .collaborators
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.User.Username == username);
        }

        public void Save(Collaborator customer)
        {
            _context.collaborators.Add(customer);
        }

        public void Update(Collaborator collaborator)
        {
            _context.Entry(collaborator).State = EntityState.Modified;
        }

        public bool DocumentExists(string document)
        {
            return _context.collaborators.Any(x => x.Document.Number == document);
        }

        public GetCollaboratorCommandResult Get(string username)
        {
            //return _context
            //    .collaborators
            //    .Include(x => x.User)
            //    .AsNoTracking()
            //    .Select(x => new GetCollaboratorCommandResult
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        Username = x.User.Username
            //    })
            //    .FirstOrDefault(x => x.Username == username);

            var query = "SELECT * FROM [GetCollaboratorInfoView] WHERE [Active]=1 AND [Username]=@username";

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetCollaboratorCommandResult>(query,
                    new { username = username })
                    .FirstOrDefault();
            }
        }

        public IEnumerable<GetCollaboratorCommandResult> Get()
        {
            var query = "SELECT * FROM [GetCollaboratorInfoView]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetCollaboratorCommandResult>(query);
            }
        }
    }
}
