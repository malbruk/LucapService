using System;
using System.Collections.Generic;

namespace Lucap.Repositories.Entities
{
    public partial class Image
    {
        public int Id { get; set; }
        public byte[]? Content { get; set; }
        public string? Url { get; set; }
    }
}
