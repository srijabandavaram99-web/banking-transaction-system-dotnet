using Microsoft.AspNetCore.Mvc;

namespace BankingTransactionSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDashboard()
        {
            var dashboard = new
            {
                ProjectName = "Banking Transaction System",
                TotalAccounts = 2,
                TotalTransactions = 1,
                TotalBankBalance = 8000,
                HighestBalanceAccount = "1001",
                Message = "Dashboard data loaded successfully"
            };

            return Ok(dashboard);
        }
    }
}