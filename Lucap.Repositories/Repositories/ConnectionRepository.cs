using Lucap.Repositories.Interfaces;
using Lucap.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucap.Repositories.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly LucapDBContext _context;

        public ConnectionRepository(LucapDBContext context)
        {
            _context = context;
        }

        public void Add(Connection connection)
        {
            _context.Connections.Add(connection);
        }

        public void Delete(Connection connection)
        {
            _context.Connections.Remove(connection);
        }

        public Connection GetById(int id)
        {
            return _context.Connections.First(c => c.Id == id);
        }

        public List<Connection> GetAll()
        {
            return _context.Connections.ToList();
        }

        public void Update(Connection connection)
        {
            _context.Connections.Update(connection);
        }
    }
}
