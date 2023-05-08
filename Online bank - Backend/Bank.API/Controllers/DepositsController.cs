using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Bank.API.Repository.Entities;
using Bank.API.Data.Models;
using Bank.API.Repository;
using Bank.API.Services;

namespace Bank.API.Controllers
{
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IServiceModel _service;

        public DepositsController(ILogger<AccountsController> logger, IServiceModel service)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }





        [HttpGet("api/deposits")]
        public IActionResult GetDeposits(int period)
        {
            try
            {
                var result = _service.GetAllDepositsService(period);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting all deposits.");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }





        [HttpGet("api/accounts/{accountId}/deposits")]
        public IActionResult GetDeposits(int accountId, int period)
        {
            try
            {
                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetDepositsService(accountId, period);

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting deposits for account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }

        }




        [HttpGet("api/deposits/{id}")]
        public IActionResult GetAccount(int id)
        {
            try
            {
                var result = _service.GetDepositWithoutAccountService(id);

                if (result == null)
                {
                    _logger.LogInformation($"Deposit with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting deposit with id {id}.");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }





        [HttpGet("api/accounts/{accountId}/deposits/{id}", Name = "GetDeposit")]
        public IActionResult GetAccount(int accountId, int id)
        {
            try
            {
                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetDepositService(accountId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Deposit with id {id} wasn't found!");
                    return NotFound();
                }

                return Ok(result);
            }
            catch
            {
                _logger.LogCritical($"Exception while getting deposit with id {id} from the account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }




        [HttpPost("api/accounts/{accountId}/deposits")]
        public IActionResult CreateDeposit(int accountId, [FromBody] DepositCreationDTO deposit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }

                var result = _service.AddDepositService(accountId, deposit);

                return CreatedAtRoute(
                    "GetDeposit",
                    new { accountId, id = result.Id },
                    result
                    );
            }
            catch
            {
                _logger.LogCritical($"Exception while creating a deposit in the account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPut("api/accounts/{accountId}/deposits/{id}")]
        public IActionResult UpdateDeposit(int accountId, int id, [FromBody] DepositUpdateDTO deposit)
        {
            try
            {

                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }


                var depositEntity = _service.GetDepositService(accountId, id);

                if (depositEntity == null)
                {
                    _logger.LogInformation($"Deposit with id {id} wasn't found!");
                    return NotFound();
                }

                _service.UpdateWithPutDeposit(accountId, id, deposit);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating deposit with id {id} from the account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }


        [HttpPatch("api/accounts/{accountId}/deposits/{id}")]
        public IActionResult PartialUpdateDeposit(int accountId, int id, [FromBody] JsonPatchDocument<DepositUpdateDTO> patchDoc)
        {
            try
            {

                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }


                var result = _service.GetDepositService(accountId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Deposit with id {id} wasn't found!");
                    return NotFound();
                }

                var depositToPatch = _service.UpdateDepositService(accountId, id);

                patchDoc.ApplyTo(depositToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(depositToPatch))
                {
                    return BadRequest(ModelState);
                }

                _service.UpdateDepositFinishService(accountId, id, depositToPatch);
                _service.SaveService();

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while updating deposit with id {id} from the account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }





        [HttpDelete("api/accounts/{accountId}/deposits/{id}")]
        public IActionResult DeleteDeposit(int accountId, int id)
        {
            try
            {

                if (!_service.AccountExistsService(accountId))
                {
                    _logger.LogInformation($"Account with id {accountId} wasn't found!");
                    return NotFound();
                }

                var result = _service.GetDepositService(accountId, id);

                if (result == null)
                {
                    _logger.LogInformation($"Deposit with id {id} wasn't found!");
                    return NotFound();
                }

                _service.DeleteDepositService(accountId, id);

                return NoContent();
            }
            catch
            {
                _logger.LogCritical($"Exception while deleting deposit with id {id} from the account with id {accountId}");
                return StatusCode(500, "A problem happend while handling your request.");
            }
        }
    }
}
