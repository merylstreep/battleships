using System;
using System.Collections.Generic;  

namespace battleships
{
    enum GameState {
            Init, 
            InProgress,
            Completed,
        };

    public class Game
    // Game should just track its state (FSM) 
    {
        public int GridSize = 10;
        public List<PlayerBoard> Players {get; set;}
        private GameState CurrentState {get; set;}

        public Game() {
             CurrentState = GameState.Init;
             Players = new List<PlayerBoard>();
        }
       
       public void AddPlayer(PlayerBoard player) {
           Players.Add(player);
       }
       public Boolean IsGameOver(PlayerBoard player) {
           return !player.IsPlayerActive();
       }

       public Boolean IsCoordinateValid(String input) {
           if (String.IsNullOrWhiteSpace(input)) {
               return false;
           } 

            String[] coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length != 2) {
                return false;
            }

            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);


            if (x >= GridSize || x < 0) {
               return false;
            }
            if (y >= GridSize || y < 0) {
               return false;
            }

            return true;
       }

       public void LaunchAttack(PlayerBoard fromPlayer, PlayerBoard toPlayer) {
           //Get attack coordinate by fromPlayer, validate position, and apply to tnPlayer

           bool valid = false;
           Console.Write("Enter attack coordinates (space separated): ");
           string userInput = Console.ReadLine();
           valid = IsCoordinateValid(userInput);

           while (!valid) {
               Console.Write("Invalid entry, please try again: ");
               userInput = Console.ReadLine();
               valid = IsCoordinateValid(userInput);
           }

            String[] coordinates = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            Tuple<int, int> point = new Tuple<int, int> (x, y);
            toPlayer.ReceiveAttack(point);
       }

       public void ProceedGame() {
           if (CurrentState == GameState.Init) {
                CurrentState = GameState.InProgress;
                return;
           } 
           if (CurrentState == GameState.InProgress) {
                CurrentState = GameState.Completed;
                return;
           } 
           return;
       }
       public Ship ProcessShipInput(String s, PlayerBoard p) {
            String[] keys = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int startX = int.Parse(keys[0]);
            int startY = int.Parse(keys[1]);
            int length = int.Parse(keys[2]);
            string direction = keys[3];

            List<Tuple<int, int>> positions = new List<Tuple<int, int>>();
            if (direction.Equals('h')) {
                for (int i = startX; i < startX + length; i++) {
                    positions.Add(new Tuple<int, int>(i, startY));
                }
            } else {
                for (int i = startY; i < startY + length; i++) {
                    positions.Add(new Tuple<int, int>(startX, i));
                }
            }
            
            Ship ship = new Ship(positions);
            return ship;
        }
    }
}
