using Microsoft.AspNetCore.Mvc;

namespace BankingTransactionSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatementsController : ControllerBase
    {
        [HttpGet("{accountNumber}")]
        public IActionResult GetStatement(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return BadRequest("Account number is required");
            }

            var statement = new BankStatement
            {
                AccountNumber = accountNumber,
                CustomerName = accountNumber == "1001" ? "Srija Bandavaram" : "John Smith",
                AccountType = accountNumber == "1001" ? "Savings" : "Checking",
                CurrentBalance = accountNumber == "1001" ? 4500 : 3500,
                StatementDate = DateTime.Now,
                Transactions = new List<StatementTransaction>
                {
                    new StatementTransaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        TransactionType = "Debit",
                        Description = "Transfer to account 1002",
                        Amount = 500,
                        TransactionDate = DateTime.Now.AddDays(-1)
                    },
                    new StatementTransaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        TransactionType = "Credit",
                        Description = "Salary deposit",
                        Amount = 2000,
                        TransactionDate = DateTime.Now.AddDays(-3)
                    }
                }
            };

            return Ok(statement);
        }
    }

    public class BankStatement
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal CurrentBalance { get; set; }
        public DateTime StatementDate { get; set; }
        public List<StatementTransaction> Transactions { get; set; } = new List<StatementTransaction>();
    }

    public class StatementTransaction
    {
        public string TransactionId { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}