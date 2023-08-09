namespace ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList
{
    public class AddTwoNumbersLinkedListChallenge : BaseChallenge<ListNode>
    {
        private readonly AddTwoNumbersLinkedListInput _input;
        private readonly AddTwoNumbersLinkedList addTwo = new AddTwoNumbersLinkedList();

        public AddTwoNumbersLinkedListChallenge() { }

        public AddTwoNumbersLinkedListChallenge(AddTwoNumbersLinkedListInput input) {
            _input = input;
        }
        public override string Link => "https://leetcode.com/problems/add-two-numbers/";

        public override string ChallengeName => "AddTwoNumbersLinkedList";

        public override ListNode Execute() {
            ReturnValue = addTwo.AddTwoNumbers(_input.L1, _input.L2);
            return ReturnValue;
        }

        public override string GetInputToString() {
            string ret = "";

            ret += "l1: " + addTwo.ConvertNodeToString(_input.L1);
            ret += ", l2: " + addTwo.ConvertNodeToString(_input.L2);

            return ret;
        }

        public override string GetOutputToString() {
            return addTwo.ConvertNodeToString(ReturnValue);
        }

        public override bool Validate() {
            base.AddValidation("l1 has node value not between 0 and 9", addTwo.ValidateNode(_input.L1));
            base.AddValidation("l2 has node value not between 0 and 9", addTwo.ValidateNode(_input.L2));

            return base.ValidateList();
        }
    }
}
/*

{
  "l1": {
    "val": 2,
	"next" : {
		 "val": 4,
		 "next" : {
			 "val": 3,
			 "next" : null
		 }
	}
  },
  "l2": {
	"val": 5,
	"next": {
		"val": 6,
		"next": {
			"val": 4,
			"next": null
		}
	}
  }
}

*/