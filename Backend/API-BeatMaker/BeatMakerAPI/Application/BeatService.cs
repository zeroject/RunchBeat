using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application
{
    public class BeatService : IBeatService
    {
        public List<Beat> GetAllBeatsFromUser(int userId_)
        {
            throw new NotImplementedException();
        }

        public Beat CreateNewBeat(BeatDTO beat_)
        {
            throw new NotImplementedException();
        }

        public Beat UpdateBeat(BeatDTO beat_)
        {
            throw new NotImplementedException();
        }

        public void DeleteBeat(int id_)
        {
            throw new NotImplementedException();
        }

        public bool IsBeatStringValid(string beatString_)
        {
            throw new NotImplementedException();
        }
    }
}
