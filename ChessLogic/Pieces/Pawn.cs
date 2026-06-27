namespace ChessLogic.Pieces;
using ChessLogic.Moves;

public class Pawn : Piece
{
    public override PieceType Type => PieceType.Pawn;
    public override Player Color { get; }
    private readonly Direction forward;

    public Pawn(Player color)
    {
        Color = color;

        if (color == Player.White)
        {
            forward = Direction.North;
        }
        else if (color == Player.Black)
        {
            forward = Direction.South;
        }
    }

    public override Piece Copy()
    {
        Pawn copy = new Pawn(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }

    private static bool CanMoveTo(Board board, Position pos)
    {
        return Board.IsInside(pos) && board.IsEmpty(pos);
    }

    private bool CanCaptureAt(Board board, Position pos)
    {
        if (!Board.IsInside(pos) || board.IsEmpty(pos))
        {
            return false;
        }
        return board[pos].Color != Color;
    }

    private IEnumerable<Move> ForwardMove(Board board, Position from)
    {
        Position oneMovPos = from + forward;
        if (CanMoveTo(board, oneMovPos))
        {
            yield return new NormalMove(from, oneMovPos);
            
            Position twoMovPos = oneMovPos + forward;
            if (!HasMoved && CanMoveTo(board, twoMovPos))
            {
                yield return new NormalMove(from, twoMovPos);
            }
        }
    }

    private IEnumerable<Move> DiagonalMoves(Board board, Position from)
    {
        foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
        {
            Position to = from + dir + forward;
            if (CanCaptureAt(board, to))
            {
                yield return new NormalMove(from, to);
            }
        }
    }

    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return ForwardMove(board, from).Concat(DiagonalMoves(board, from));
    }
    
}