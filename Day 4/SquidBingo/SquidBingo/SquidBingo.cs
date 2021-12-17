using SquidBingo;

var numbers = FileReader.ReadNumbers("Numbers.txt");
var boards = FileReader.ReadBoards("Boards.txt");

var winningScore = new List<int>();
foreach (var number in numbers)
{
    foreach (var board in boards.ToList())
    {
        board.MarkOffNumber(number);
        if (board.HasLine())
        {
            var nonMarkedOffNumbers = board.GetNonMarkedOffNumbers();
            var score = nonMarkedOffNumbers.Sum() * number;
            
            winningScore.Add(score);
            boards.Remove(board);
        }
    }
}

for (var i = 0; i < winningScore.Count; i++)
{
    if (i == 0)
        Console.WriteLine($"First winner has won with score: {winningScore[i]}");
    if (i == winningScore.Count - 1)
        Console.WriteLine($"Last winner has 'won' with score: {winningScore[i]}");
}
