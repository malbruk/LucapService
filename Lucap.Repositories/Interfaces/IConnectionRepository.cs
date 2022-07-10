using Lucap.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucap.Repositories.Interfaces
{
    public interface IConnectionRepository
    {
        List<Connection> GetAll();

        Connection GetById(int id);

        void Update(Connection connection);

        void Add (Connection connection);

        void Delete(Connection connection);
    }
}
