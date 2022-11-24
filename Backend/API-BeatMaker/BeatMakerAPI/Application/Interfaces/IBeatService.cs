using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IBeatService
    {
        public List<Beat> GetAllBeatsFromUser(int userId_);
        public Beat CreateNewBeat(BeatDTO beat_);
        public Beat UpdateBeat(BeatDTO beat_);
        public void DeleteBeat(int id_);
    }
}
