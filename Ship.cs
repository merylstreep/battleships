using System;
using System.Collections.Generic;  

namespace battleships
{
    public class Ship
    {
        public List<Tuple<int ,int>> ActivePositions { get; set;} 
        public Ship(List<Tuple<int ,int>> initialPositions) {
            ActivePositions = initialPositions;
        }

        public Boolean IsShipAlive() {
            if (ActivePositions.Count > 0) {
                return true;
            };
            return false;
        }

        public void UpdatePositions(Tuple<int, int> point) {
            List<Tuple<int, int>> newPositions = new List<Tuple<int, int>>();

            newPositions = ActivePositions.FindAll(pos => 
                            !(pos.Item1 == point.Item1 && pos.Item2 == point.Item2));
            
            ActivePositions = newPositions;
        }
    }
}
