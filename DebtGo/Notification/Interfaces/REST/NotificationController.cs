using System.Net.Mime;
using DebtGo.Notification.Domain.Services;
using DebtGo.Notification.Interfaces.REST.Resources;
using DebtGo.Notification.Interfaces.REST.Transform;
using DebtGo.Notification.Domain.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using NotificationsBC.Application.Internal.CommandServices;
using DebtGo.Notification.Domain.Model.Queries;

namespace NotificationsBC.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Notification")]
    public class NotificationController(INotificationCommandService commandService, INotificationQueryService queryService) : ControllerBase
    {

        /// <summary>
        /// Crea una nueva notificaci�n.
        /// </summary>
        /// <param name="resource">Los detalles de la notificaci�n.</param>
        /// <returns>La notificaci�n creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationResource resource)
        {
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
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var query = new GetAllNotificationsQuery();
            var result = await queryService.Handle(query);

            if (result == null) return NotFound();

            var notificationResources = result.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(notificationResources);
        }
    }
}
