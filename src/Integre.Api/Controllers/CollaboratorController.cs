using Integre.Domain.Commands.Handlers;
using Integre.Domain.Commands.Inputs;
using Integre.Domain.Repositories;
using Integre.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Integre.Api.Controllers
{
    public class CollaboratorController : BaseController
    {

        private readonly ICollaboratorRepository _repository;
        private readonly CollaboratorCommandHandler _handler;

        public CollaboratorController(IUow uow, ICollaboratorRepository repository, CollaboratorCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("v1/collaborators")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCollaboratorCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpGet]
        [Route("v1/getcollaborators")]
        //[AllowAnonymous]
        [Authorize(Policy = "Admin")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
    }
}
