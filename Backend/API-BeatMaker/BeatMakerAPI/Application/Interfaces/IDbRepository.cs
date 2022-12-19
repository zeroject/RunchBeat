namespace Application.Interfaces
{
    public interface IDbRepository
    {
        /// <summary>
        /// Deletes old database if there is one and creates a new one.
        /// </summary>
        public void RecreateDb();
    }
}
