using System;
using System.Collections.Generic;

namespace Lucap.Repositories.Models
{
    public partial class Connection
    {
        public Connection()
        {
            Queries = new HashSet<Query>();
        }

        public int Id { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? DbName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Query> Queries { get; set; }
    }
}
