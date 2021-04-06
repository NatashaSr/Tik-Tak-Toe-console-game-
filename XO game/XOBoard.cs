using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO_game
{
    class XOBoard
    {
        //Array that refers to the positions of the XO board, we will not use the postion 0.
        static string[] place = new string[10] { "0", "1","2","3","4","5","6","7","8","9"};
        
        //Constructor
        public XOBoard(){}

        public bool inputXO(string XO, int index)
        {
            if (index <= 0 || index>9)
                return false;

            if (place[index] == "")
            {
                place[index] = XO;
                return true;
            }
            //If we got here, it means that he tried to put an X or O in a place that was already occupied. 
            return false;
        }

        private bool IsLine(int index0, int index1, int index2, string piece)
        {
            return place[index0] == piece && place[index1] == piece && place[index2] == piece;
        }

        public string checkStatus()
        {
            //X and O-Vertical
            for(int j=1; j<4;j++)
            {
                if (IsLine(j, j + 3, j + 6, "X"))
                    return "X";
                if(IsLine(j, j + 3, j + 6, "O"))
                    return "O";
            }

            //X and O-Horizontal
            for (int j = 1; j < 8;)
            {
                if (IsLine(j, j + 1, j + 2, "X"))
                    return "X";
                if (IsLine(j, j + 1, j + 2, "O"))
                    return "O";

                j = j + 3;
            }
            
            //X-Diagonal
            if (IsLine(1, 5, 9, "X") || IsLine(7, 5, 3, "X"))
            {
                return "X";
            }
            
            //O-Diagonal 
            if (IsLine(1, 5, 9, "O") || IsLine(7, 5, 3, "O")) 
            {
                return "O";
            }

            if (Array.IndexOf(place, "") >= 0) 
                return "None";
            else
            {
                return "Draw";
            }
        }
    

        public void drawPositionsValues()
        {
            for (int i = 0; i < place.Length; i++)
            {
                place[i] = Convert.ToString(i);
            }
        }
        
        public void resetBoardValues()
        {
            for(int i=1;i<place.Length; i++){
                place[i] = "";
            }
        }

        public void DrawBoard()
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}  ", place[1], place[2], place[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", place[4], place[5], place[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", place[7], place[8], place[9]);
        }
    }
}
