using Integre.Shared.Commands;
using System;

namespace Integre.Domain.Commands.Inputs
{
    public class RegisterUserRolesCommand : ICommand
    {
        public string RolesCode { get; set; }
    }
}
