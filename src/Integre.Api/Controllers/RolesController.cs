using Integre.Domain.Commands.Handlers;
using Integre.Domain.Commands.Inputs;
using Integre.Domain.Repositories;
using Integre.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Integre.Api.Controllers
{
    public class RolesController : BaseController
    {

        private readonly IRolesRepository _repository;
        private readonly RolesCommandHandler _handler;

        public RolesController(IUow uow, IRolesRepository repository, RolesCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("v1/roles")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterRolesCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpGet]
        [Route("v1/getroles")]
        [AllowAnonymous]
        //[Authorize(Policy = "Admin")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
    }
}
