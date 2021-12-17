using SquidBingo;

public class Board
{
    private readonly BoardNumber[,] _boardNumbers;

    public Board(BoardNumber[,] boardNumbers)
    {
        _boardNumbers = boardNumbers;
    }

    public List<int> GetNonMarkedOffNumbers()
    {
        var nonMarkedOffNumbers = new List<int>();
        for (var i = 0; i < _boardNumbers.GetLength(0); i++)
        {
            for (var j = 0; j < _boardNumbers.GetLength(1); j++)
            {
                if (!_boardNumbers[i, j].MarkedOff)
                    nonMarkedOffNumbers.Add(_boardNumbers[i, j].Number);
            }
        }

        return nonMarkedOffNumbers;
    }

    public bool HasLine()
    {
        return HasHorizontalLine() || HasVerticalLine();
    }

    public bool HasHorizontalLine()
    {
        for (var row = 0; row < _boardNumbers.GetLength(0); row++)
        {
            var isWinning = true;
            for (var col = 0; col < _boardNumbers.GetLength(1); col++)
            {
                var boardNumber = _boardNumbers[col, row];
                if (boardNumber.MarkedOff)
                    continue;

                isWinning = false;
            }

            if (isWinning)
                return isWinning;
        }

        return false;
    }

    public bool HasVerticalLine()
    {
        for (var row = 0; row< _boardNumbers.GetLength(0); row++)
        {
            var isWinning = true;

            for (var col = 0; col < _boardNumbers.GetLength(1); col++)
            {
                var boardNumber = _boardNumbers[row, col];
                if (boardNumber.MarkedOff)
                    continue;

                isWinning = false;
            }

            if (isWinning)
                return isWinning;
        }

        return false;
    }

    public void MarkOffNumber(int number)
    {
        for (var row = 0; row < _boardNumbers.GetLength(0); row++)
        {
            for (var column = 0; column < _boardNumbers.GetLength(1); column++)
            {
                var boardNumber = _boardNumbers[row, column];
                if (boardNumber.Number == number)
                {
                    boardNumber.MarkedOff = true;
                }
            }
        }
    }

}