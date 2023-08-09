namespace ChallengesWebAPI.Challenges.Challenges.SubarrayAverages
{
    public class SubarrayAverages
    {
        public int[] GetAverages(int[] nums, int k) {
            int nLength = nums.Length;
            int[] result = new int[nLength];
            int length = (2 * k + 1);

            //before
            var firstNegatives = k > nLength ? nLength : k;
            for (int i = 0; i < firstNegatives; i++) {
                result[i] = -1;
            }

            var lastCalculable = nLength - k;

            long sumCarry = 0;
            var firstSum = nLength > length ? length : nLength;
            for (int i = 0; i < firstSum; i++)
                sumCarry += nums[i];

            //calculable  
            for (int i = k; i < lastCalculable; i++) {
                result[i] = (int)(sumCarry / length);
                //remove first item from carry sum
                sumCarry -= nums[i - k];
                //add next item for carry sum, or nothing if array out of bounds
                sumCarry += (i + k + 1 >= nLength ? 0 : nums[i + k + 1]);

            }

            //after
            var lastNegatives = k > nLength ? nLength : nLength - k;
            for (int i = lastNegatives; i < nLength; i++) {
                result[i] = -1;
            }

            return result;
        }
    }
}
