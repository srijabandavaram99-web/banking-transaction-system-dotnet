using Microsoft.AspNetCore.Mvc;

namespace BankingTransactionSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private static List<Account> accounts = new List<Account>
        {
            new Account
            {
                AccountNumber = "1001",
                CustomerName = "Srija Bandavaram",
                AccountType = "Savings",
                Balance = 5000
            },
            new Account
            {
                AccountNumber = "1002",
                CustomerName = "John Smith",
                AccountType = "Checking",
                Balance = 3000
            }
        };

        private static List<TransactionRecord> transactions = new List<TransactionRecord>();

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            return Ok(accounts);
        }

        [HttpGet("{accountNumber}")]
        public IActionResult GetAccountByNumber(string accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                return NotFound("Account not found");
            }

            return Ok(account);
        }

        [HttpPost]
        public IActionResult CreateAccount(Account account)
        {
            var existingAccount = accounts.FirstOrDefault(a => a.AccountNumber == account.AccountNumber);

            if (existingAccount != null)
            {
                return BadRequest("Account number already exists");
            }

            accounts.Add(account);
            return Ok("Account created successfully");
        }

        [HttpPost("transfer")]
        public IActionResult TransferMoney(TransferRequest request)
        {
            if (request.Amount <= 0)
            {
                return BadRequest("Transfer amount must be greater than zero");
            }

            var fromAccount = accounts.FirstOrDefault(a => a.AccountNumber == request.FromAccountNumber);
            var toAccount = accounts.FirstOrDefault(a => a.AccountNumber == request.ToAccountNumber);

            if (fromAccount == null)
            {
                return NotFound("Sender account not found");
            }

            if (toAccount == null)
            {
                return NotFound("Receiver account not found");
            }

            if (fromAccount.AccountNumber == toAccount.AccountNumber)
            {
                return BadRequest("Sender and receiver account cannot be the same");
            }

            if (fromAccount.Balance < request.Amount)
            {
                return BadRequest("Insufficient balance");
            }

            fromAccount.Balance -= request.Amount;
            toAccount.Balance += request.Amount;

            var transaction = new TransactionRecord
            {
                TransactionId = Guid.NewGuid().ToString(),
                FromAccountNumber = request.FromAccountNumber,
                ToAccountNumber = request.ToAccountNumber,
                Amount = request.Amount,
                TransactionType = "Transfer",
                TransactionDate = DateTime.Now,
                Status = "Success"
            };

            transactions.Add(transaction);

            return Ok(new
            {
                Message = "Money transferred successfully",
                Transaction = transaction,
                FromAccountBalance = fromAccount.Balance,
                ToAccountBalance = toAccount.Balance
            });
        }

        [HttpGet("transactions")]
        public IActionResult GetTransactionHistory()
        {
            return Ok(transactions);
        }
    }

    public class Account
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }

    public class TransferRequest
    {
        public string FromAccountNumber { get; set; } = string.Empty;
        public string ToAccountNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }

    public class TransactionRecord
    {
        public string TransactionId { get; set; } = string.Empty;
        public string FromAccountNumber { get; set; } = string.Empty;
        public string ToAccountNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}