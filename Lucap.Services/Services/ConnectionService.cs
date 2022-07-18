using Lucap.Common.Models;
using Lucap.Repositories.Entities;
using Lucap.Repositories.Interfaces;
using Lucap.Services.Interfaces;

namespace Lucap.Services.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;

        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public void Add(ConnectionModel connectionModel)
        {
            var connection = new Connection()
            {
                Host = connectionModel.Host,
                UserName = connectionModel.UserName,
                Password = connectionModel.Password,
                DbName = connectionModel.DbName
            };
            _connectionRepository.Add(connection);
        }

        public Connection GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Connection> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
