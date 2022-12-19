using Domain;

namespace Application.Interfaces
{
    public interface IBeatRepository
    {
        /// <summary>
        /// Returns a list of all beats by a user givin be ID
        /// </summary>
        /// <param name="userId_"></param>
        /// <returns></returns>
        public List<Beat> GetAllBeatsFromUser(int userId_);
        /// <summary>
        /// Creates a new beat
        /// </summary>
        /// <param name="beat_"></param>
        /// <returns></returns>
        public Beat CreateNewBeat(Beat beat_);
        /// <summary>
        /// Updates a beat with new infomation
        /// </summary>
        /// <param name="beat_"></param>
        /// <returns></returns>
        public Beat UpdateBeat(Beat beat_);
        /// <summary>
        /// Deletes a beat.
        /// </summary>
        /// <param name="beat_"></param>
        public void DeleteBeat(Beat beat_);
    }
}
