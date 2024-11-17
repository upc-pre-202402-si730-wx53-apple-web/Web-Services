<<<<<<< Updated upstream
using DebtGo.Notification.Domain.Model.Commands;
=======
<<<<<<< HEAD
using System.Net.Mime;
using DebtGo.Notification.Domain.Services;
using DebtGo.Notification.Interfaces.REST.Resources;
using DebtGo.Notification.Interfaces.REST.Transform;
=======
using DebtGo.Notification.Domain.Model.Commands;
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using NotificationsBC.Application.Internal.CommandServices;

namespace NotificationsBC.Interfaces.REST.Controllers
{
    [ApiController]
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Notification")]
    public class NotificationController(INotificationCommandService commandService, INotificationQueryService queryService) : ControllerBase
    {
=======
>>>>>>> Stashed changes
    [Route("api/notifications")]
    [Produces("application/json")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationCommandService _commandService;

        public NotificationController(NotificationCommandService commandService)
        {
            _commandService = commandService;
        }
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0

        /// <summary>
        /// Crea una nueva notificación.
        /// </summary>
        /// <param name="resource">Los detalles de la notificación.</param>
        /// <returns>La notificación creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationResource resource)
        {
<<<<<<< Updated upstream
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
=======
<<<<<<< HEAD
            var command = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await commandService.Handle(command);

            if (result == null) return BadRequest("Failed to create notification");

            var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(result);

            return Ok(notificationResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification([FromRoute] int id)
        {
            var query = GetNotificationByIdQueryFromResourceAssembler.ToCommandFromResource(id);
            var result = await queryService.Handle(query);

            if (result == null) return NotFound();

            var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(result);

            return Ok(notificationResource);
=======
            var command = new CreateNotificationCommand(resource.Content, resource.Type);
            var result = await _commandService.Handle(command);
            return Ok(result);
>>>>>>> Stashed changes
        }


        /// <summary>
        /// Obtiene todas las notificaciones.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Lógica de obtención de notificaciones
            return Ok(new { Message = "Get all notifications" });
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
        }
    }
}
