using board;
using System;
using System.Collections.Generic;
namespace chess
{
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool FinishedGame { get; private set; } = false;
        private readonly HashSet<Piece> _pieces = new HashSet<Piece>();
        private readonly HashSet<Piece> _capturedPieces = new HashSet<Piece>();
        public bool Check { get; set; } = false;

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PlacePieces();
        }

        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(p, destination);
            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void MakeMovment(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);

            if (IsChecked(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardExceptions("You can't put yourself in check");
            }
            if (IsChecked(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (IsMated(Adversary(CurrentPlayer)))
            {
                FinishedGame = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

        }

        private void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destination);
            piece.DecrementMovement();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destination);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(piece, origin);
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardExceptions("There is no piece in that square");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardExceptions("The chosen piece is not yours");
            }
            if (!Board.Piece(pos).IsTherePossibleMoves())
            {
                throw new BoardExceptions("No possible moves for the chosen piece");
            }
        }
        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.Piece(origin).CanMove(destination))
            {
                throw new BoardExceptions("Invalid Destination");
            }
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        public HashSet<Piece> CapturedPiece(Color color)
        {
            HashSet<Piece> helper = new HashSet<Piece>();
            foreach (Piece piece in _capturedPieces)
            {
                if (piece.Color == color)
                {
                    helper.Add(piece);
                }
            }
            return helper;
        }
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> helper = new HashSet<Piece>();
            foreach (Piece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    helper.Add(piece);
                }
            }
            helper.ExceptWith(CapturedPiece(color));
            return helper;
        }
        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }
        public bool IsChecked(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardExceptions($"No {color} king in the game");
            }
            foreach (var piece in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[king.PiecePosition.Rank, king.PiecePosition.File])
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsMated(Color color)
        {
            if (!IsChecked(color))
            {
                return false;
            }
            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < Board.Ranks; i++)
                {
                    for (int j = 0; j < Board.Files; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.PiecePosition;
                            Position destination = new Position(i, j);
                            Piece capured = ExecuteMovement(origin, destination);
                            bool TestingCheck = IsChecked(color);
                            UndoMove(origin, destination, capured);
                            if (!TestingCheck)
                            {
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }
        public void PlaceNewPiece(char file, int rank, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(file, rank).ToPosition());
            _pieces.Add(piece);
        }
        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            //PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            //PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            //PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            //PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            //PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White));

            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ToPosition());

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            //PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            //PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            //PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            //PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            //PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black));

            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        }
    }
}
