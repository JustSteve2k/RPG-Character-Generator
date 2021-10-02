using System;
using System.Collections.Generic;
using System.Threading;

namespace RPG_Character_Generator
{
    class Character
    {
        public string name { get; set; }

        public string charClass { get; set; }

        public int level { get; set; }

        public int attack { get; set; }

        public int defense { get; set; }

        public int hp { get; set; }

        public int intelligence { get; set; }

        public int dexterity { get; set; }

        public int constitution { get; set; }

        public int charisma { get; set; }

        public string role { get; set; }

        // Other stats to make - characterdescription, alignment, hometown, occupation, age, money;

        public Character()  // Character Constructor - 
        {
            name = "";
            charClass = "Novice";
            role = "Newbie";
            level = 1;
            attack = 0;
            defense = 0;
            hp = 0;
            intelligence = 0;
            dexterity = 0;
            constitution = 0;
            charisma = 0;
        }

        public void GenerateCharacter()  // Maybe make something that genrates a tank / healer / spellcaster / melee dps depending on input.
        {
            Random rand = new Random();

            Console.Write("\nGenerating character");
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write(".");
            Thread.Sleep(800);

            name = GenerateName();
            role = "Newbie";  // need something to randomly pick the role.
            level = 1;
            attack = rand.Next(10, 25);
            defense = rand.Next(10, 20);
            hp = rand.Next(20, 35);
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

            Console.WriteLine("Whats your characters HP?");
            hp = Convert.ToInt32(Console.ReadLine());

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
            Console.WriteLine($"Your level is {level}.");
            Console.WriteLine($"Your characters class is {charClass}.");
            Console.WriteLine($"Your attack is {attack}.");
            Console.WriteLine($"Your defense is {defense}.");
            Console.WriteLine($"Your HP is {hp}.");
            Console.WriteLine($"Your intelligence is {intelligence}.");
            Console.WriteLine($"Your dexterity is {dexterity}.");
            Console.WriteLine($"Your constitution is {constitution}.");
            Console.WriteLine($"Your charisma is {charisma}.");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowStatsOnRight()  // Utilize border with this
        {
            int xpos = 80;
            int ypos = 2;
            
            StatsOnRightVertBorders();

            Console.SetCursorPosition(80, 2);
            Console.WriteLine("------------------------");
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("Your stats are:");
            Console.SetCursorPosition(80, 4);
            Console.WriteLine($"NAME: {name}.");
            Console.SetCursorPosition(80, 5);
            Console.WriteLine($"LVL: {level}.");
            Console.SetCursorPosition(80, 6);
            Console.WriteLine($"CLASS: {charClass}.");
            Console.SetCursorPosition(80, 7);
            Console.WriteLine($"ROLE: {role}.");
            Console.SetCursorPosition(80, 8);
            Console.WriteLine($"ATK: {attack}.");
            Console.SetCursorPosition(80, 9);
            Console.WriteLine($"DEF: {defense}.");
            Console.SetCursorPosition(80, 10);
            Console.WriteLine($"HP:  {hp}.");
            Console.SetCursorPosition(80, 11);
            Console.WriteLine($"INT: {intelligence}.");
            Console.SetCursorPosition(80, 12);
            Console.WriteLine($"DEX: {dexterity}.");
            Console.SetCursorPosition(80, 13);
            Console.WriteLine($"CON: {constitution}.");
            Console.SetCursorPosition(80, 14);
            Console.WriteLine($"CHA: {charisma}.");
            Console.SetCursorPosition(80, 15);
            Console.WriteLine("------------------------");
        }

        private void StatsOnRightVertBorders()
        {
            for (int x = 3; x < 15; x++)
            {
                Console.SetCursorPosition(78, x);
                Console.WriteLine("|");

                Console.SetCursorPosition(104, x);
                Console.WriteLine("|");
            }
        }

        public void ChangeCharacterName()
        {
            Console.WriteLine("What is your characters new name?");
            name = Console.ReadLine();
            Console.WriteLine("\nNice to meet you {0}!", name);

            Console.ReadKey();
        }

        public void ChangeCharacterRole()
        {
            string entry;
            Console.WriteLine("Do you want a Tank / Healer / DPS");

            entry = Console.ReadLine().ToLower().Trim();

            role = entry;
        }

        //public void LevelUp()  // Old level  up function before roles implemented.
        //{
        //    level++;
        //    UpdateStatsGeneral();

        //    Console.WriteLine($"LEVEL UP! your new level is {level}.");

        //    Console.ReadKey();
        //}

        public void LevelUp( ) // to be used with overloads passing in the character class
        {
            level++;

            switch (role)
                {
                case "tank":
                    
                    UpdateStatsTank();
                    break;

                case "healer":                    
                    UpdateStatsHealer();
                    break;

                case "dps":                    
                    UpdateStatsDPS();
                    break;

                default:                    
                    UpdateStatsGeneral();
                    break;
            }


            Console.WriteLine($"LEVEL UP! your new level is {level}.");

            Console.ReadKey();

        }

        private void UpdateStatsGeneral()
        {
            Random rand = new Random();

            attack += rand.Next(1, 3);
            defense += rand.Next(1, 3);
            hp += rand.Next(3, 5);
            intelligence += rand.Next(1, 2);
            dexterity += rand.Next(1, 2);
            constitution += rand.Next(1, 2);
            charisma += rand.Next(1, 2);
        }

        private void UpdateStatsTank()  // modifier passed in can raise stats.  AKA Juggernaut passed in can raise upper cap on defense and con.
        {
            Random rand = new Random();

            attack += rand.Next(1, 2);
            defense += rand.Next(1, 5);
            hp += rand.Next(3, 8);
            intelligence += rand.Next(1, 2);
            dexterity += rand.Next(1, 2);
            constitution += rand.Next(1, 4);
            charisma += rand.Next(1, 2);
        }

        private void UpdateStatsHealer()
        {
            Random rand = new Random();

            attack += rand.Next(1, 4);
            defense += rand.Next(1, 2);
            hp += rand.Next(3, 3);
            intelligence += rand.Next(1, 4);
            dexterity += rand.Next(1, 2);
            constitution += rand.Next(1, 3);
            charisma += rand.Next(1, 3);
        }

        private void UpdateStatsDPS()
        {
            Random rand = new Random();

            attack += rand.Next(1, 4);
            defense += rand.Next(1, 2);
            hp += rand.Next(3, 4);
            intelligence += rand.Next(1, 3);
            dexterity += rand.Next(1, 4);
            constitution += rand.Next(1, 2);
            charisma += rand.Next(1, 3);
        }

        public void PlaceHolder()
        {
            Console.WriteLine("This function is not ready yet!");
            
            Console.ReadKey();
        }

        public void LevelUpJump()  // Needs to be cleaned up somehow.
        {
            int choice;

            Console.WriteLine("What level do you want to jump to?");
            choice = Convert.ToInt32(Console.ReadLine());

            for (int x = level; x < choice; x++)
            {
                level++;
                switch (role)
                {
                    case "tank":
                        UpdateStatsTank();
                        break;

                    case "healer":
                        UpdateStatsHealer();
                        break;

                    case "dps":
                        UpdateStatsDPS();
                        break;

                    default:
                        UpdateStatsGeneral();
                        break;
                }
            }

            Console.WriteLine("{0} is leveled up to {1}!", name, level);

            Console.ReadKey();
        }

        public void LevelUpMax() // Not used anymore
        {

            for (int x = level; x < 99; x++)
            {
                level++;
                UpdateStatsGeneral();
            }

            Console.WriteLine("{0} is leveled up to {1}!", name, level);

            Console.ReadKey();
        }


        private string GenerateName()
        {
            Random rand = new Random();
            int temp = 0;

            List<string> names = new List<string> { "Riggalo", "Zenith", "Quasar", "Nero", "Samson", "Elian", "Ragnar", "Ignis", "Bariten", "Arthas", "Elian", "Wanderer"};

            temp = rand.Next(names.Count);

            return names[temp];
        }

       
    }
}
