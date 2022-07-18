using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NETCore.MailKit.Core;
using Lucap.Web.EmailTemplates;

namespace Lucap.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnyController : ControllerBase
    {
        private readonly EmailManager _emailManager;

        public AnyController(EmailManager emailManager)
        {
            _emailManager = emailManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success");
        }

        [HttpPost]
        public IActionResult Post()
        {
            _emailManager.SendEmail("malka2039@gmail.com", "מלכה");
            return Ok();
        }
    }
}
