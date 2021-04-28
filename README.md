# battleships. 
Take home challenge for FlareHR. 

The task is to implement a Battleship state-tracker for a single player that must support the following logic:  
● Create a board. 
● Add a battleship to the board. 
● Take an “attack” at a given position, and report back whether the attack resulted in a
hit or a miss. 
● Return whether the player has lost the game yet (i.e. all battleships are sunk). 



Requirements:   
● Two players. 
● Each player has a 10x10 board. 
● During setup, players can place an arbitrary number of “battleships” on their board.  
The ships are 1-by-n sized, must fit entirely on the board, and must be aligned either vertically or horizontally.  
● During play, players take a turn “attacking” a single position on the opponent’s board,
and the opponent must respond by either reporting a “hit” on one of their battleships
(if one occupies that position) or a “miss”. 
● A battleship is sunk if it has been hit on all the squares it occupies. 
● A player wins if all of their opponent’s battleships have been sunk.  
