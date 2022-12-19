using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IBeatService
    {
        /// <summary>
        /// Returns a list of beats of that user given by users Email
        /// </summary>
        /// <param name="userEmail_"></param>
        /// <returns></returns>
        public List<Beat> GetAllBeatsFromUser(string userEmail_);
        /// <summary>
        /// Creates A new beat
        /// </summary>
        /// <param name="beatDTO_"></param>
        /// <returns></returns>
        public Beat CreateNewBeat(BeatDTO beatDTO_);
        /// <summary>
        /// Updates a beat with new infomation given by the user
        /// </summary>
        /// <param name="beatDTO_"></param>
        /// <returns></returns>
        public Beat UpdateBeat(BeatDTO beatDTO_);
        /// <summary>
        /// Deletes a beat.
        /// </summary>
        /// <param name="beatDTO_"></param>
        public void DeleteBeat(BeatDTO beatDTO_);
        /// <summary>
        /// Tests if the beat string is valid.
        /// </summary>
        /// <param name="beatstring_"></param>
        /// <returns></returns>
        public bool IsBeatStringValid(string beatstring_);
    }
}
