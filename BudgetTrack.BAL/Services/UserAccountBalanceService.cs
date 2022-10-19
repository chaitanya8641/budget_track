using AutoMapper;
using BudgetTrack.BAL.Interfaces;
using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Domain.DTOs.UserAccountBalance;
using BudgetTrack.Domain.Entities;
using BudgetTrack.Domain.Enums;

namespace BudgetTrack.BAL.Services
{
    public class UserAccountBalanceService : IUserAccountBalanceService
    {
        private readonly IUserAccountBalanceRepository _userAccountBalanceRepository;
        private readonly IMapper _mapper;

        public UserAccountBalanceService(IUserAccountBalanceRepository userAccountBalanceRepository, IMapper mapper)
        {
            _userAccountBalanceRepository = userAccountBalanceRepository;
            _mapper = mapper;
        }

        public async Task<UserAccountBalanceDTO> GetCreditAccountBalance(Guid userId)
        {
            var accountBalance = _mapper.Map<UserAccountBalanceDTO>(await _userAccountBalanceRepository.Get(x => x.Type.ToString() == TransactionType.Credit.ToString() && x.UserId == userId));
            return accountBalance;
        }

        public async Task<UserAccountBalanceDTO> GetDebitAccountBalance(Guid userId)
        {
            var accountBalance = _mapper.Map<UserAccountBalanceDTO>(await _userAccountBalanceRepository.Get(x => x.Type.ToString() == TransactionType.Debit.ToString() && x.UserId == userId));
            return accountBalance;
        }

        public async Task<bool> UpdateAccountBalance(UserAccountBalanceDTO userAccountBalanceDTO)
        {
            var result = _mapper.Map<UserAccountBalanceDTO>(await _userAccountBalanceRepository.Update(_mapper.Map<UserAccountBalance>(userAccountBalanceDTO)));
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
