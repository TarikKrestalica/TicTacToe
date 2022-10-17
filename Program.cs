using System;

namespace TicTacToe
    {
        class MainClass
        {

        public static void Main(string[] args)
        {
            // Setup: Make the initial board, indicate the pieces, and the goal is to fill in 9 empty spaces
            char[,] gameBoard = new char[3, 3] { {' ', ' ', ' '},
                                                 {' ', ' ', ' '},
                                                 {' ', ' ', ' '} } ;
            char player1 = 'X', player2 = 'O';

            int turn = 0;
            int emptySpaces = gameBoard.Length;
            string horizontalDivider = "\n-----------", verticalDivider = " |";

            // Playing the Game: As long as the board is not full!!

            while (emptySpaces != 0)
            {
                CurrentBoardState(gameBoard);

                // Alternate between player 1 and 2, assign the appropriate piece
                int result = turn % 2;
                char piece = result < 1 ? player1 : player2;

                // Message, "\n\n: Separate the board from the prompt
                string response = result < 1 ? "Player 1's turn!" : "Player 2's turn!";
                Console.WriteLine("\n\n" + response);

                // Prompt the user for a row, must be 0-2
                Console.Write("Enter a row number(0-2): ");
                string row = Console.ReadLine();

                // Did the user enter a valid row number?
                if (int.TryParse(row, out int rowNum))
                {
                    if (rowNum < 0 || rowNum > 3)
                    {
                        Console.WriteLine($"Row {row} is out of bounds. Please Try Again!");
                        continue;
                    }
                }
                // Keep asking the user until a number is entered
                else
                {
                    Console.WriteLine($"{row} is not a number. Try Again!\n");  
                    continue;
                }
                    

                // Prompt the user for a column, check for validity, 0-2
                Console.Write("Enter a column number(0 - 2): ");
                string column = Console.ReadLine();

                // Did the user enter a number?
                if (int.TryParse(column, out int colNum))
                {
                    if (colNum < 0 || colNum > 3)
                    {
                        Console.WriteLine($"Column {column} is out of bounds. Please Try Again!");
                        continue;
                    }
                }
                // Keep asking the user until a number is entered
                else
                {
                    Console.WriteLine($"{column} is not a number. Try Again!\n");
                    continue;
                }
                    

                Console.Clear();

                // Is the location invalid
                if (!ValidLocation(gameBoard, rowNum, colNum, piece))
                    continue;

                // Check for winning moves
                if (WinningMove(gameBoard, piece) == true)
                    break;
               
            }

            CurrentBoardState(gameBoard);


            // Functions for the game!

                // Print out the game board
                void CurrentBoardState(char[,] board)
                { 
                    for (int row = 0; row < board.GetLength(0); ++row)
                    {
                        for (int col = 0; col < board.GetLength(1); ++col)
                        {
                            // Add a space, place the piece, place the divider when appropriate(not at column 2)
                            if (col < board.GetLength(1) - 1)
                                Console.Write(" " + board[row, col] + verticalDivider);
                            else
                                Console.Write(" " + board[row, col]);

                        }

                        // Place the divider only if I am not in the last row!
                        if(row < board.GetLength(0) - 1)
                            Console.WriteLine(horizontalDivider);
                    }

                }

                // Is there an opposing piece at the player's chosen position?
                bool ValidLocation(char [,] board, int row, int column, char piece)
                {
                    if (board[row, column] != player1 && board[row, column] != player2)
                    {
                        // Place the piece, decrement my empty spaces, increment the turn count
                        board[row, column] = piece;
                        emptySpaces--;
                        ++turn;
                        return true;
                    }
                    else
                    {
                        // Throw an error message, prompt the user again!
                        Console.WriteLine($"Row {row}, Column {column} is taken! Please try Again!");
                        return false;
                    }
                }

                // Do I have winning moves?
                bool WinningMove(char[,] board, char piece)
                {
                    int numOfPieces = 0;    // Track my pieces

                    // Create a winning message: Separate the message from the final game board
                    string message = piece == 'X' ? "Player 1 Wins!\n" : "Player 2 Wins!\n";

                    // Check horizontal wins
                    for (int row = 0; row < board.GetLength(0); ++row)
                    { 
                        for(int col = 0; col < board.GetLength(1); ++col)
                        {
                            // Go through each column and find any instance of the player's piece
                            if (board[row, col] == piece)
                                numOfPieces++;
                        }

                        // Do I have a winning move? Do I have a 3 of a kind?
                        if (numOfPieces == board.GetLength(1))
                        {
                            Console.WriteLine(message);
                            return true;
                        }
                        // Otherwise, reset the process
                        else
                            numOfPieces = 0;

                    }
              
                    // Check vertical wins
                    for (int col = 0; col < board.GetLength(1); ++col)
                    {
                        for (int row = 0; row < board.GetLength(0); ++row)
                        {
                        // Go through each row
                        if (board[row, col] == piece)
                            numOfPieces++;
                        }

                        // Do I have a winning move? Do I have a 3 of a kind?
                        if (numOfPieces == board.GetLength(1))
                        {
                            Console.WriteLine(message);
                            return true;
                        }
                        // Otherwise, reset the process
                        else
                            numOfPieces = 0;

                    }

                    // After checking all wins, return false by default
                    return false;
            }
                
                

            }

        }

    }
    


