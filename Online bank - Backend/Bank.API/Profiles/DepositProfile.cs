using AutoMapper;
using Bank.API.Data.Models;
using Bank.API.Repository.Entities;



namespace Bank.API.Profiles
{
    public class DepositProfile : Profile
    {
        public DepositProfile() 
        {
            CreateMap<Deposit,DepositDTO>();
            CreateMap<DepositCreationDTO, Deposit>();
            CreateMap<DepositUpdateDTO, Deposit>();
            CreateMap<Deposit, DepositUpdateDTO>();
        }
    }
}
