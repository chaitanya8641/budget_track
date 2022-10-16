using BudgetTrack.API.Exceptions;
using BudgetTrack.BAL.Interfaces;
using BudgetTrack.Domain.DTOs.Transactions;
using BudgetTrack.Domain.DTOs.Transactions.Request;
using BudgetTrack.Domain.DTOs.Transactions.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BudgetTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : BaseController
    {
        private readonly IUserTransactionService _userTransactionService;
        public BudgetController(IUserTransactionService userTransactionService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userTransactionService = userTransactionService;
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetUserTransactions(Guid userId, string? type)
        {
            var transactions = await _userTransactionService.GetUserTransactions(userId);
            if (type != null)
            {
                transactions = transactions.Where(x => x.Type.ToString() == type.ToString());
            }
            return Ok(transactions);
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionRequest AddTransactionRequest)
        {
            AddUserTransactionDTO userTransactionDTO = new()
            {
                TransactionName = AddTransactionRequest.TransactionName,
                TransactionAmount = AddTransactionRequest.TransactionAmount,
                Type = AddTransactionRequest.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = Guid.Parse(GetUserId())
            };
            var transaction = await _userTransactionService.AddUserTransaction(userTransactionDTO);
            if (transaction.TransactionId == Guid.Empty)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User transaction not created successfully", $"TransactionAmount: {AddTransactionRequest.TransactionAmount}");
            }
            TransactionCommonResponse response = new()
            {
                TransactionId = transaction.TransactionId,
                Message = "User transaction created successfully!"
            };

            return Ok(response);
        }

        [HttpPost("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionRequest updateTransactionRequest)
        {

            var transaction = await _userTransactionService.GetUserTransaction(updateTransactionRequest.TransactionId);
            if (transaction.TransactionId == Guid.Empty)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User transaction not found", $"Transaction Id: {updateTransactionRequest.TransactionId}");
            }

            UserUpdateTransactionDTO userTransactionDTO = new()
            {
                TransactionId = transaction.TransactionId,
                TransactionName = updateTransactionRequest.TransactionName,
                TransactionAmount = updateTransactionRequest.TransactionAmount,
                Type = updateTransactionRequest.Type,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = DateTime.Now,
                UserId = Guid.Parse(GetUserId())
            };
            await _userTransactionService.UpdateUserTransaction(userTransactionDTO);
            TransactionCommonResponse response = new()
            {
                Message = "User transaction updated sucessfully!!",
                TransactionId = transaction.TransactionId
            };
            return Ok(response);
        }

        [HttpPost("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(Guid transactionId)
        {
            var result = await _userTransactionService.DeleteUserTransaction(transactionId);
            if (result == 1)
            {
                TransactionCommonResponse response = new()
                {
                    TransactionId = transactionId,
                    Message = "User transaction deleted successfully!"
                };
                return Ok(response);
            }
            throw new HttpException(HttpStatusCode.NotFound, "User not found", $"Transaction Id: {transactionId}");
        }
    }
}
