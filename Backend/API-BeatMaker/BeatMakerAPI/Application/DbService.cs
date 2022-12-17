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

        /// <summary>
        /// Deletes the Database if there is one, then creates a new one.
        /// </summary>
        public void RecreateDb()
        {
            _dbRepository.RecreateDb();
        }
    }
}
