using AutoMapper;
using BudgetTrack.Domain.DTOs.Transactions;
using BudgetTrack.Domain.DTOs.Transactions.Request;
using BudgetTrack.Domain.DTOs.UserAccountBalance;
using BudgetTrack.Domain.Entities;

namespace BudgetTrack.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUserTransactionDTO, UserTransaction>().ReverseMap();
            CreateMap<UserTransactionDTO, UserTransaction>().ReverseMap();
            CreateMap<AddTransactionRequest, UserTransaction>().ReverseMap();
            CreateMap<UpdateTransactionRequest, UserTransaction>().ReverseMap();

            CreateMap<UserAccountBalanceDTO, UserAccountBalance>().ReverseMap();
            CreateMap<UpdateAccountBalanceDTO, UserAccountBalance>().ReverseMap();
        }
    }
}