using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class BeatRepository : IBeatRepository
    {
        public List<Beat> GetAllBeatsFromUser(int userId_)
        {
            throw new NotImplementedException();
        }

        public Beat CreateNewBeat(Beat weightEntry_)
        {
            throw new NotImplementedException();
        }

        public Beat UpdateBeat(Beat weightEntry_)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeat(int id_)
        {
            throw new NotImplementedException();
        }
    }
}
