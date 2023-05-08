using Bank.API.Data.Models;
using Bank.API.Repository.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Bank.API.Services
{
    public interface IServiceModel
    {
        IEnumerable<AccountWithoutDepositsDTO> GetAccountsService();
        IEnumerable<UserWithoutAccountsDTO> GetUsersService();
        IEnumerable<DepositDTO> GetAllDepositsService(int period);
        IEnumerable<DepositDTO> GetDepositsService(int accountId, int period);


        UserDTO? GetUserServiceTrue(int? userId, bool includeAccounts);
        UserWithoutAccountsDTO? GetUserServiceFalse(int? userId, bool includeAccounts);
        AccountWithoutDepositsDTO? GetAccountServiceFalse(int? accountId, bool includeDeposits);
        UserDTO? GetUserWithUsernameService(string username);
        AccountDTO? GetAccountServiceTrue(int? accountId, bool includeDeposits);
        DepositDTO? GetDepositWithoutAccountService(int? depositId);
        DepositDTO? GetDepositService(int? accountId, int? depositId);

        IEnumerable<AccountWithoutDepositsDTO> GetUserAccountsService(int userId);


        UserDTO AddUserService(UserCreationDTO user);
        AccountDTO AddAccountService(AccountCreationDTO account);
        DepositDTO AddDepositService(int accountId, DepositCreationDTO deposit);




        AccountUpdateDTO UpdateAccountService(int id);
        void UpdateWithPutDeposit(int accountId, int id, DepositUpdateDTO deposit);
        void UpdateWithPutAccount(int accountId, AccountUpdateDTO account);
        void UpdateAccountFinishService(int id, AccountUpdateDTO accountToPatch);
        DepositUpdateDTO UpdateDepositService(int accountId, int id);
        void UpdateDepositFinishService(int accountId, int id, DepositUpdateDTO depositToPatch);




        void DeleteAccountService(int id);
        void DeleteDepositService(int accountId, int id);


        UserDTO LoginRequestService(LoginRequest request);
        bool AccountExistsService(int accountId);
        bool SaveService();
    }
}
