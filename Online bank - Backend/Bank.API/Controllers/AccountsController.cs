using AutoMapper;
using Bank.API.Data.Models;
using Bank.API.Repository.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Bank.API.Services;

namespace Bank.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> _logger;
        private readonly IServiceModel _service;

        public AccountsController(ILogger<AccountsController> logger,IServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }





        [HttpGet]
        public IActionResult GetAccounts()
        {
            try
            {
                var result = _service.GetAccountsService();

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting accounts!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }





        [HttpGet("{id}", Name = "GetAccount")]
        public IActionResult GetAccount(int id, bool includeDeposits = false)
        {
            try
            {
                var resultTrue = _service.GetAccountServiceTrue(id, includeDeposits);
                var resultFalse = _service.GetAccountServiceFalse(id, includeDeposits);

                if (resultTrue == null)
                {
                    _logger.LogInformation($"Account with id {id} wasn't found!");
                    return NotFound();
                }

                if (includeDeposits)
                {
                    return Ok(resultTrue);
                }

                return Ok(resultFalse);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting the account with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }





        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountCreationDTO account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = _service.AddAccountService(account);

                return CreatedAtRoute(
                    "GetAccount",
                    new { id = result },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating an account!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateDeposit(int id, [FromBody] AccountUpdateDTO account)
        {
            try
            {
                if (!_service.AccountExistsService(id))
                {
                    _logger.LogInformation($"Account with id {id} wasn't found!");
                    return NotFound();
                }

                _service.UpdateWithPutAccount(id, account);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating deposit with id {id} from the account with id {id}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }



        [HttpPatch("{id}")]
        public IActionResult PartialUpdateAccount(int id, [FromBody] JsonPatchDocument<AccountUpdateDTO> patchDoc)
        {
            try
            {
                if (!_service.AccountExistsService(id))
                {
                    _logger.LogInformation($"Account with id {id} wasn't found!");
                    return NotFound();
                }

                var accountToPatch = _service.UpdateAccountService(id);

                patchDoc.ApplyTo(accountToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(accountToPatch))
                {
                    return BadRequest(ModelState);
                }


                _service.UpdateAccountFinishService(id, accountToPatch);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating the account with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                if (!_service.AccountExistsService(id))
                {
                    _logger.LogInformation($"Account with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteAccountService(id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting the account with id {id}!");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
