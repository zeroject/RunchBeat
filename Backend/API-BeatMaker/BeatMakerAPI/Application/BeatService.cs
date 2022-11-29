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

        public BeatService(IBeatRepository repo, IMapper mapper, IValidator<BeatDTO> validator, IUserService userService)
        {
            _mapper = mapper;
            _beatRepo = repo;
            _validator = validator;
            _userService = userService;
        }

        public List<Beat> GetAllBeatsFromUser(string userEmail_)
        {
            return _beatRepo.GetAllBeatsFromUser(_userService.GetUserByEmailOrUsername(userEmail_).Id);
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

        public Beat UpdateBeat(BeatDTO beatDTO_, string userEmail_)
        {
            if (IsBeatStringValid(beatDTO_.BeatString))
            {
                var validation = _validator.Validate(beatDTO_);
                if (!validation.IsValid)
                {
                    throw new ValidationException(validation.ToString());
                }
                Beat editedBeat = _mapper.Map<Beat>(beatDTO_);
                editedBeat.UserId = _userService.GetUserByEmailOrUsername(userEmail_).Id;
                return _beatRepo.UpdateBeat(editedBeat);
            }
            throw new Exception("Save data corrupted");
        }

        public void DeleteBeat(BeatDTO beatDTO_, string userEmail_)
        {
            Beat beat = _mapper.Map<Beat>(beatDTO_);
            beat.UserId = _userService.GetUserByEmailOrUsername(userEmail_).Id;
            _beatRepo.DeleteBeat(beat);
        }

        public bool IsBeatStringValid(string beatString_)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Span<char> alpahbetSpan = new Span<char>(alphabet);

            int cheksumCheck = 0;
            string beatSequence = beatString_.Replace(";", "");
            string[] cheksumString = beatSequence.Split(":");
            string beatString = cheksumString[0];

            if (beatString_.Length == 0) { return false; }
            for (int i = 0; i < beatString.Length; i++)
            {
                if (!Char.IsDigit(beatString[i]))
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (beatString[i] == alphabet[j])
                        {
                            cheksumCheck = j+1 + cheksumCheck;
                        }
                    }
                }
                else
                {
                    cheksumCheck = int.Parse(beatString[i].ToString()) + cheksumCheck;
                }
            }

            if (cheksumCheck.Equals(int.Parse(cheksumString[1])))
            {
                return true;
            }
            return false;
        }
    }
}
