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
            for (int i = 0; i < beatString_.Length; i++)
            {
                if (int.TryParse(beatString_[i].ToString(), out number) && i % 2 == 0)
                {
                    if (number < min || number > max)
                    {
                        return false;
                    }
                }
                for (int z = 0; z < invalidChars.Length; z++)
                {
                    if (beatString_[i].Equals(invalidChars[z]))
                    {
                        return false;
                    }
                }
                if (!(i % 3 == 0 && beatString_[i] == ';'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
