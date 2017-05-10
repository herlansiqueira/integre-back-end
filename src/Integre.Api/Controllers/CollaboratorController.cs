using Integre.Domain.Commands.Handlers;
using Integre.Domain.Commands.Inputs;
using Integre.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Integre.Api.Controllers
{
    public class CollaboratorController : BaseController
    {
        private readonly CollaboratorCommandHandler _handler;

        public CollaboratorController(IUow uow, CollaboratorCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/collaborators")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCollaboratorCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
