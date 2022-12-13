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
        private IUserService _userService;

        public BeatService(IBeatRepository repo_, IMapper mapper_, IValidator<BeatDTO> validator_, IUserService userService_)
        {
            _mapper = mapper_;
            _beatRepo = repo_;
            _validator = validator_;
            _userService = userService_;
        }

        public List<Beat> GetAllBeatsFromUser(string userEmail_)
        {
            return _beatRepo.GetAllBeatsFromUser(_userService.GetUserByEmailOrUsername(userEmail_).Id);
        }

        public Beat CreateNewBeat(BeatDTO beatDTO_)
        {
            if (IsBeatStringValid(beatDTO_.BeatString))
            {
                var validation = _validator.Validate(beatDTO_);
                if (!validation.IsValid)
                {
                    throw new ValidationException(validation.ToString());
                }
                Beat editedBeat = _mapper.Map<Beat>(beatDTO_);
                editedBeat.UserId = _userService.GetUserByEmailOrUsername(beatDTO_.UserEmail).Id;
                return _beatRepo.CreateNewBeat(editedBeat);
            }
            throw new ArgumentException("Save data corrupted");
        }

        public Beat UpdateBeat(BeatDTO beatDTO_)
        {
            if (IsBeatStringValid(beatDTO_.BeatString))
            {
                var validation = _validator.Validate(beatDTO_);
                if (!validation.IsValid)
                {
                    throw new ValidationException(validation.ToString());
                }
                Beat editedBeat = _mapper.Map<Beat>(beatDTO_);
                editedBeat.UserId = _userService.GetUserByEmailOrUsername(beatDTO_.UserEmail).Id;
                return _beatRepo.UpdateBeat(editedBeat);
            }
            throw new ArgumentException("Save data corrupted");
        }

        public void DeleteBeat(BeatDTO beatDTO_)
        {
            Beat beat = _mapper.Map<Beat>(beatDTO_);
            beat.UserId = _userService.GetUserByEmailOrUsername(beatDTO_.UserEmail).Id;
            _beatRepo.DeleteBeat(beat);
        }

        public bool IsBeatStringValid(string beatString_)
        {
            bool result = false;
            string[] checkString = beatString_.Split(";");
            checkString = checkString.Take(checkString.Count() - 1).ToArray();
            foreach (string checkString2 in checkString)
            {
                checkString2.Replace(";", "");
            }
            foreach (string checkString3 in checkString)
            {
                try
                {
                    int numberString = int.Parse(checkString3[0].ToString());
                }
                catch
                {
                    return false;
                }
                if (checkString3.Length <= 3 && checkString3.Length != 1)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
