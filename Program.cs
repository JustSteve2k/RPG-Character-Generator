﻿using System;
using System.Xml;

namespace RPG_Character_Generator
{
    class Program
    {
        static void Main(string[] args)
        {            
            Character mainChar = new Character();
            char choice;
            
            choice = Menu.ShowMainMenu();
            
            switch(choice)
            {
                case ('a'):
                    mainChar.GenerateCharacter();
                    break;
                case ('b'):
                    Console.WriteLine("Load an existing character - TBD");
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

            if (choice != 'd')
            {
                // New menu asking if they want to A-rename person B-Level up character C. Save.   Show stats automatically.
                Menu.ShowSecondaryMenu(mainChar);                                                
            }

            Console.ReadKey();

        }
        
    }

    class Menu
    {
        public static char ShowMainMenu() // Maybe need to return choice as char 
        {
            string entry;

            Console.WriteLine("Welcome to the Character Generator!\n\n");
            Console.WriteLine("Choose how to proceed:");
            Console.WriteLine("(A)Generate a new character.");
            Console.WriteLine("(B)Load an exsisting character.");
            Console.WriteLine("(C)Manually enter a new character");
            Console.WriteLine("(D)Nvm, go do something else.");

            entry = Console.ReadLine().ToLower();  // need to validate choice to be a-d.... loop if not.

            switch (entry)  // CLEAN UP THIS PORTION TO JUST SIMPLE RETURN
            {
                case ("a"):
                    return 'a';
                case ("b"):
                    return 'b';
                case ("c"):
                    return 'c';
                case ("d"):
                    return 'd';
                default:
                    return 'a';
            }

        }

        public static void ShowSecondaryMenu(Character character)
        {
            string entry;
            bool loop = true;

            character.ShowStats();

            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("(A) Change characters name.");
            Console.WriteLine("(B) Level up character");
            Console.WriteLine("(C) Save Character");
            Console.WriteLine("(D) Quit");
            entry = Console.ReadLine().ToLower();

            if (entry == "a")
            {
                character.ChangeCharacterName();
                character.ShowStats();
            }

            if (entry == "b")
                character.LevelUp();

            if (entry == "c")
                ImportExport.SaveCharacter(character);
        }

    }
    
    class Character
    {       
        
        public string name { get; set; }
        
        public string charClass { get; set; }

        public int attack { get; set; }
        
        public int defense { get; set; }
        
        public int intelligence { get; set; }  
        
        public int dexterity { get; set; } 

        public int constitution { get; set; } 

        public int charisma { get; set; } 
        
        // Other stats to make - characterdescription, alignment, hometown, occupation, age, money;

        public Character()  // May be the same as generate character.
        {
            name = "";
            charClass = "Novice";
            attack = 0;
            defense = 0;
            intelligence = 0;
            dexterity = 0;
            constitution = 0;
            charisma = 0;
        }
                        
        public void GenerateCharacter()  // Maybe make something that genrates a tank / healer / spellcaster / melee dps depending on input.
        {
            Random rand = new Random();
            
            Console.WriteLine("Generating character...");
            name = "Hero";  // Make something that picks from a random list of names.
            attack = rand.Next(10,25);
            defense = rand.Next(10, 20);
            intelligence = rand.Next(6, 20);
            dexterity = rand.Next(6, 20);
            constitution = rand.Next(6, 20);
            charisma = rand.Next(6, 20);
        }

        public void ManuallyMakeChar()
        {
            Console.Clear();
            Console.WriteLine("Lets make a character...");
            Console.ReadKey();
                        
            Console.WriteLine("\nWhats your characters name?");
            name = Console.ReadLine();

            Console.WriteLine("Whats your characters class?");
            charClass = Console.ReadLine();

            Console.WriteLine("Whats your characters attack power?");
            attack = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters defense?");
            defense = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters intelligence");
            intelligence = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters dexterity");
            dexterity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters constitution");
            constitution = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters charisma");
            charisma = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowStats()
        {
            Console.Clear();            
            Console.WriteLine("Your stats are:\n");
            Console.WriteLine($"Your characters name is {name}.");
            Console.WriteLine($"Your characters class is {charClass}.");
            Console.WriteLine($"Your attack is {attack}.");
            Console.WriteLine($"Your defense is {defense}.");
            Console.WriteLine($"Your intelligence is {intelligence}.");
            Console.WriteLine($"Your dexterity is {dexterity}.");
            Console.WriteLine($"Your constitution is {constitution}.");
            Console.WriteLine($"Your charisma is {charisma}.");
            Console.ReadKey();
        }

        public void ChangeCharacterName()
        {
            string entry = " ";
            
            Console.WriteLine("What is your characters new name?");
            name = Console.ReadLine();
        }

        public void LevelUp()
        {
            Console.WriteLine("This will level up your character eventually.");
        }

        /////////////
        ////////// Functions to make
        /////////////
        // LevelUp - level up 
        // LevelUpMax - level up character to lvl 99.
        // Evaluate - give comments based off level of stats.
        // GenerateInv - make  
        /////////////
    }


    class ImportExport
    {
        public static void ShowMenu(Character character)
        {
            Console.Clear();
            string entry = "";
            Console.WriteLine("Would you like to save your work?");
            entry = Console.ReadLine().ToLower().Trim();

            if (entry == "yes" || entry == "y")
            {
                SaveCharacter(character);
            }
            else
            {
                Console.WriteLine("Not saved!");
                Console.ReadKey();
            }
        }
        
        public static void SaveCharacter(Character character)
        {
           
            XmlDocument xmldoc = new XmlDocument();

            XmlNode root, node;
            root = xmldoc.CreateElement("CharacterInfo");
            xmldoc.AppendChild(root);

            node = xmldoc.CreateElement("Name");
            node.InnerText = character.name;
            root.AppendChild(node);

            node = xmldoc.CreateElement("CharacterClass");
            node.InnerText = character.charClass;
            root.AppendChild(node);

            node = xmldoc.CreateElement("AttackPower");
            node.InnerText = character.attack.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Defense");
            node.InnerText = character.defense.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Intelligence");
            node.InnerText = character.intelligence.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Dexterity");
            node.InnerText = character.dexterity.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Constitution");
            node.InnerText = character.constitution.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Charisma");
            node.InnerText = character.charisma.ToString();
            root.AppendChild(node);

            xmldoc.Save(@"Y:\Programming\C#\Learning Projects - Console\RPG Character Generator\RPG Character Generator\Character.xml");  // Eventually allow the user to name the save file.
            Console.WriteLine("Saved!");
            Console.ReadKey();                       
        }

        public static void LoadCharacter()
        {
            Console.WriteLine("This function loads a character...");
        }

    }
}

#region Future Plans

// LATER

// Load a file for editing.

// Open a new file for editing or generate a character

// Generate stats based off role chosen. 

// Generate monsters.. 

// Generate towns

// Generate special artifact items.
#endregion
