namespace ChallengesWebAPI.Challenges.Challenges.TextJustification
{
    public class TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth) {
            var returnList = new List<string>() { words[0] };

            //separate per line
            for (int i = 1; i < words.Length; i++) {
                AddList(returnList, words[i], maxWidth);
            }

            //justify
            for (int i = 0; i < returnList.Count - 1; i++) {
                if (returnList[i].Length != maxWidth)
                    JustifyLine(returnList, i, maxWidth);
            }

            //left last
            while (returnList[returnList.Count - 1].Length < maxWidth) returnList[returnList.Count - 1] += " ";

            return returnList;
        }

        private bool JustifyLine(IList<string> list, int line, int maxWidth) {
            var wordsSplit = list[line].Split(" ");
            var wordsQtt = wordsSplit.Length;
            list[line] = wordsSplit[0];
            if (wordsQtt == 1) {
                //lista[line] = wordsSplit[0];
                while (list[line].Length < maxWidth) list[line] += " ";
                return true;
            }
            if (wordsQtt == 2) {
                //lista[line] = wordsSplit[0];
                while (list[line].Length < maxWidth - wordsSplit[1].Length) list[line] += " ";
                list[line] += wordsSplit[1];
                return true;
            }
            var holes = wordsQtt - 1;
            var spaceTopUp = maxWidth - string.Join("", wordsSplit).Length;
            //lista[line] += $"({spaceTopUp})";
            var spaces = new string[holes];
            int pointerSpaces = 0;
            while (spaceTopUp-- > 0) {
                pointerSpaces = pointerSpaces >= spaces.Length ? 0 : pointerSpaces;
                spaces[pointerSpaces] += " ";
                pointerSpaces++;
            }
            pointerSpaces = 0;
            for (int i = 1; i < wordsSplit.Length; i++) {
                if (pointerSpaces < spaces.Length) {
                    list[line] += spaces[pointerSpaces++];
                }
                list[line] += wordsSplit[i];
            }

            return true;
        }

        private void AddList(IList<string> lista, string word, int maxWidth) {
            var length = lista[lista.Count - 1].Length;
            var wordLength = word.Length;
            if ((length + wordLength + 1) <= maxWidth) {
                lista[lista.Count - 1] += " " + word;
            } else {
                lista.Add(word);
            }
        }
    }
}
