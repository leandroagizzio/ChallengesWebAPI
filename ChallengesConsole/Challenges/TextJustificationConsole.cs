using ChallengesWebAPI.Challenges.Challenges.TextJustification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesConsole.Challenges
{
    public class TextJustificationConsole
    {
        public TextJustificationConsole()
        {
            var justify = new TextJustification();

            Console.WriteLine(
                ("|" + string.Join("|\n|", justify.FullJustify(
                    new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16)
                ) + "|")
            );

            Console.WriteLine(
                ("|" + string.Join("|\n|", justify.FullJustify(
                    new string[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16)
                ) + "|")
            );

            Console.WriteLine(
                ("|" + string.Join("|\n|", justify.FullJustify(
                    new string[] { "Science", "is", "what", "we", "understand",
                        "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything",
                        "else", "we", "do" }, 20)
                ) + "|")
            );
            
        }
    }
}
