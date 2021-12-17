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

for (var i = 0; i < winningScores.Count; i++)
{
    if (i == 0)
        Console.WriteLine($"First winner has won with score: {winningScores[i]}");
    if (i == winningScores.Count - 1)
        Console.WriteLine($"Last 'winner' has 'won' with score: {winningScores[i]}");
}
