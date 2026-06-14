using System;
using System.Collections.Generic;
using ChessLogic;
using Avalonia.Media.Imaging; 
using Avalonia.Platform;

namespace ChessUI;

public class Images
{
    private static readonly Dictionary<PieceType, Bitmap> whiteSources = new()
    {
        { PieceType.Rook, LoadImage("Assets/RookW.png") },
        { PieceType.Knight, LoadImage("Assets/KnightW.png") },
        { PieceType.Queen, LoadImage("Assets/QueenW.png") },
        { PieceType.Bishop, LoadImage("Assets/BishopW.png") },
        { PieceType.King, LoadImage("Assets/KingW.png") },
        { PieceType.Pawn, LoadImage("Assets/PawnW.png") },
    };
    
    private static readonly Dictionary<PieceType, Bitmap> blackSources = new()
    {
        { PieceType.Rook, LoadImage("Assets/RookB.png") },
        { PieceType.Knight, LoadImage("Assets/KnightB.png") },
        { PieceType.Queen, LoadImage("Assets/QueenB.png") },
        { PieceType.Bishop, LoadImage("Assets/BishopB.png") },
        { PieceType.King, LoadImage("Assets/KingB.png") },
        { PieceType.Pawn, LoadImage("Assets/PawnB.png") },
    };
    
    private static Bitmap LoadImage(string path)
    {
        string Uri = $"avares://ChessUI/{path}";
        return new Bitmap(AssetLoader.Open(new Uri(Uri)));
    }

    private static Bitmap GetImage(Player color, PieceType type)
    {
        return color switch
        {
            Player.White => whiteSources[type],
            Player.Black => blackSources[type],
            _ => null,
        };
    }

    public static Bitmap GetImage(Piece piece)
    {
        if(piece == null){ return null; }
        return GetImage(piece.Color, piece.Type);
    }
}