using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application
{
    public class BeatService : IBeatService
    {
        Dictionary<string, int> _cheksumDictionary = new Dictionary<string, int>();
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

            _cheksumDictionary.Add("A", 1);
            _cheksumDictionary.Add("B", 2);
            _cheksumDictionary.Add("C", 3);
            _cheksumDictionary.Add("D", 4);
            _cheksumDictionary.Add("E", 5);
            _cheksumDictionary.Add("F", 6);
            _cheksumDictionary.Add("G", 7);
            _cheksumDictionary.Add("H", 8);
            _cheksumDictionary.Add("I", 9);
            _cheksumDictionary.Add("J", 10);
            _cheksumDictionary.Add("K", 11);
            _cheksumDictionary.Add("L", 12);
            _cheksumDictionary.Add("M", 13);
            _cheksumDictionary.Add("N", 14);
            _cheksumDictionary.Add("O", 15);
            _cheksumDictionary.Add("P", 16);
            _cheksumDictionary.Add("Q", 17);
            _cheksumDictionary.Add("R", 18);
            _cheksumDictionary.Add("S", 19);
            _cheksumDictionary.Add("T", 20);
            _cheksumDictionary.Add("U", 21);
            _cheksumDictionary.Add("V", 22);
            _cheksumDictionary.Add("W", 23);
            _cheksumDictionary.Add("X", 24);
            _cheksumDictionary.Add("Y", 25);
            _cheksumDictionary.Add("Z", 26);
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

        public void DeleteBeat(string userEmail_)
        {
            _beatRepo.DeleteBeat(_userService.GetUserByEmailOrUsername(userEmail_).Id);
        }

        public bool IsBeatStringValid(string beatString_)
        {
            int cheksumCheck = 0;
            string beatSequence = beatString_.Replace(";", "");
            string[] cheksumString = beatSequence.Split(":");
            string beatString = cheksumString[0];

            if (beatString_.Length == 0) { return false; }
            for (int i = 0; i < beatString.Length; i++)
            {
                if (!Char.IsDigit(beatString[i]))
                {
                    cheksumCheck = _cheksumDictionary[beatString[i].ToString()] + cheksumCheck;
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
