using System;
using System.Collections.Generic;
using System.Threading;

namespace RPG_Character_Generator
{
    class Menu
    {
        public static void TitleScreen()
        {
            int speed = 50;

            // Graphics.MakeBorder(5,20,15);
            
            Console.SetWindowSize(100, 30);

            Console.SetCursorPosition(40, 10);
            Console.WriteLine("!! Character Creator !!\n");
            Console.SetCursorPosition(39, 11);
            TitleAnimation(speed);

            Thread.Sleep(800);
            Console.SetCursorPosition(70, 20);
            Console.WriteLine("ver. 0.1.1");

            Thread.Sleep(800);
            Console.Clear();
            
            Console.SetWindowSize(125, 30);
        }
        
        private static void TitleAnimation(int speed) // Does squigglies under title text - Figure out how to write in center of screen.
        {
            Console.Write("*");
            Thread.Sleep(speed);
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");
            Thread.Sleep(speed);            
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");
            Thread.Sleep(speed);                        
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");
            Thread.Sleep(speed);
            Console.Write(@"\");
            Thread.Sleep(speed);
            Console.Write("_");
            Thread.Sleep(speed);
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("*");

        }

        public static void ShowMainMenu(Character mainChar)
        {
            string entry;

            Console.Clear();

            Console.WriteLine(" Welcome to the Character Generator!\n\n");
            Console.WriteLine(" Choose how to proceed:");
            Console.WriteLine(" (A)Generate a new character.");
            Console.WriteLine(" (B)Load an exsisting character.");
            Console.WriteLine(" (C)Manually enter a new character");
            Console.WriteLine(" (D)Nvm, go do something else.\n");

            entry = Console.ReadLine().ToLower();  // need to validate choice to be a-d.... loop if not.

            // return entry[0];

            switch (entry[0])  // Clean up somehow.  Move to show main menu function.
            {
                case ('a'):
                    mainChar.GenerateCharacter();
                    break;
                case ('b'):
                    ImportExport.LoadCharacter(mainChar);
                    break;
                case ('c'):
                    mainChar.ManuallyMakeChar();
                    break;
                case ('d'):
                    Console.WriteLine("\n\nOk then... bye!");
                    break;
                default:
                    Console.WriteLine("wat");
                    break;
            }
        }

        public static void ShowSecondaryMenu(Character character)
        {
            string entry;
            bool loop = true;
            
            do
            {
                Console.Clear();
                                
                character.ShowStatsOnRight();

                Console.SetCursorPosition(0, 2);
                Console.WriteLine(" What would you like to do next?");
                Console.WriteLine(" (A) Change characters name.");
                Console.WriteLine(" (B) Level up character");
                Console.WriteLine(" (C) Change character role");
                Console.WriteLine(" (J) Jump to a particular level");
                Console.WriteLine(" (R) Restart and make a new character - TBD");
                Console.WriteLine(" (S) Save Character");
                Console.WriteLine(" (T) Test Character - TBD");  // Not implemented yet... Will give user output if certain criteria are met.
                Console.WriteLine(" (X) Exit\n");
                
                entry = Console.ReadLine().ToLower();

                // Change below to switch statment
                if (entry == "a")
                    character.ChangeCharacterName();

                if (entry == "b")
                    character.LevelUp();

                if (entry == "c")
                    character.ChangeCharacterRole();

                if (entry == "j")
                    character.LevelUpJump();

                if (entry == "r")
                    Menu.ShowMainMenu(character);

                if (entry == "s")
                    ImportExport.SaveCharacter(character);

                if (entry == "t")
                    character.PlaceHolder();

                if (entry == "x")
                {
                    Console.WriteLine("Bye!");
                    loop = false;
                }

            } while (loop == true);
        }
    }

}
