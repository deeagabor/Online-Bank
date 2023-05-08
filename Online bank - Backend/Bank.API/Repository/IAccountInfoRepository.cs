using Bank.API.Data.Models;
using Bank.API.Repository.Entities;


namespace Bank.API.Repository
{
    public interface IAccountInfoRepository
    {
        IEnumerable<Account> GetAccounts();

        IEnumerable<Account> GetUserAccounts(int id);
        IEnumerable<User> GetUsers();
        Account? GetAccount(int? accountId, bool includeDeposits);
        User? GetUser(int? userId, bool includeAccounts);
        User? GetUserWithUsername(string username);


        IEnumerable<Deposit> GetDeposits(int accountId, int period);
        IEnumerable<Deposit> GetAllDeposits(int period);

        Deposit? GetDeposit(int? accountId, int? depositId);
        Deposit? GetDepositWithoutAccount(int? depositId);





        void AddDeposit(int accountId, Deposit deposit);
        void AddAccount(Account account);
        void AddUser(User user);





        void DeleteAccount(Account account);
        void DeleteDeposit(Deposit deposit);



        User? LoginRequest(LoginRequest request);
        bool AccountExists(int accountId);
        bool Save();
    }
}
