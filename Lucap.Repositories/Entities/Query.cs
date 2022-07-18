﻿using System;
using System.Collections.Generic;

namespace Lucap.Repositories.Entities
{
    public partial class Query
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ConnectionId { get; set; }
        public string? Query1 { get; set; }

        public virtual Connection? Connection { get; set; }
        public virtual User? User { get; set; }
    }
}
