using System;
using System.Collections.Generic;  

namespace battleships
{
    public class PlayerBoard
    {
        private Boolean[,] BoardState {get; set;}
        public List<Ship> Ships { get; set;}

        public PlayerBoard(int size) {
            BoardState = new bool[size, size];
            Ships = new List<Ship> {};
        }

        public void AddShip(Ship s) {
            //Check if any position in S conflicts with board

            foreach (Tuple<int, int> point in s.ActivePositions) {
                int x = point.Item1;
                int y = point.Item2;

                if (x >= BoardState.GetLength(0) || x < 0) {
                    Console.WriteLine("Invalid ship placement, does not fit on board");
                    return;
                }

                if (y >= BoardState.GetLength(1) || y < 0) {
                    Console.WriteLine("Invalid ship placement, does not fit on board");
                    return;
                }
                
                if (BoardState[x, y]) {
                    Console.WriteLine("Ship placement conflicts with existing ship");
                    return;
                }
            }

            foreach(Tuple<int, int> point in s.ActivePositions) {
                int x = point.Item1;
                int y = point.Item2;

                BoardState[x, y] = true;
            }
            Ships.Add(s);
            Console.WriteLine("Ship successfully added");
            return;
        }

        public Boolean IsPlayerActive() {
            return Ships.Count > 0;
        }
        public void ReceiveAttack(Tuple<int, int> point) {
            if (BoardState[point.Item1, point.Item2]) {
                Console.WriteLine("Hit!");
                Console.WriteLine("");
                
                BoardState[point.Item1, point.Item2] = false;
                List<Ship> remainingShips = new List<Ship>(Ships);

                foreach (Ship s in Ships) {
                    if (s.ActivePositions.Contains(point)) {
                        s.UpdatePositions(point);
        
                        if(!s.IsShipAlive()) {
                            remainingShips = Ships.FindAll(ship => ship != s);
                        }
                        break;
                    }
                }

                Ships = remainingShips;
                return;
            }

            Console.WriteLine("Miss");
            Console.WriteLine("");
        }
    
    }
}
