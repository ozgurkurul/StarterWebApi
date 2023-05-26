using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using CryptocurrencyPurchaseOrderApi.V1.Requests;
using CryptocurrencyPurchaseOrderApi.V1.Responses;

namespace CryptocurrencyPurchaseOrderApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/users")]
    //[ApiExplorerSettings(GroupName = "Users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<QueryUsersResponse>))]
        public async Task<IActionResult> QueryUsers([FromQuery] QueryUsersRequest request)
        {
            List<QueryUsersResponse> results = new List<QueryUsersResponse>();
            results.Add(new QueryUsersResponse());
            await Task.FromResult(1);
            return Ok(results);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserResponse))]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            GetUserResponse response = new GetUserResponse();
            response.name = await Task.FromResult("Özgür");
            return Ok(response);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateUserResponse))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            response.Id = await Task.FromResult("1");
            return Created(new Uri(response.Id, UriKind.Relative), response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateUserResponse))]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();
            response.Message = await Task.FromResult("The update was successful.");
            return Ok(response);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatchUserResponse))]
        public async Task<IActionResult> PatchUser([FromRoute] long id, [FromBody] JsonPatchDocument<PatchUserRequest> request)
        {
            PatchUserResponse response = new PatchUserResponse();
            response.Message = await Task.FromResult("The update was successful.");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            await Task.FromResult(true);
            return NoContent();
        }
    }
}
