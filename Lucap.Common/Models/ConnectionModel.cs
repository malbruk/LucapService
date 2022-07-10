using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucap.Common.Models
{
    public class ConnectionModel
    {
        public int Id { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? DbName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
        public int? UserId { get; set; }
    }
}
