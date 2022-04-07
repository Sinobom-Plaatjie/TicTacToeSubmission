using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _boardPosition = new int[9];
        private int _rounds;


        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }
        private void PlayMove(int player)
        {
            Console.SetCursorPosition(2, 19);

            if(player == 1)
            Console.Write("Player X");
             else
                Console.Write("Player O");


            Console.SetCursorPosition(2, 20);

            Console.Write("Please Enter Row: ");
            var row = Console.ReadLine();

            Console.SetCursorPosition(2, 22);


            Console.Write("Please Enter Column: ");
            var column = Console.ReadLine();

            Console.Clear();

            //store move in array
            int rowNumber = int.Parse(row);
            int columnNumber = int.Parse(column);
            int arrayPos = (rowNumber * 3) + columnNumber;

            _boardPosition[arrayPos] = player;

            if (player == 1)
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.X, true);
            else
                _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.O, true);

            //Console.Clear();
        }
        public bool CheckIfWins(int player)
        {   //*Horizontal win
            if ((_boardPosition[0] == player) && (_boardPosition[1] == player) && (_boardPosition[2] == player))
               
                return true;
            //*diagonal win 
            if ((_boardPosition[0] == player) && (_boardPosition[4] == player) && (_boardPosition[8] == player))

                return true;

            //*vertical win

            if ((_boardPosition[0] == player) && (_boardPosition[3] == player) && (_boardPosition[6] == player))

                return true;

            //*
            if ((_boardPosition[3] == player) && (_boardPosition[4] == player) && (_boardPosition[5] == player))

                return true;
            //*
            if ((_boardPosition[6] == player) && (_boardPosition[7] == player) && (_boardPosition[8] == player))

                return true;
            //*
            if ((_boardPosition[6] == player) && (_boardPosition[4] == player) && (_boardPosition[2] == player))

                return true;

            if ((_boardPosition[1] == player) && (_boardPosition[4] == player) && (_boardPosition[7] == player))

                return true;

            if ((_boardPosition[2] == player) && (_boardPosition[5] == player) && (_boardPosition[8] == player))

                return true;


            return false;
        }
   
        public void Run()
        {
            _rounds = 0;
            bool playerXWins = false;
            bool playerOWins = false;

            while (_rounds < 4)
            {
                PlayMove(1);
                playerXWins = CheckIfWins(1);

                if(playerXWins)
                {
                    Console.SetCursorPosition(22, 27);
                    Console.WriteLine("Player X Win!!");
                    break;
                }
              

                PlayMove(2);
                playerOWins = CheckIfWins(2);

                if (playerOWins)
                {
                    Console.SetCursorPosition(22, 27);
                    Console.WriteLine("Player O Win!!");
                    break;
                }
              

                _rounds++;
            }
            if (!playerXWins && !playerOWins)
            {
                Console.SetCursorPosition(22, 27);
                Console.WriteLine("The game is draw!");

            }
        }
        

    }
}
