using System.Drawing;
using ChessLogic.Moves;

namespace ChessLogic.Pieces;

public class King : Piece
{
    public override PieceType Type => PieceType.King;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[]
    {
        Direction.West,
        Direction.East,
        Direction.South,
        Direction.North,
        Direction.SouthWest,
        Direction.SouthEast,
        Direction.NorthEast,
        Direction.NorthWest
    };

    public King(Player color)
    {
        Color = color;
    }

    public override Piece Copy()
    {
        King copy = new King(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }

    private IEnumerable<Position> MovePositions(Board board, Position from)
    {
        foreach (Direction dir in dirs)
        {
            Position to = from + dir;

            if (!Board.IsInside(to))
            {
                continue;
            }

            if (board.IsEmpty(to) || board[to].Color != Color)
            {
                yield return to;
            }
        }
    }

    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        foreach (Position to in MovePositions(board, from))
        {
            yield return new NormalMove(from, to);
        }
    }
}