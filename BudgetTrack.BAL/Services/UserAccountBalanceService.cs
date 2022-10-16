using AutoMapper;
using BudgetTrack.BAL.Interfaces;
using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Domain.DTOs.UserAccountBalance;

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

        public async Task<decimal> GetBalance(string accountType, Guid userId)
        {
            var accountBalance = _mapper.Map<UserAccountBalanceDTO>(await _userAccountBalanceRepository.Get(x => x.Type.ToString() == accountType && x.UserId == userId));
            return accountBalance.AccounrBalance;
        }
    }
}
