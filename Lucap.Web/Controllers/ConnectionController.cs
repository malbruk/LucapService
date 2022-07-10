using Lucap.Common.Models;
using Lucap.Repositories.Models;
using Lucap.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lucap.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IConnectionService _connectionService;

        public ConnectionController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Connection>> GetConnecions()
        {
            var connections = _connectionService.GetByUserId("");

            return connections;
        }

        [HttpPost]
        public ActionResult AddConnecion(ConnectionModel model)
        {
            _connectionService.Add(model);
            return Ok();
        }
    }
}
