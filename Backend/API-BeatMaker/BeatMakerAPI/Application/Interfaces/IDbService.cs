namespace Application.Interfaces
{
    public interface IDbService
    {
        /// <summary>
        /// Deletes old database if there is one and creates a new one.
        /// </summary>
        public void RecreateDb();
    }
}
