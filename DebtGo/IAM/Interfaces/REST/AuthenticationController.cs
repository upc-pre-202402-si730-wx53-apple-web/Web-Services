using System.Net.Mime;
using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Services;
using DebtGo.IAM.Interfaces.REST.Resources;
using DebtGo.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DebtGo.IAM.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Authentication")]
    public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
    {
        [HttpPost("sign-up")]
        [SwaggerOperation(
            Summary = "Register a new user account",
            Description = "Creates a new user account in the system using the provided registration details, including username, password, and additional required information.",
            OperationId = "SignUp"
            )]
        [SwaggerResponse(201, "User account created successfully", typeof(User))]
        public async Task<ActionResult> SignUp([FromBody] SignUpResource resource)
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await userCommandService.Handle(signUpCommand);

            if (result is null) return BadRequest();

            var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);

            return CreatedAtAction(nameof(SignUp), userResource);
        }

        [HttpPost("sign-in")]
        [SwaggerOperation(
            Summary = "Authenticate and sign in user",
            Description = "Authenticates the user with the provided credentials and, if successful, signs them into the system, returning relevant user session information.",
            OperationId = "SignIn"
            )]
        [SwaggerResponse(201, "User authenticated successfully", typeof(User))]
        public async Task<ActionResult> SignIn([FromBody] SignInResource resource)
        {
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await userCommandService.Handle(signInCommand);

            if (result is null) return BadRequest();

            return CreatedAtAction(nameof(SignUp), new { id = result.Id });
        }
    }
}