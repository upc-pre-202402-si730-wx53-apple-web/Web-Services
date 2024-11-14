using DebtGo.Notification.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using NotificationsBC.Application.Internal.CommandServices;

namespace NotificationsBC.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    [Produces("application/json")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationCommandService _commandService;

        public NotificationController(NotificationCommandService commandService)
        {
            _commandService = commandService;
        }

        /// <summary>
        /// Crea una nueva notificación.
        /// </summary>
        /// <param name="resource">Los detalles de la notificación.</param>
        /// <returns>La notificación creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationResource resource)
        {
            var command = new CreateNotificationCommand(resource.Content, resource.Type);
            var result = await _commandService.Handle(command);
            return Ok(result);
        }


        /// <summary>
        /// Obtiene todas las notificaciones.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Lógica de obtención de notificaciones
            return Ok(new { Message = "Get all notifications" });
        }
    }
}
