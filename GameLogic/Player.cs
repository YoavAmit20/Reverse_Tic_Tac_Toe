
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly ePlayerSymbols r_PlayerSymbol;
        private readonly bool r_IsAiPlayer;
        private int m_Score = 0;

        public Player(string i_Name, ePlayerSymbols i_PlayerSymbol, bool i_IsAiPlayer)
        {
            this.r_Name = i_Name;
            this.r_PlayerSymbol = i_PlayerSymbol;
            this.r_IsAiPlayer = i_IsAiPlayer;

        }

        public string Name { get { return r_Name; } }
        
        public int Score
        { 
            get 
            {
                return m_Score; 
            }

            set 
            {
                m_Score = value;
            }
        }

        public ePlayerSymbols PlayerSymbol { get { return r_PlayerSymbol; } }
        public bool IsAiPlayer { get { return r_IsAiPlayer; } }

        public Coordinate AiMove(int i_BoardSize)
        {
            Random random = new Random();
            int x = random.Next(1, i_BoardSize);
            int y = random.Next(1, i_BoardSize);

            return new Coordinate(x, y);
        }

        public Coordinate AiMove(LinkedList<Coordinate> i_FreeCoordiantes)
        {
            Random random = new Random();
            int index = random.Next(0, i_FreeCoordiantes.Count);

            return i_FreeCoordiantes.ElementAt(index);
        }
        
    }
}
