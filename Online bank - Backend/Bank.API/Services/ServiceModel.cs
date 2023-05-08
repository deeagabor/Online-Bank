using AutoMapper;
using Bank.API.Controllers;
using Bank.API.Data.Models;
using Bank.API.Repository;
using Bank.API.Repository.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Bank.API.Services
{
    public class ServiceModel : IServiceModel
    {
        private readonly IAccountInfoRepository _accountInfoRepository;
        private readonly IMapper _mapper;

        public ServiceModel(IAccountInfoRepository accountInfoRepository, IMapper mapper)
        {
            _accountInfoRepository = accountInfoRepository ?? throw new ArgumentNullException(nameof(AccountInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }






        public IEnumerable<AccountWithoutDepositsDTO> GetAccountsService()
        {
            var result = _accountInfoRepository.GetAccounts();
            return _mapper.Map<IEnumerable<AccountWithoutDepositsDTO>>(result);
        }

        public IEnumerable<UserWithoutAccountsDTO> GetUsersService()
        {
            var result = _accountInfoRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserWithoutAccountsDTO>>(result);
        }

        public IEnumerable<DepositDTO> GetAllDepositsService(int period)
        {
            var result = _accountInfoRepository.GetAllDeposits(period);

            return _mapper.Map<IEnumerable<DepositDTO>>(result);
        }

        public IEnumerable<DepositDTO> GetDepositsService(int accountId, int period)
        {
            var result = _accountInfoRepository.GetDeposits(accountId, period);
            return _mapper.Map<IEnumerable<DepositDTO>>(result);
        }

        public IEnumerable<AccountWithoutDepositsDTO> GetUserAccountsService(int userId)
        {
            var result = _accountInfoRepository.GetUserAccounts(userId);
            return _mapper.Map<IEnumerable<AccountWithoutDepositsDTO>>(result);
        }






        public AccountDTO? GetAccountServiceTrue(int? accountId, bool includeDeposits)
        {
            var result = _accountInfoRepository.GetAccount(accountId, includeDeposits);

            return _mapper.Map<AccountDTO>(result);
        }

        public AccountWithoutDepositsDTO? GetAccountServiceFalse(int? accountId, bool includeDeposits)
        {
            var result = _accountInfoRepository.GetAccount(accountId, includeDeposits);

            return _mapper.Map<AccountWithoutDepositsDTO>(result);
        }

        public UserDTO? GetUserServiceTrue(int? id, bool includeAccounts)
        {
            var result = _accountInfoRepository.GetUser(id, includeAccounts);

            return _mapper.Map<UserDTO>(result);
        }

        public UserWithoutAccountsDTO? GetUserServiceFalse(int? id, bool includeAccounts)
        {
            var result = _accountInfoRepository.GetUser(id, includeAccounts);

            return _mapper.Map<UserWithoutAccountsDTO>(result);
        }

        public UserDTO? GetUserWithUsernameService(string username)
        {
            var result = _accountInfoRepository.GetUserWithUsername(username);

            return _mapper.Map<UserDTO>(result);
        }
        public DepositDTO? GetDepositWithoutAccountService(int? depositId)
        {
            var result = _accountInfoRepository.GetDepositWithoutAccount(depositId);

            return _mapper.Map<DepositDTO>(result);
        }


        public DepositDTO? GetDepositService(int? accountId, int? depositId)
        {
            var result = _accountInfoRepository.GetDeposit(accountId, depositId);

            return (_mapper.Map<DepositDTO>(result));
        }




        public UserDTO AddUserService(UserCreationDTO user)
        {   
            var result = _mapper.Map<User>(user);

            _accountInfoRepository.AddUser(result);
            _accountInfoRepository.Save();

            return _mapper.Map<UserDTO>(result);
        }



        public AccountDTO AddAccountService(AccountCreationDTO account)
        {
            var result = _mapper.Map<Account>(account);

            _accountInfoRepository.AddAccount(result);
            _accountInfoRepository.Save();

            return _mapper.Map<AccountDTO>(result);
        }


        public DepositDTO AddDepositService(int accountId, DepositCreationDTO deposit)
        {
            var result = _mapper.Map<Deposit>(deposit);

            _accountInfoRepository.AddDeposit(accountId, result);
            _accountInfoRepository.Save();
            
            return _mapper.Map<DepositDTO>(result);
        }







        public void UpdateWithPutDeposit(int accountId, int id, DepositUpdateDTO deposit)
        {
            var depositEntity = _accountInfoRepository.GetDeposit(accountId, id);
            _mapper.Map(deposit, depositEntity);
        }

        public void UpdateWithPutAccount(int accountId, AccountUpdateDTO account)
        {
            var accountEntity = _accountInfoRepository.GetAccount(accountId, false);
            _mapper.Map(account, accountEntity);
        }


        public AccountUpdateDTO UpdateAccountService(int id) 
        {
            var accountEntity = _accountInfoRepository.GetAccount(id, false);
            return _mapper.Map<AccountUpdateDTO>(accountEntity);
        }

        public void UpdateAccountFinishService(int id, AccountUpdateDTO accountToPatch)
        {
            var accountEntity = _accountInfoRepository.GetAccount(id, false);
            _mapper.Map(accountToPatch, accountEntity);
        }


        public DepositUpdateDTO UpdateDepositService(int accountId, int id)
        {
            var depositEntity = _accountInfoRepository.GetDeposit(accountId, id);
            return _mapper.Map<DepositUpdateDTO>(depositEntity);
        }

        public void UpdateDepositFinishService(int accountId, int id, DepositUpdateDTO depositToPatch)
        {
            var depositEntity = _accountInfoRepository.GetDeposit(accountId, id);
            _mapper.Map(depositToPatch, depositEntity);
        }







        public void DeleteAccountService(int id)
        {
            var accountEntity = _accountInfoRepository.GetAccount(id, false);

            _accountInfoRepository.DeleteAccount(accountEntity);

            _accountInfoRepository.Save();
        }

        public void DeleteDepositService(int accountId, int id) 
        {
            var result = _accountInfoRepository.GetDeposit(accountId, id);

            _accountInfoRepository.DeleteDeposit(result);

            _accountInfoRepository.Save();
        }






        public UserDTO LoginRequestService(LoginRequest request)
        {
            var user =  _accountInfoRepository.LoginRequest(request);

            if(user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public bool AccountExistsService(int accountId)
        {
            return _accountInfoRepository.AccountExists(accountId);
        }

        public bool SaveService()
        {
            return _accountInfoRepository.Save();
        }
    }
}
