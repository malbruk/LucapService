using System;
using System.Collections.Generic;

namespace Lucap.Repositories.Entities
{
    public partial class Sample
    {
        public int Id { get; set; }
        public int? ConnectionId { get; set; }

        public virtual Connection? Connection { get; set; }
    }
}
