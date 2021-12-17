using SquidBingo;

var numbers = FileReader.ReadNumbers("Numbers.txt");
var boards = FileReader.ReadBoards("Boards.txt");

foreach (var number in numbers)
{
    foreach (var board in boards)
    {
        board.MarkOffNumber(number);
        if (board.HasLine())
        {
            var nonMarkedOffNumbers = board.GetNonMarkedOffNumbers();
            var score = nonMarkedOffNumbers.Sum() * number;
            Console.WriteLine($"Winner has got score: {score}");
            return;
        }
    }
}
