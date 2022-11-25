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
            throw new NotImplementedException();
        }
    }
}
