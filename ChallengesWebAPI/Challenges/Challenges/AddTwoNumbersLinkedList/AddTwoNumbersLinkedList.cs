namespace ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList
{
    public class AddTwoNumbersLinkedList
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

            var pointer1 = l1;
            var pointer2 = l2;

            var overTen = 0;

            ListNode result = null; // = new ListNode(0, null);
            ListNode pointerResult = result;

            do {

                var val1 = GetValFromPointer(pointer1);
                var val2 = GetValFromPointer(pointer2);

                var resultSumNodes = SumNodes(val1, val2, overTen);

                overTen = resultSumNodes.overTen;

                if (result == null) {
                    result = resultSumNodes.listNode;
                    pointerResult = result;
                } else {
                    pointerResult.next = resultSumNodes.listNode;
                    pointerResult = pointerResult.next;
                }
                //pointerResult = pointerResult.next;

                pointer1 = GetNextNode(pointer1);
                pointer2 = GetNextNode(pointer2);
            } while (pointer1 != null || pointer2 != null || overTen != 0);


            //do {
            //    Console.WriteLine("result: " + result.val);
            //    result = result.next;
            //} while (result != null);


            return result;
        }

        public ListNode AddTwoNumbersRecursion(ListNode l1, ListNode l2) {

            var result = Recursion(l1, l2, 0);

            //do {
            //    Console.WriteLine("result: " + result.val);
            //    result = result.next;
            //} while (result != null);

            return result;
        }

        private ListNode Recursion(ListNode l1, ListNode l2, int carry) {

            if (l1 == null && l2 == null && carry == 0) {  // end
                return null;
            }

            int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = 0;
            if (sum >= 10) {
                sum -= 10;
                carry = 1;
            }

            var retNode = new ListNode(sum,
                Recursion(
                    l1?.next,
                    l2?.next,
                    carry
                    )
                );

            return retNode;
        }

        private int GetValFromPointer(ListNode listNode) {
            if (listNode == null)
                return 0;
            return listNode.val;
        }

        private ListNode GetNextNode(ListNode listNode) {
            if (listNode != null)
                return listNode.next;
            return listNode;
        }

        private (ListNode listNode, int overTen) SumNodes(int val1, int val2, int over) {
            int sum = val1 + val2 + over;
            int overTen = 0;
            if (sum >= 10) {
                overTen = 1;
                sum -= 10;
            }
            //Console.WriteLine($"val1: {val1}, val2: {val2}, sum: {sum}, over: {overTen}");
            return (new ListNode(sum, null), overTen);
        }

        public bool ValidateNode(ListNode listNode) {
            do {
                //Console.WriteLine("validating: " + listNode.val);
                if (listNode.val < 0 || listNode.val > 9)
                    return false;
                listNode = listNode.next;
            } while (listNode != null);

            return true;
        }

        public string ConvertNodeToString(ListNode listNode) {
            string ret = "";

            if (listNode == null)
                return ret;

            do {
                ret += $"[{listNode.val}] ";
                listNode = listNode.next;
            } while (listNode != null);

            return ret;
        }
    }
}
