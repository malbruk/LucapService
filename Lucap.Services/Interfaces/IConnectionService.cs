using Lucap.Common.Models;
using Lucap.Repositories.Entities;

namespace Lucap.Services.Interfaces
{
    public interface IConnectionService
    {
        List<Connection> GetByUserId(string userId);

        Connection GetById(string id);

        void Add(ConnectionModel connectionModel);
    }
}
