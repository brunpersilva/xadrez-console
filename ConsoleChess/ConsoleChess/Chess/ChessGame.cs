using board;
using System;
namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        private int _turn;
        private Color _currentPlayer;
        public bool FinishedGame { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            _turn = 1;
            _currentPlayer = Color.White;
            FinishedGame = false;
            PlacePieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(p, destination);
        }

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PlacePiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.PlacePiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.PlacePiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PlacePiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.PlacePiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());

            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PlacePiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.PlacePiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.PlacePiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PlacePiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
            Board.PlacePiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());

            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        }
    }
}
