namespace ChallengesWebAPI.Challenges.Challenges.SubarrayAverages
{
    public class SubarrayAveragesChallenge : BaseChallenge<int[]>
    {
        private readonly SubarrayAveragesInput _input;

        public SubarrayAveragesChallenge() { }
        public SubarrayAveragesChallenge(SubarrayAveragesInput input) {
            _input = input;
        }
        public override string ChallengeName => "SubarrayAverages";

        public override string Link => "https://leetcode.com/problems/k-radius-subarray-averages";

        public override int[] Execute() {
            ReturnValue = new SubarrayAverages().GetAverages(_input.nums, _input.k);
            return ReturnValue;
        }

        public override string GetInputToString() {
            return $"nums [ {string.Join(", ", _input.nums)} ] - k [ {_input.k} ]";
        }

        public override string GetOutputToString() {
            return $"[ {string.Join(", ", ReturnValue)} ]";
        }

        public override bool Validate() {
            //0 <= nums[i], k <= 105

            AddValidation("k has to be positive", _input.k >= 0);
            AddValidation("k has to be less than or equal to 100 000", _input.k <= 100_000);

            AddValidation("size of nums has to be >= 1 and <= 100 000",
                    _input.nums.Length >= 1 && _input.nums.Length <= 100_000);

            AddValidation("values inside nums have to be between (including) 0 to 100 000",
                new Func<bool>(() => {
                    foreach (var num in _input.nums) {
                        if (num < 0 || num > 100_000)
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
