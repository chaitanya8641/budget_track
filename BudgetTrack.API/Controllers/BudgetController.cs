using BudgetTrack.BAL.Interfaces;
using BudgetTrack.Domain.DTOs.Transactions;
using BudgetTrack.Domain.DTOs.Transactions.Request;
using BudgetTrack.Domain.DTOs.Transactions.Response;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetUserTransactions(Guid userId)
        {
            try
            {
                return Ok(await _userTransactionService.GetUserTransactions(userId));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionRequest AddTransactionRequest)
        {
            TransactionCommonResponse response = new();
            try
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
                if (transaction == null)
                {
                    return BadRequest("User transaction not created successfully");
                }

                response.TransactionId = transaction.TransactionId;
                response.Message = "User transaction created successfully!";

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionRequest updateTransactionRequest)
        {
            TransactionCommonResponse response = new();
            try
            {
                var transaction = await _userTransactionService.GetUserTransaction(updateTransactionRequest.TransactionId);
                if (transaction == null)
                {
                    return NotFound("User transaction details not found!!");
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
                var result = await _userTransactionService.UpdateUserTransaction(userTransactionDTO);
                if (result == null)
                {
                    return BadRequest("User transaction not updated!!");
                }

                response.Message = "User transaction updated sucessfully!!";
                response.TransactionId = transaction.TransactionId;
                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(Guid transactionId)
        {
            TransactionCommonResponse response = new();
            var transaction = await _userTransactionService.GetUserTransaction(transactionId);
            var result = await _userTransactionService.DeleteUserTransaction(transaction);
            response.TransactionId = transactionId;
            response.Message = "User transaction deleted successfully!";
            return Ok(response);
        }
    }
}
