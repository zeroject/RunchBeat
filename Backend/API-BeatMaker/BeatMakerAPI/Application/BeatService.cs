using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application
{
    public class BeatService : IBeatService
    {
        private IBeatRepository _beatRepo;
        private IMapper _mapper;
        private IValidator<BeatDTO> _validator;

        public BeatService(IBeatRepository repo, IMapper mapper, IValidator<BeatDTO> validator)
        {
            _mapper = mapper;
            _beatRepo = repo;
            _validator = validator;
        }

        public List<Beat> GetAllBeatsFromUser(int userId_)
        {
            return _beatRepo.GetAllBeatsFromUser(userId_);
        }

        public Beat CreateNewBeat(BeatDTO beatDTO_, string userEmail_)
        {

            if (IsBeatStringValid(beatDTO_.BeatString)) {
                var validation = _validator.Validate(beatDTO_);
                if (!validation.IsValid)
                {
                    throw new ValidationException(validation.ToString());
                }
                Beat editedBeat = _mapper.Map<Beat>(beatDTO_);
                editedBeat.UserId = 1;
                return _beatRepo.CreateNewBeat(editedBeat);
            }
            throw new Exception("Save data corrupted");
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
            int number = 0;
            int min = 1;
            int max = 32;
            char[] invalidChars = { 'æ', 'ø', 'å', '.', ',', ':', '´', '!', '"', '#', '¤', '¤', '%', '&', '/', '(', ')', '='};

            if (beatString_.Length < 3) { return false; }
            for (int i = 0; i < beatString_.Length; i++)
            {
                if (int.TryParse(beatString_[i].ToString(), out number))
                {
                    if (number < min || number > max)
                    {
                        return false;
                    }
                }
                for (int z = 0; z < invalidChars.Length; z++ )
                {
                    if (beatString_[i].Equals(invalidChars[z]) && !int.TryParse(beatString_[i + 1].ToString(), out number))
                    {
                        return false;
                    }
                }
                if (!(i == 0))
                {
                    if (!(int.TryParse(beatString_[i - 1].ToString(), out number) && beatString_[i].ToString().Contains(";")))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
