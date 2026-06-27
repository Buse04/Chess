using System;
namespace ChessLogic.Moves;

public class NormalMove : Move
{
    public override MoveType MoveType => MoveType.Normal;
    public override Position FromPosition { get; }
    public override Position ToPosition { get; }

    public override void Execute(Board board)
    {
        Piece piece = board[FromPosition];
        board[ToPosition] = piece;
        board[FromPosition] = null;
        piece.HasMoved = true;
    }

    public NormalMove(Position from, Position to)
    {
        from = FromPosition;
        to = ToPosition;
    }
    
    
}