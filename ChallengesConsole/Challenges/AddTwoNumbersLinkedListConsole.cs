using ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesConsole.Challenges
{
    public class AddTwoNumbersLinkedListConsole
    {
        public AddTwoNumbersLinkedListConsole() {
            // TEST CASE 1 - return 807
            ListNode t1_l1_3 = new ListNode(3, null);
            ListNode t1_l1_2 = new ListNode(4, t1_l1_3);
            ListNode t1_l1 = new ListNode(2, t1_l1_2);

            ListNode t1_l2_3 = new ListNode(4, null);
            ListNode t1_l2_2 = new ListNode(6, t1_l2_3);
            ListNode t1_l2 = new ListNode(5, t1_l2_2);

            //      1 2 3 4 5 6 7
            //l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
            // TEST CASE 3 - return 10009998
            ListNode t3_l1_7 = new ListNode(9, null);
            ListNode t3_l1_6 = new ListNode(9, t3_l1_7);
            ListNode t3_l1_5 = new ListNode(9, t3_l1_6);
            ListNode t3_l1_4 = new ListNode(9, t3_l1_5);
            ListNode t3_l1_3 = new ListNode(9, t3_l1_4);
            ListNode t3_l1_2 = new ListNode(9, t3_l1_3);
            ListNode t3_l1 = new ListNode(9, t3_l1_2);

            ListNode t3_l2_4 = new ListNode(9, null);
            ListNode t3_l2_3 = new ListNode(9, t3_l2_4);
            ListNode t3_l2_2 = new ListNode(9, t3_l2_3);
            ListNode t3_l2 = new ListNode(9, t3_l2_2);

            var addTwo = new AddTwoNumbersLinkedList();

            //Console.WriteLine("validate l1: " + addTwo.ValidateNode(l1));
            //Console.WriteLine("validate l2: " + addTwo.ValidateNode(l2));

            // TEST CASE 2 - return 0
            ListNode t2_l1 = new ListNode(0, null);
            ListNode t2_l2 = new ListNode(0, null);

            // TEST CASE 2.1 - return 17
            ListNode t21_l1 = new ListNode(8, null);
            ListNode t21_l2 = new ListNode(9, null);

            //addTwo.AddTwoNumbers(new ListNode(0, null), new ListNode(0, null));

            //addTwo.AddTwoNumbers(new ListNode(8, null), new ListNode(9, null));

            // TEST CASE 4 - return 81
            ListNode t4_l1_2 = new ListNode(8, null);
            ListNode t4_l1 = new ListNode(1, t4_l1_2);

            ListNode t4_l2 = new ListNode(0, null);

            //
            var l1 = t21_l1;
            var l2 = t21_l2;

            //addTwo.AddTwoNumbers(l1, l2);

            addTwo.AddTwoNumbersRecursion(l1, l2);

        }

    }
}
