using Microsoft.AspNetCore.Mvc;

namespace BankingTransactionSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private static List<AuditLog> auditLogs = new List<AuditLog>
        {
            new AuditLog
            {
                Id = 1,
                Action = "Account Created",
                Description = "Savings account 1001 created for Srija Bandavaram",
                PerformedBy = "System",
                CreatedDate = DateTime.Now
            },
            new AuditLog
            {
                Id = 2,
                Action = "Money Transfer",
                Description = "Amount 500 transferred from account 1001 to account 1002",
                PerformedBy = "Customer",
                CreatedDate = DateTime.Now
            }
        };

        [HttpGet]
        public IActionResult GetAuditLogs()
        {
            return Ok(auditLogs);
        }

        [HttpPost]
        public IActionResult AddAuditLog(AuditLog auditLog)
        {
            if (string.IsNullOrWhiteSpace(auditLog.Action))
            {
                return BadRequest("Action is required");
            }

            if (string.IsNullOrWhiteSpace(auditLog.Description))
            {
                return BadRequest("Description is required");
            }

            auditLog.Id = auditLogs.Count + 1;
            auditLog.CreatedDate = DateTime.Now;

            auditLogs.Add(auditLog);

            return Ok(new
            {
                Message = "Audit log added successfully",
                AuditLog = auditLog
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAuditLogById(int id)
        {
            var auditLog = auditLogs.FirstOrDefault(x => x.Id == id);

            if (auditLog == null)
            {
                return NotFound("Audit log not found");
            }

            return Ok(auditLog);
        }
    }

    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}