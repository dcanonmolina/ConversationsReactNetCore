using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Twilio.Jwt.AccessToken;

namespace conversations_demo_react.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationsController : ControllerBase
    {
        private readonly ILogger<ConversationsController> _logger;

        public ConversationsController(ILogger<ConversationsController> logger)
        {
            _logger = logger;
        }

       [HttpGet("token")]
        public IActionResult GetToken(){

            String AccountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            String ApiKey = "SKXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            String ApiSecret = "YYYYYYYYYYYYYYYYYYYYYYYYYYY";
            String ChatService = "ISXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            String identity = HttpContext.Request.Query["identity"].ToString() ?? "testUser";

            var grant = new ChatGrant
            {
            ServiceSid = ChatService
            };

            var token = new Token(AccountSid,
                         ApiKey,
                         ApiSecret,
                         identity ?? Guid.NewGuid().ToString(),
                         grants: new HashSet<IGrant> { grant }).ToJwt();

            return new JsonResult(new { token = token });
        }

       
    }
}
