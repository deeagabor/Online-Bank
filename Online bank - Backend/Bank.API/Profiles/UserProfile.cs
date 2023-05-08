using Bank.API.Data.Models;
using Bank.API.Repository.Entities;
using AutoMapper;

namespace Bank.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {

            CreateMap<User, UserWithoutAccountsDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserCreationDTO, User>();
        }
    }
}
