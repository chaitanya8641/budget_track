using AutoMapper;
using BudgetTrack.BAL.Interfaces;
using BudgetTrack.DAL.Interfaces;
using BudgetTrack.Domain.DTOs.Transactions;
using BudgetTrack.Domain.Entities;

namespace BudgetTrack.BAL.Services
{
    public class UserTransactionService : IUserTransactionService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public UserTransactionService(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserTransactionDTO>> GetUserTransactions(Guid userId) => _mapper.Map<List<UserTransactionDTO>>(await _transactionsRepository.GetList(x => x.UserId == userId));
        public async Task<UserTransactionDTO> GetUserTransaction(Guid transactionId) => _mapper.Map<UserTransactionDTO>(await _transactionsRepository.Get(x => x.TransactionId == transactionId));
        public async Task<UserTransactionDTO> AddUserTransaction(AddUserTransactionDTO userTransactionDTO) => _mapper.Map<UserTransactionDTO>(await _transactionsRepository.Add(_mapper.Map<UserTransaction>(userTransactionDTO)));
        public async Task<UserTransactionDTO> UpdateUserTransaction(UserUpdateTransactionDTO userUpdateTransactionDTO) => _mapper.Map<UserTransactionDTO>(await _transactionsRepository.Update(_mapper.Map<UserTransaction>(userUpdateTransactionDTO)));
        public async Task<int> DeleteUserTransaction(UserTransactionDTO userTransaction) => await _transactionsRepository.Delete(_mapper.Map<UserTransaction>(userTransaction));
    }
}