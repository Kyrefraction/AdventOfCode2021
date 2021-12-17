using SquidBingo;

var numbers = FileReader.ReadNumbers("Numbers.txt");
var boards = FileReader.ReadBoards("Boards.txt");

var winningScores = new List<int>();
foreach (var number in numbers)
{
    foreach (var board in boards.ToList())
    {
        board.MarkOffNumber(number);
        if (board.HasLine())
        {
            var nonMarkedOffNumbers = board.GetNonMarkedOffNumbers();
            var score = nonMarkedOffNumbers.Sum() * number;

            winningScores.Add(score);
            boards.Remove(board);
        }
    }
}

Console.WriteLine($"First winner has won with score: {winningScores.First()}");
Console.WriteLine($"Last 'winner' has 'won' with score: {winningScores.Last()}");
