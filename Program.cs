using System;
using System.Xml;

namespace RPG_Character_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, entry;
            int attack, defense; // Add additional parameters later.
            XmlDocument xmldoc = new XmlDocument();

            Console.WriteLine("Welcome to the character generator");

            // Menu - New Character, Load Character ( Or party Eventually ), Randomly Generate Character (Skips next few steps)
            // Need to move menu to functions or classes.

            Menu();

            Console.WriteLine("Whats your characters name?");
            name = Console.ReadLine();

            Console.WriteLine("Whats your characters attack power?");
            attack = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Whats your characters defense?");
            defense = Convert.ToInt32(Console.ReadLine());

            ShowStats(name, attack, defense);
            Console.ReadKey();

            Console.WriteLine("Would you like to save to a file? (Y)Yes or (N)No?");
            entry = Console.ReadLine().ToLower();

            if (entry == "yes" || entry == "y")
            {
                XmlNode root, node;
                root = xmldoc.CreateElement("Character");
                xmldoc.AppendChild(root);

                node = xmldoc.CreateElement("Name");
                node.InnerText = name;
                root.AppendChild(node);

                node = xmldoc.CreateElement("AttackPower");
                node.InnerText = attack.ToString();
                root.AppendChild(node);

                node = xmldoc.CreateElement("Defense");
                node.InnerText = defense.ToString();
                root.AppendChild(node);

                xmldoc.Save(@"Y:\Programming\C#\Learning Projects - Console\RPG Character Generator\RPG Character Generator\Character.xml");  // Eventually allow the user to name the save file.
                Console.WriteLine("Saved!");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Not saved!");
                Console.ReadKey();
            }

        }

        public static void Menu()
        {
            string entry;
            
            Console.WriteLine("Welcome to the Character Generator!\n\n");
            Console.WriteLine("Choose how to proceed:");
            Console.WriteLine("(A)Generate a new character.");
            Console.WriteLine("(B)Load an exsisting character.");
            Console.WriteLine("(C)Manually enter a new character");
            Console.WriteLine("(D)Nvm, go do something else.");

            entry = Console.ReadLine();

            switch (entry)
            {
                case ("A"):
                    Console.WriteLine("Case A");
                    break;

                default:
                    Console.WriteLine("Wat.");
                    break;
            }
        }
        
        
        public static void ShowStats(string name, int attack, int defense)
        {
            Console.Clear();
            Console.WriteLine("Your stats are:\n");
            Console.WriteLine($"Your characters name is {name}.");
            Console.WriteLine($"Your attack is {attack}.");
            Console.WriteLine($"Your defense is {defense}.");

        }

        public static void generateStats()
        {
            Console.WriteLine("Generate stats with generator.");
        }


    }
}


#region Future Plans
// Have user enter char name and stats and save it to an xml file

//  Show stats then save.

// LATER

// Load a file for editing.

// Open a new file for editing or generate a character

// IF generate, make from random stats or provide starting stats.

// Generate monsters
#endregion
