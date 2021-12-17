namespace SquidBingo
{
    public static class FileReader
    {
        public static List<int> ReadNumbers(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var numbers = lines.First().Split(',');
            return numbers.Select(int.Parse).ToList();
        }

        public static List<Board> ReadBoards(string fileName)
        {
            var input = File.ReadAllText(fileName);
            var bingoBoards = new List<Board>();
            var boards = input.Split($"{Environment.NewLine}{Environment.NewLine}");
            foreach (var board in boards)
            {
                var bingoBoard = new BoardNumber[5, 5];
                var rows = board.Split(Environment.NewLine);
                for (var i = 0; i < rows.Length; i++)
                {
                    var columns = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (var j = 0; j < columns.Length; j++)
                    {
                        bingoBoard[i, j] = new BoardNumber
                        {
                            Number = int.Parse(columns[j]),
                            MarkedOff = false
                        };
                    }
                }
                bingoBoards.Add(new Board(bingoBoard));
            }

            return bingoBoards;
        }
    }
}
