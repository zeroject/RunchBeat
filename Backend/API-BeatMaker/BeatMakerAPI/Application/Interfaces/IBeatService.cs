using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IBeatService
    {
        public List<Beat> GetAllBeatsFromUser(string userEmail_);
        public Beat CreateNewBeat(BeatDTO beatDTO_, string userEmail_);
        public Beat UpdateBeat(BeatDTO beatDTO_, string userEmail_);
        public void DeleteBeat(string userEmail_);
        public bool IsBeatStringValid(string beatstring_);
    }
}
