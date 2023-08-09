namespace ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs
{
    public class EqualRowColumnPairsChallenge : BaseChallenge<int>
    {
        private readonly EqualRowColumnPairsInput _input;

        public EqualRowColumnPairsChallenge() {

        }

        public EqualRowColumnPairsChallenge(EqualRowColumnPairsInput input) {
            _input = input;
        }

        public override string Link { get; }
         = "https://leetcode.com/problems/equal-row-and-column-pairs/ ";

        public override string ChallengeName => "EqualRowColumnPairs";

        public override int Execute() {
            ReturnValue = new EqualRowColumnPairs().EqualPairs(_input.Grid);
            return ReturnValue;
        }

        public override string GetInputToString() {
            var inputString = "";
            foreach (var row in _input.Grid) {
                inputString += $"[ {string.Join(", ", row)} ] ";
            }
            return inputString;
        }

        public override string GetOutputToString() {
            return $"int: {ReturnValue}";
        }

        public override bool Validate() {

            //base.AddValidation("it should be a square nxn", _input.Grid.Length == _input.Grid[0].Length);
            base.AddValidation("it should be a square nxn",
                (
                    new Func<bool>(() => {
                        var squareValidation = true;
                        foreach (var line in _input.Grid) {
                            if (_input.Grid.Length != line.Length)
                                squareValidation = false;
                        }
                        return squareValidation;
                    })()
                )
            );

            base.AddValidation($"n {_input.Grid.Length} should be smaller than 200", _input.Grid.Length < 200);

            base.AddValidation($"n {_input.Grid.Length} should bigger than 1", _input.Grid.Length > 1);

            return ValidateList();
        }
    }
}

/*
 {
  "grid": [
    [ 3, 2, 1 ], 
    [ 1, 7, 6 ], 
    [ 2, 7, 7 ]
  ]
}


{
  "grid": [
    [ 3, 1, 2, 2 ], 
    [ 1, 4, 4, 5 ], 
    [ 2, 4, 2, 2 ], 
    [ 2, 4, 2, 2 ]
  ]
}

*/

