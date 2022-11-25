using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IBeatService
    {
        public List<Beat> GetAllBeatsFromUser(int userId_);
        public Beat CreateNewBeat(BeatDTO beatDTO_, string userEmail_);
        public Beat UpdateBeat(BeatDTO beatDTO_);
        public void DeleteBeat(int id_);
        public bool IsBeatStringValid(string beatstring_);
    }
}
