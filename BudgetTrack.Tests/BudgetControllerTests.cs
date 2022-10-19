using Microsoft.AspNetCore.Mvc.Testing;
using BudgetTrack.Domain.DTOs.Transactions;
using Newtonsoft.Json;
using BudgetTrack.Domain.DTOs.Auth.Request;
using System.Net.Http.Json;
using BudgetTrack.Tests.Responses;
using System.Net.Http.Headers;

namespace BudgetTrack.Tests
{
    public class BudgetControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public BudgetControllerTests(TestingWebAppFactory<Program> factory)
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task GetAllTransactions_WhenCalled_ReturnsAllUserTransactions()
        {
            await PerformLogin("HGibbs", "password");
            var response = await _client.GetAsync("/api/Budget/GetTransactions?userId=3fa85f64-5717-4562-b3fc-2c963f66afa6");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<List<UserTransactionDTO>>(responseString);
            parsedResponse = parsedResponse.Distinct().ToList();
            Assert.NotNull(parsedResponse);
        }

        [Fact]
        public async Task AddDebitTransaction_WhenCalledWithValidUser_ReturnsSuccess()
        {
            await PerformLogin("HGibbs", "password");
            var addTransation = new AddUserTransactionDTO { TransactionName = "Online", TransactionAmount = 100};
            var response = await _client.PostAsJsonAsync<AddUserTransactionDTO>("/api/Budget/AddDebitTransaction", addTransation);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task AddCreditTransaction_WhenCalledWithValidUser_ReturnsSuccess()
        {
            await PerformLogin("HGibbs", "password");
            var addTransation = new AddUserTransactionDTO { TransactionName = "Online", TransactionAmount = 100 };
            var response = await _client.PostAsJsonAsync<AddUserTransactionDTO>("/api/Budget/AddCreditTransaction", addTransation);
            Assert.True(response.IsSuccessStatusCode);
        }


        [Fact]
        public async Task UpdateTransaction_WhenCalledWithValidTransactionId_ReturnsSuccess()
        {
            await PerformLogin("HGibbs", "password");
            var addTransation = new UserUpdateTransactionDTO {TransactionId = Guid.Parse("3fa85f64-5717-9999-b3fc-2c963f66afa6") ,TransactionName = "Online2", TransactionAmount = 100 };
            var response = await _client.PostAsJsonAsync<UserUpdateTransactionDTO>("/api/Budget/UpdateTransaction", addTransation);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task UpdateTransaction_WhenCalledWithInValidTransactionId_ReturnsFailure()
        {
            await PerformLogin("HGibbs", "password");
            var addTransation = new UserUpdateTransactionDTO { TransactionId = Guid.Parse("3fa85f64-5717-9999-b3f7-2c963f66afa6"), TransactionName = "Online2", TransactionAmount = 100 };
            var response = await _client.PostAsJsonAsync<AddUserTransactionDTO>("/api/Budget/UpdateTransaction", addTransation);
            Assert.Equal("Not Found", response.ReasonPhrase?.ToString());
        }

        [Fact]
        public async Task UpdateTransaction_WhenCalledWithInValidTransactionId_ReturnsFailure2()
        {
            await PerformLogin("HGibbs", "password");
            var addTransation = new UserUpdateTransactionDTO { TransactionId = Guid.Parse("3fa85f64-5717-9999-b3f7-2c963f66afa6"), TransactionName = "Online2", TransactionAmount = 100, Type = 0 };
            var response = await _client.PostAsJsonAsync<AddUserTransactionDTO>("/api/Budget/UpdateTransaction", addTransation);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task DeleteTransaction_WhenCalledWithInValidTransactionId_ReturnsSuccess()
        {
            await PerformLogin("HGibbs", "password");            
            var response = await _client.DeleteAsync("/api/Budget/DeleteTransaction?transactionId=3fa85f64-5717-4562-b3fc-2c963f66afa7");
            Assert.False(response.IsSuccessStatusCode);
        }

        private async Task PerformLogin(string userName, string password)
        {
            var user = new AuthRequest
            {
                Username = userName,
                Password = password
            };

            var res = await _client.PostAsJsonAsync("/api/auth/authenticate", user);
            var responseString = await res.Content.ReadAsStringAsync();
            var parsedResponse = JsonConvert.DeserializeObject<TestTokenResponse>(responseString);
            AddAuthToken(parsedResponse.Token);
        }

        private void AddAuthToken(string? token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
