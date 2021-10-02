using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Character_Generator
{
    class Graphics
    {
        public static void MakeBorder(int size, int xpos, int ypos)  // Makes a random border of inputted size at specified position
        {
                        
            Console.SetCursorPosition(xpos, ypos);

            for (int x = 0; x< size; x++)
            {
                Console.SetCursorPosition(xpos+x, ypos);
                Console.WriteLine("*");
            }

            for (int x = 1; x< size; x++)
            {
                Console.SetCursorPosition(xpos, ypos + x);
                Console.WriteLine("*");
            }

            for (int x = 1; x < size; x++)
            {
                Console.SetCursorPosition(xpos+size-1, ypos + x);
                Console.WriteLine("*");
            }

            Console.SetCursorPosition(xpos+size, ypos);

            for (int x = 0; x < size; x++)
            {
                Console.SetCursorPosition(xpos+x, ypos + size);
                Console.WriteLine("*");
            }

            Console.ReadKey();

        }




    }
}
