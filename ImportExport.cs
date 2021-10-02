using System;
using System.IO;
using System.Xml;

namespace RPG_Character_Generator
{
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

            node = xmldoc.CreateElement("Level");
            node.InnerText = character.level.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Role");
            node.InnerText = character.role.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("AttackPower");
            node.InnerText = character.attack.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("Defense");
            node.InnerText = character.defense.ToString();
            root.AppendChild(node);

            node = xmldoc.CreateElement("HP");
            node.InnerText = character.hp.ToString();
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

            xmldoc.Save(@"Y:\Programming\C#\Learning Projects - Console\RPG Character Generator\RPG Character Generator\" + character.name + ".xml");  // Eventually allow the user to name the save file.
            Console.WriteLine("Saved!");
            Console.ReadKey();
        }

        public static void LoadCharacter(Character character)  // Console.WriteLine("This function loads a character...");
        {
            string entry = "";


        NameEntry:
            try
            {
                Console.WriteLine("What character do you want to load?");
                entry = Console.ReadLine().Trim();

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(@"Y:\Programming\C#\Learning Projects - Console\RPG Character Generator\RPG Character Generator\" + entry + ".xml");


                foreach (XmlNode xmlnode in xmldoc.DocumentElement.ChildNodes)
                {
                    if (xmlnode.Name == "Name")
                        character.name = xmlnode.InnerText;

                    if (xmlnode.Name == "CharacterClass")
                        character.charClass = xmlnode.InnerText;

                    if (xmlnode.Name == "Level")
                        character.level = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "AttackPower")
                        character.attack = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "Defense")
                        character.defense = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "HP")
                        character.hp = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "Intelligence")
                        character.intelligence = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "Dexterity")
                        character.dexterity = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "Constitution")
                        character.constitution = Convert.ToInt32(xmlnode.InnerText);

                    if (xmlnode.Name == "Charisma")
                        character.charisma = Convert.ToInt32(xmlnode.InnerText);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("I dunno who that is.  Lets try that again.\n");
                Console.ReadKey();
                Console.Clear();
                goto NameEntry;
            }

            Console.ReadKey();
        }

    }
}
