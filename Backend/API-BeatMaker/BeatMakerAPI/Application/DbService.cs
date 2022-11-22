using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class DbService : IDbService
    {
        private IDbRepository _dbRepository;

        public DbService(IDbRepository dbRepository_)
        {
            _dbRepository = dbRepository_;
        }

        public void RecreateDb()
        {
            _dbRepository.RecreateDb();
        }
    }
}
