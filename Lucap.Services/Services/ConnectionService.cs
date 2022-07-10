using Lucap.Common.Models;
using Lucap.Repositories.Interfaces;
using Lucap.Repositories.Models;
using Lucap.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
