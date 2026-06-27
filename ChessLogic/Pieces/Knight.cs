using System.Drawing;
using ChessLogic.Moves;

namespace ChessLogic.Pieces;

public class Knight : Piece
{
    public override PieceType Type => PieceType.Knight;
    public override Player Color { get; }

    public Knight(Player color)
    {
        Color = color;
    }

    public override Piece Copy()
    {
        Knight copy = new Knight(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }

    private IEnumerable<Position> PotentialPositions(Position from)
    {
        foreach (Direction vDir in new Direction[] { Direction.South, Direction.North })
        {
            foreach (Direction hDir in new Direction[] { Direction.West, Direction.East })
            {
                yield return from + 2 * vDir + hDir;
                yield return from + 2 * hDir + vDir;
            }
        }
    }

    private IEnumerable<Position> MovePositions(Board board, Position from)
    {
        return PotentialPositions(from).Where(pos=> Board.IsInside(pos) && 
                        (board.IsEmpty(pos) || board[pos].Color != Color));
    }

    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePositions(board, from).Select(to=> new NormalMove(from, to));
    }
}