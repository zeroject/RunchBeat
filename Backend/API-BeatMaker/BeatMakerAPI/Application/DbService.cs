using Application.Interfaces;

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
