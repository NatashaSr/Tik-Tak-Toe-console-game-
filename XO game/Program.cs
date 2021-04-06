using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO_game
{
    class Program
    {
        static void Main(string[] args)
        {
            XOBoard myBoard = new XOBoard();
          
            playTheGame();

            void playTheGame()
            {
                string name1, name2, currentPlayer, XorO, gameStatus, optionEnter, posInput;
                int pos;
                bool inputCheck = false,posParse;
                
                while (true)
                {
                    Console.Write("Here are the options to our game:\n" +
                                    "Press 0-to EXIT;\n" +
                                    "Press 1-to star e new game;\n");
                    optionEnter = Console.ReadLine();

                    switch (optionEnter)
                    {
                        case "0":
                            return;

                        case "1":
                            Console.Write("Welcome to the tic tac toe game!\n" +
                                "Please Player 1, enter your name:\n");
                            name1 = Console.ReadLine();
                            Console.Write("Now please Player 2, enter your name:\n");
                            name2 = Console.ReadLine();
                            Console.Write("Ok, great! {0} you are X and {1} you are O. \n", name1, name2);
                            Console.Write("Those are the positions to play the game:\n");
                            drawPostions();
                            display();
                            Console.Write("Now let's start the game!\n");
                            resetBoard();

                            for (int i = 0; i < 9; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    XorO = "X";
                                    currentPlayer = name1;
                                }
                                else
                                {
                                    XorO = "O";
                                    currentPlayer = name2;
                                }

                                do
                                {
                                    Console.Write("Please {0} enter the position that you want to put {1},\n" +
                                                  "be sure that this position has not been taken yet\n" +
                                                  "and that you writting a right position.\n", currentPlayer, XorO);

                                    posInput = Console.ReadLine();
                                    posParse = Int32.TryParse(posInput, out pos);

                                    if (posParse == false || pos<=0 || pos>9)
                                        Console.Write("Please enter a real position.\n");
                                    else
                                    {
                                        inputCheck = put(XorO, pos);
                                        if (inputCheck == false)
                                            Console.Write("This position already taken!\n");
                                    }

                                    display();
                                } while (posParse == false || inputCheck == false);

                                inputCheck = false;

                                if (i>=4)
                                {
                                    gameStatus=status();
                                    if (gameStatus == "X" || gameStatus == "O" || gameStatus == "Draw")
                                    {
                                        if (gameStatus == "X")
                                            Console.Write("The game ends and the winner is {0}, congratulations!\n", name1);
                                        else if(gameStatus == "O")
                                            Console.Write("The game ends and the winner is {0}, congratulations!\n", name2);
                                        else
                                            Console.Write("The game is over and it was a draw!\n");
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write("The game is not over yet!\n");
                                    }
                                }
                            }
                            break;
                      
                        default:
                            Console.Write("Enter a right option please.\n");
                            break;
                    }
                }
            }

            bool put(string symb,int pos)
            {
                return myBoard.inputXO(symb,pos);
            }

            string status()
            {
                return myBoard.checkStatus();
            }

            void display()
            {
                myBoard.DrawBoard();
            }

            void drawPostions()
            {
                myBoard.drawPositionsValues();
            }
            void resetBoard()
            {
                myBoard.resetBoardValues();
            }
        }    
    }
}
