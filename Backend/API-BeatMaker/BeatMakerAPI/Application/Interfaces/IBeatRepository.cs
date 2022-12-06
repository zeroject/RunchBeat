using Domain;

namespace Application.Interfaces
{
    public interface IBeatRepository
    {
        public List<Beat> GetAllBeatsFromUser(int userId_);
        public Beat CreateNewBeat(Beat beat_);
        public Beat UpdateBeat(Beat beat_);
        public void DeleteBeat(Beat beat_);
    }
}
