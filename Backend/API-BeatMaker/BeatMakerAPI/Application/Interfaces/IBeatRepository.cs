using Domain;

namespace Application.Interfaces
{
    public interface IBeatRepository
    {
        public List<Beat> GetAllBeatsFromUser(int userId_);
        public Beat CreateNewBeat(Beat weightEntry_);
        public Beat UpdateBeat(Beat weightEntry_);
        public void DeleteBeat(int id_);
    }
}
