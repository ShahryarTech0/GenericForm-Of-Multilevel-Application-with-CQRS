using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Add Merchant Location
        [HttpPost("AddMerchant")]
        public async Task<IActionResult> AddMerchant([FromBody] AddMerchantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // Get Zone Areas by ID
        [HttpGet("{zoneId}")]
        public async Task<IActionResult> GetMerchantById(int Id)
        {

            var result = await _mediator.Send(new GetMerchantbyIdQuery(Id));
            return Ok(result);
        }

        //// Update Merchant Location
        [HttpPut("UpdateMerchant")]
        public async Task<IActionResult> UpdateMerchant([FromBody] UpdateMerchantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //// Delete Merchant Location
        [HttpDelete("DeleteMerchant")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var result = await _mediator.Send(new DeleteMerchantCommand(id));
            return Ok(result);
        }

        [HttpGet("GetallMerchant")]
        public async Task<IActionResult> GetAllMerchantLocations()
        {
            var result = await _mediator.Send(new GetAllMerchantQuery());
            return Ok(result);
        }

    }
}
