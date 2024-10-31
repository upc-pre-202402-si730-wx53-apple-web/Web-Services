using DebtGo.Notification.Application.Internal.CommandServices;
using DebtGo.Notification.Application.Internal.QueryServices;
using DebtGo.Notification.Interfaces.REST.Resources;
using DebtGo.Notification.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace DebtGo.Notification.Interfaces.REST
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationCommandService _commandService;
        private readonly NotificationQueryService _queryService;
        private readonly NotificationCommandFromResourceAssembler _commandAssembler;

        public NotificationController(
            NotificationCommandService commandService,
            NotificationQueryService queryService,
            NotificationCommandFromResourceAssembler commandAssembler)
        {
            _commandService = commandService;
            _queryService = queryService;
            _commandAssembler = commandAssembler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationResource resource)
        {
            var command = _commandAssembler.ToCommand(resource);
            var result = await _commandService.Handle(command);

            if (result == null) return BadRequest("Failed to create notification");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var result = await _queryService.GetNotificationById(id);

            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
