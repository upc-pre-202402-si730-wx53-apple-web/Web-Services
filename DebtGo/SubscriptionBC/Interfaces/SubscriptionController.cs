using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo.SubscriptionBC.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using DebtGo2.SubscriptionBC.Interfaces.REST.Transform;
using DebtGo2.SubscriptionBC.Interfaces.REST.Resources;

namespace DebtGo.SubscriptionBC.Interface.Controllers
{
    /// <summary>
    ///     Controller for managing subscriptions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController(ISubscriptionCommandService commandService,
            ISubscriptionQueryService queryService) : ControllerBase
    {
        /// <summary>
        ///     Gets a subscription by its unique identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await queryService.GetSubscriptionByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }

        /// <summary>
        ///     Gets all subscriptions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await queryService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionResource resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resources);

            var subscription = await commandService.Handle(command);

            return CreatedAtAction(nameof(Create), subscription);
            //return CreatedAtAction(nameof(GetById), new { id = resources.Id }, resources);
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /*   [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubscriptionDto resources)
        {
            if (id != resources.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await commandService.UpdateSubscriptionAsync(resources);
            return NoContent();
        } */

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /*   [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await commandService.DeleteSubscriptionAsync(id);
            return NoContent();
        } */
    }
}
