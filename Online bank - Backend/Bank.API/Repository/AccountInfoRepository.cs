using Bank.API.Data;
using Bank.API.Data.Models;
using Bank.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Bank.API.Repository
{
    public class AccountInfoRepository : IAccountInfoRepository
    {
        private readonly AccountInfoContext _context;

        private string SHA256Hash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        public AccountInfoRepository(AccountInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public IEnumerable<Account> GetUserAccounts(int id)
        {
            return _context.Accounts.Where(a => a.UserId == id).ToList();
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Account? GetAccount(int? accountId, bool includeDeposits)
        {
            if (includeDeposits)
            {
                return _context.Accounts.Include(a => a.Deposits).Where(a => a.Id == accountId).FirstOrDefault();
            }

            return _context.Accounts.Where(a => a.Id == accountId).FirstOrDefault();
        }

        public User? GetUser(int? userId, bool includeAccounts)
        {
            if (includeAccounts)
            {
                return _context.Users.Include(a => a.Accounts).Where(a => a.Id == userId).FirstOrDefault();
            }

            return _context.Users.Where(a => a.Id == userId).FirstOrDefault();
        }

        public User? GetUserWithUsername(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }


        public IEnumerable<Deposit> GetDeposits(int accountId, int period)
        {
            if (period != 0)
            {
                return _context.Deposits.Where(d => d.AccountId == accountId && d.Period == period).ToList();
            }
            return _context.Deposits.Where(d => d.AccountId == accountId).ToList();
        }

        public IEnumerable<Deposit> GetAllDeposits(int period)
        {
            if (period != 0)
            {
                return _context.Deposits.Where(d => d.Period == period).ToList();
            }
            return _context.Deposits.ToList();
        }




        public Deposit? GetDeposit(int? accountId, int? depositId)
        {

            return _context.Deposits.Where(d => d.AccountId == accountId && d.Id == depositId).FirstOrDefault();
        }

        public Deposit? GetDepositWithoutAccount(int? depositId)
        {
            return _context.Deposits.Where(d => d.Id == depositId).FirstOrDefault();
        }





        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void AddDeposit(int accountId, Deposit deposit)
        {
            var account = GetAccount(accountId, false);
            account.Deposits.Add(deposit);
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
        }







        public void DeleteDeposit(Deposit deposit)
        {
            _context.Deposits.Remove(deposit);
        }

        public void DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
        }


        


        public User? LoginRequest(LoginRequest request)
        { 
           foreach(var user in _context.Users) 
           {
                if(user.Username == request.Username && user.Password == request.Password)
                {
                    return user;
                }
           }

           return null;
        }


        public bool AccountExists(int accountId)
        {
            return _context.Accounts.Any(a => a.Id == accountId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
