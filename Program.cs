using System;
using System.Collections.Generic;

namespace RPG_Character_Generator
{
    class Program
    {
        static void Main(string[] args)
        {            
            Character mainChar = new Character();

            Menu.TitleScreen();
            
            Menu.ShowMainMenu(mainChar); // Main menu asking paths. Maybe add branching monster menu.
            
            Menu.ShowSecondaryMenu(mainChar);   // New menu asking if they want to do additional things to generated character. Show stats automatically.
            
            Console.ReadKey();

        }
        
    }
    
}

#region Future Plans

// LATER

// Load a file for editing. - DONE

// Open a new file for editing or generate a character - DONE 

// Title Screen - DONE

// Generate stats based off role chosen.   DONE, needs refining though.

// Generate monsters.. 

// Pick from a list of premade monsters?

// Branching classes?

// Evaluate - give comments based off level of stats. Maybe replaced by glass

// Simple combat

// Generate inventory - Potions, Gil, 

// Loot from monster battles.

// Generate character traits

// Tower progession - Fight monsters of various levels set with premade monsters.

// Save character progress through tower and load game.

// Generate backstory for character.

// Provide character with random abilities

// Provide Traits  

// Generate towns

// Generate special artifact items.

#endregion

#region Bugs

// Main menu continues despite exit.

#endregion


#region Things to think about.

// Classes - Determine stat progression

#endregion






/////////////
