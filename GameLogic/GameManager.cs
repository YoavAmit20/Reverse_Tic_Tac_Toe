using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class GameManager
    {        
        private readonly GameBoard r_Board;
        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private Player m_CurrentPlayersTurn;


        private GameManager(string i_PlayerOneName, string i_PlayerTwoName ,int i_BoardSize, bool i_IsAiPlayer)
        {
            r_Board = new GameBoard(i_BoardSize);
            r_PlayerOne = new Player(i_PlayerOneName, ePlayerSymbols.X, false);
            r_PlayerTwo = new Player(i_PlayerTwoName, ePlayerSymbols.O, i_IsAiPlayer);
        }

        public static GameManager InitializeGame(string i_PlayerOneName, string i_PlayerTwoName, int i_BoardSize, bool i_isAiPlayer) 
        {

            GameManager manager = new GameManager(i_PlayerOneName, i_PlayerTwoName, i_BoardSize, i_isAiPlayer);

            manager.setStartingPlayer();

            return manager;
        }

        public GameBoard GameBoard 
        { 
            get 
            {
                return r_Board; 
            } 
        }
        public Player PlayerOne 
        { 
            get 
            {
                return r_PlayerOne; 
            } 
        }
        public Player PlayerTwo 
        { 
            get 
            { 
                return r_PlayerTwo; 
            } 
        }

        public Player CurrentPlayersTurn 
        { 
            get 
            {
                return m_CurrentPlayersTurn; 
            }

            set 
            {
                m_CurrentPlayersTurn = value;
            }
        }
        private void setStartingPlayer()
        {
            CurrentPlayersTurn = PlayerOne;
        }

        public void ChangeTurn()
        {
            if (CurrentPlayersTurn == PlayerOne) 
            {
                CurrentPlayersTurn = PlayerTwo;
            }

            else 
            {
                CurrentPlayersTurn = PlayerOne;
            }

        }

        public bool IsValidPosition(Coordinate i_Coordiante)
        {
            return GameBoard.IsCellPostionValid(i_Coordiante);
        }
        public bool IsEmptyCell(Coordinate i_Coordiante)
        {
            return GameBoard.IsEmptyCell(i_Coordiante);
        }
        public void PlacePlayerCell(Coordinate i_Coordiante)
        {
            GameBoard.SetCell(i_Coordiante, CurrentPlayersTurn);
        }

        public bool IsBoardFull()
        {
            return GameBoard.IsBoardFull();
        }

        public bool IsLossingMove(Coordinate i_Coordinate)
        {
            return GameBoard.IsStreak(i_Coordinate);
        }


        public static bool IsAmountPlayersValid(int i_AmountOfPlayers)
        {
            const int k_minimumAmountOfPlayers = 1, k_maximumAmountOfPlayers = 2;

            return i_AmountOfPlayers >= k_minimumAmountOfPlayers && i_AmountOfPlayers <= k_maximumAmountOfPlayers;
        }
        public void AddPoint()
        {
            CurrentPlayersTurn.Score++;
        }

        public Coordinate AiMove()
        {

            LinkedList<Coordinate> freeCoordiantes = new LinkedList<Coordinate>();
            for (int i = 1; i < GameBoard.Board.GetLength(0); i++)
            {
                for (int j = 1; j < GameBoard.Board.GetLength(1); j++)
                {
                    if (GameBoard.Board[i, j] == ePlayerSymbols.None)
                    {
                        freeCoordiantes.AddLast(new Coordinate(i, j));
                    }
                }
            }

            return PlayerTwo.AiMove(freeCoordiantes);
        }

        public void Reset()
        {
            setStartingPlayer();
            GameBoard.Reset();
        }
    }
}
