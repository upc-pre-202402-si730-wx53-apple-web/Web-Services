using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo.SubscriptionBC.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DebtGo.SubscriptionBC.Interface.Controllers
{
    /// <summary>
    ///     Controller for managing subscriptions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionCommandService _subscriptionCommandService;
        private readonly ISubscriptionQueryService _subscriptionQueryService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionController"/> class.
        /// </summary>
        /// <param name="commandService"> The command service for managing subscriptions.</param>
        /// <param name="queryService"> The query service for fetching subscription data.</param>
        public SubscriptionController(
            ISubscriptionCommandService commandService,
            ISubscriptionQueryService queryService)
        {
            _subscriptionCommandService = commandService;
            _subscriptionQueryService = queryService;
        }

        /// <summary>
        ///     Gets a subscription by its unique identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _subscriptionQueryService.GetSubscriptionByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }

        /// <summary>
        ///     Gets all subscriptions.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await _subscriptionQueryService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscriptionDto resources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _subscriptionCommandService.CreateSubscriptionAsync(resources);
            return CreatedAtAction(nameof(GetById), new { id = resources.Id }, resources);
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubscriptionDto resources)
        {
            if (id != resources.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _subscriptionCommandService.UpdateSubscriptionAsync(resources);
            return NoContent();
        }

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriptionCommandService.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}
