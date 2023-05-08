using AutoMapper;
using Bank.API.Data.Models;
using Bank.API.Repository.Entities;


namespace Bank.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile() 
        { 
            CreateMap<Account, AccountWithoutDepositsDTO>();
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountCreationDTO, Account>();
            CreateMap<AccountUpdateDTO, Account>();
            CreateMap<Account, AccountUpdateDTO>();
        }
    }
}
