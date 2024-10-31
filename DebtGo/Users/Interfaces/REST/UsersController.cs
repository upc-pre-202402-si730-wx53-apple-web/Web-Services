using System.Net.Mime;
using DebtGo.Users.Domain.Model.Queries;
using DebtGo.Users.Domain.Services;
using DebtGo.Users.Interfaces.REST.Resources;
using DebtGo.Users.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DebtGo.Users.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = UserResourceFormEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = userResource.id }, userResource);
    }

    [HttpGet("{useId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var profile = await userQueryService.Handle(getUserByIdQuery);
        if (userId == null) return NotFound();
        var userResource = UserResourceFormEntityAssembler.ToResourceFromEntity(profile);
        return Ok(userResource);
    }
}