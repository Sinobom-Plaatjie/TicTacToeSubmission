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
        private int[] _boardPosition = new int[] {2,2,2,2,2,2,2,2,2};
        private int _rounds;


        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            _boardRenderer.Render();
        }
        private void PlayMove(PlayerEnum player)
        {
            Console.SetCursorPosition(2, 19);

            if (player == PlayerEnum.X)
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

            _boardPosition[arrayPos] = (int) player;

            _boardRenderer.AddMove(rowNumber, columnNumber, player, true);
            /* if (player == PlayerEnum.X)
                 _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.X, true);
             else
                 _boardRenderer.AddMove(rowNumber, columnNumber, PlayerEnum.O, true);
 */
        }
        public bool CheckIfWins(PlayerEnum player)
        {
           int playerValue = (int)player;
            if ((_boardPosition[0] == playerValue) && (_boardPosition[1] == playerValue) && (_boardPosition[2] == playerValue))
               
                return true;
            
            if ((_boardPosition[0] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[8] == playerValue))

                return true;

            

            if ((_boardPosition[0] == playerValue) && (_boardPosition[3] == playerValue) && (_boardPosition[6] == playerValue))

                return true;

           
            if ((_boardPosition[3] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[5] == playerValue))

                return true;
            
            if ((_boardPosition[6] == playerValue) && (_boardPosition[7] == playerValue) && (_boardPosition[8] == playerValue))

                return true;
           
            if ((_boardPosition[6] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[2] == playerValue))

                return true;

            if ((_boardPosition[1] == playerValue) && (_boardPosition[4] == playerValue) && (_boardPosition[7] == playerValue))

                return true;

            if ((_boardPosition[2] == playerValue) && (_boardPosition[5] == playerValue) && (_boardPosition[8] == playerValue))

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
                PlayMove(PlayerEnum.X);
                playerXWins = CheckIfWins(PlayerEnum.X);

                if(playerXWins)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("Player X Win!!");
                    break;
                }
              

                PlayMove(PlayerEnum.O);
                playerOWins = CheckIfWins(PlayerEnum.O);

                if (playerOWins)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("Player O Win!!");
                    break;
                }
              

                _rounds++;
            }
            if (!playerXWins && !playerOWins)
            {
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("The game is draw!");

            }
        }
        

    }
}
