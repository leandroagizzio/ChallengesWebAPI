namespace ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs
{
    // https://leetcode.com/problems/equal-row-and-column-pairs/ 
    public class EqualRowColumnPairs
    {
        public int EqualPairs(int[][] grid) { // n x n matrix grid
            List<int[]> rows = new List<int[]>();
            List<int[]> columns = new List<int[]>();

            AddToList(GetRow, rows, grid);
            AddToList(GetColumn, columns, grid);

            int qttEqualPairs = 0;

            foreach (var row in rows) {
                foreach (var col in columns) {
                    qttEqualPairs += Compare(row, col) ? 1 : 0;
                }
            }

            return qttEqualPairs;
        }

        public void AddToList(Func<int[][], int, int[]> func, List<int[]> rows, int[][] grid) {
            for (int i = 0; i < grid.Length; i++) {
                rows.Add(func(grid, i));
            }
        }

        public int[] GetRow(int[][] grid, int row) {
            int[] rowToGetFrom = grid[row];
            return rowToGetFrom;
        }

        public int[] GetColumn(int[][] grid, int column) {
            int size = grid.Length;
            int[] columnToReturn = new int[size];
            for (int i = 0; i < size; i++) {
                columnToReturn[i] = grid[i][column];
            }
            return columnToReturn;
        }

        public bool Compare(int[] a, int[] b) {

            for (int i = 0; i < a.Length; i++) {
                if (a[i] != b[i])
                    return false;
            }

            return true;
        }
    }
}
