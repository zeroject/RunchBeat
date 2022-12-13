using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IBeatService
    {
        public List<Beat> GetAllBeatsFromUser(string userEmail_);
        public Beat CreateNewBeat(BeatDTO beatDTO_);
        public Beat UpdateBeat(BeatDTO beatDTO_);
        public void DeleteBeat(BeatDTO beatDTO_);
        public bool IsBeatStringValid(string beatstring_);
    }
}
