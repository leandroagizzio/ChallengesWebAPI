using ChallengesWebAPI.Helper;
using ChallengesWebAPI.Interfaces;

namespace ChallengesWebAPI.Challenges
{
    public abstract class BaseChallenge<T> : ISolution<T>
    {
        private readonly IList<string> _errors;
        private readonly IList<IErrorDetail> _validations;
        public BaseChallenge() {
            _errors = HelperFactory.GetStringListInstance();
            _validations = HelperFactory.GetErrorDetailListInstance();
        }
        public IList<string> GetErrors() => _errors;
        protected bool ValidateList() {
            _errors.Clear();

            foreach (var validation in _validations) {
                if (!validation.IsValid)
                    _errors.Add(validation.Message);
            }

            return _errors.Count > 0 ? false : true;
        }

        protected void AddValidation(string message, bool isValid) {
            var errorDetail = HelperFactory.GetErrorDetailInstance();
            errorDetail.IsValid = isValid;
            errorDetail.Message = message;
            _validations.Add(errorDetail);
        }

        protected T ReturnValue { get; set; }
        public abstract string Link { get; }
        public abstract string ChallengeName { get; }

        public abstract T Execute();
        public abstract bool Validate();
        public abstract string GetInputToString();
        public abstract string GetOutputToString();
    }
}
