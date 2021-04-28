using System;
using System.Collections.Generic;  

namespace battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialising game...");
            Game game = new Game();

            PlayerBoard playerOne = new PlayerBoard(game.GridSize);
            PlayerBoard playerTwo = new PlayerBoard(game.GridSize);
        
            Console.WriteLine("--------------");
            Console.WriteLine("This is a two player game. Players will take turn entering ship locations.");
            Console.WriteLine(@"To specify ship locations, indicate a starting x and y position, length and either v/h for vertical or horizontal orientation.");
            
            bool playerOneDone = false;
            bool playerTwoDone = false;
            while (!playerOneDone || !playerTwoDone) {

                if (!playerOneDone) {
                    Console.Write("Player One to place a ship: ");
                    string playerOneInput = Console.ReadLine();
                    if (playerOneInput.ToLower().Equals("done")) {
                        playerOneDone = true;
                        continue;
                    }
                    playerOne.AddShip(game.ProcessShipInput(playerOneInput, playerOne));
                }
                
                if (!playerTwoDone) {
                    Console.Write("Player Two to place a ship: ");
                    string playerTwoInput = Console.ReadLine();
                    if (playerTwoInput.ToLower().Equals("done")) {
                        playerTwoDone = true;
                        continue;
                    }
                    playerTwo.AddShip(game.ProcessShipInput(playerTwoInput, playerTwo));
                }
            }

            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);
            game.ProceedGame();

            Console.WriteLine("--------------");
            Console.WriteLine("The game is now in progress. Players take turns attacking.");

            while(true) {
                if(game.IsGameOver(playerOne)) {
                    Console.WriteLine("Player Two Wins!");
                    break;
                }
                if (game.IsGameOver(playerTwo)){
                    Console.WriteLine("Player One Wins!");
                    break;
                }
                Console.WriteLine("-------PLAYER ONE-------");
                game.LaunchAttack(playerOne, playerTwo);
                Console.WriteLine("-------PLAYER TWO-------");
                game.LaunchAttack(playerTwo, playerOne);
            }

            game.ProceedGame();

        }
    }
}
