using System;
using System.Collections.Generic;

namespace Lucap.Repositories.Models
{
    public partial class User
    {
        public User()
        {
            Connections = new HashSet<Connection>();
            Queries = new HashSet<Query>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Connection> Connections { get; set; }
        public virtual ICollection<Query> Queries { get; set; }
    }
}
