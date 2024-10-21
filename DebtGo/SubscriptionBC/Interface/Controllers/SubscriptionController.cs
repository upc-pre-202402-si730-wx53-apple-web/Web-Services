using DebtGo.SubscriptionBC.Application.DTOs;
using DebtGo.SubscriptionBC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DebtGo.SubscriptionBC.Interface.Controllers
{
    /// <summary>
    ///     Controller for managing subscriptions.
    /// </summary>
    /// <remarks>
    ///     This controller provides HTTP endpoints for CRUD operations on <see cref="SubscriptionDto"/> entities.
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionController"/> class.
        /// </summary>
        /// <param name="service">The subscription service for managing subscriptions.</param>
        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Gets a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription.</param>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _service.GetSubscriptionByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }

        /// <summary>
        ///     Gets all subscriptions.
        /// </summary>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await _service.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        /// <param name="dto">The subscription data transfer object.</param>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscriptionDto dto)
        {
            await _service.CreateSubscriptionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to update.</param>
        /// <param name="dto">The updated subscription data transfer object.</param>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubscriptionDto dto)
        {
            if (id != dto.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateSubscriptionAsync(dto);
            return NoContent();
        }

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to delete.</param>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}
