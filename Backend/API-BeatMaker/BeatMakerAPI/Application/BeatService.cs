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
        /// <summary>
        /// Returns a list of beats that belongs to the given user.
        /// </summary>
        /// <param name="userEmail_"></param>
        /// <returns></returns>
        public List<Beat> GetAllBeatsFromUser(string userEmail_)
        {
            return _beatRepo.GetAllBeatsFromUser(_userService.GetUserByEmailOrUsername(userEmail_).Id);
        }
        /// <summary>
        /// Creates a new beat.
        /// </summary>
        /// <param name="beatDTO_"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
            throw new ArgumentException("Failed to make new beat");
        }
        /// <summary>
        /// updates a beat information.
        /// </summary>
        /// <param name="beatDTO_"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
        /// <summary>
        /// Deletes the given beat.
        /// </summary>
        /// <param name="beatDTO_"></param>
        public void DeleteBeat(BeatDTO beatDTO_)
        {
            Beat beat = _mapper.Map<Beat>(beatDTO_);
            beat.UserId = _userService.GetUserByEmailOrUsername(beatDTO_.UserEmail).Id;
            _beatRepo.DeleteBeat(beat);
        }
        /// <summary>
        /// checks if the beat is valid by 
        /// </summary>
        /// <param name="beatString_"></param>
        /// <returns></returns>
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
