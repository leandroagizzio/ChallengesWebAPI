namespace ChallengesWebAPI.Challenges.Challenges.TextJustification
{
    public class TextJustificationChallenge : BaseChallenge<IList<string>>
    {
        private readonly TextJustificationInput _input;

        public TextJustificationChallenge() {  }

        public TextJustificationChallenge(TextJustificationInput input)
        {
            _input = input;
        }
        public override string Link => "TextJustification";

        public override string ChallengeName => "https://leetcode.com/problems/text-justification/";

        public override IList<string> Execute() {
            ReturnValue = new TextJustification().FullJustify(_input.words, _input.maxWidth);
            return ReturnValue;
        }

        public override string GetInputToString() {
            return $"words [{string.Join(", ", _input.words)}] - maxWidth [{_input.maxWidth}]";
        }

        public override string GetOutputToString() {
            return $"[ {string.Join(", ", ReturnValue)} ]";
        }

        public override bool Validate() {
            //1 <= maxWidth <= 100
            //words[i].length <= maxWidth

            AddValidation("Max width has to be between 1 and 100", (_input.maxWidth >= 1 && _input.maxWidth <= 100));

            AddValidation("Each word length has to be smaller or equal to max width", 
                new Func<bool>(() => {
                    foreach (var word in _input.words) {
                        if (word.Length > _input.maxWidth)
                            return false;
                    }
                    return true;
                }
                )()
            );

            return ValidateList();
        }
    }
}
