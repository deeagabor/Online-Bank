using Bank.API.Data.Models;
using Bank.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IServiceModel _service;

        public UsersController(ILogger<UsersController> logger, IServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var result = _service.GetUsersService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting users!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id, bool includeAccounts = false)
        {
            try
            {
                var resultTrue = _service.GetUserServiceTrue(id, includeAccounts);
                var resultFalse = _service.GetUserServiceFalse(id, includeAccounts);

                if(resultTrue == null)
                {
                    _logger.LogInformation($"User with id {id} wasn't found!");
                    return NotFound();
                }

                if (includeAccounts)
                {
                    return Ok(resultTrue);
                }

                return Ok(resultFalse);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting the user with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpGet("usernames/{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var result = _service.GetUserWithUsernameService(username);

                if (result == null)
                {
                    _logger.LogInformation($"User with username {username} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting the user with username {username}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpGet("{userId}/accounts")]
        public IActionResult GetDeposits(int userId)
        {
            try
            {
                var result = _service.GetUserServiceFalse(userId, false);

                if (result == null)
                {
                    _logger.LogInformation($"User with id {userId} wasn't found!");
                    return NotFound();
                }

                var userAccounts = _service.GetUserAccountsService(userId);

                return Ok(userAccounts);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting accounts for user with id {userId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreationDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _service.AddUserService(user);

                return CreatedAtRoute(
                    "GetUser",
                    new { id = result },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating an user!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
