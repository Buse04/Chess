using System.Drawing;
using ChessLogic.Moves;
namespace ChessLogic.Pieces;

public class Queen : Piece
{
    public override PieceType Type => PieceType.Queen;
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

    public Queen(Player color)
    {
        Color = color;
    }

    public override Piece Copy()
    {
        Queen copy = new Queen(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePosInDırs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
}