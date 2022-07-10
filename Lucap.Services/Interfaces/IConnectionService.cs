using Lucap.Common.Models;
using Lucap.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucap.Services.Interfaces
{
    public interface IConnectionService
    {
        List<Connection> GetByUserId(string userId);

        Connection GetById(string id);

        void Add(ConnectionModel connectionModel);
    }
}
