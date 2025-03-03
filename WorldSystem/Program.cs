/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using static WorldSystem.Material_List;
using InventorySystem;
using System.IO.Ports;
using System.IO;

namespace WorldSystem
{
    internal class Program
    {

        // Déclaration de la fonction Windows qui peut être utilisée pour manipuler la fenêtre
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Constantes utilisées pour manipuler la fenêtre
        const int SW_MAXIMIZE = 3;
        static Vector2 GroundPosition = new Vector2(10, 40);
        static Vector2 InputPosition = new Vector2(GroundPosition.X, GroundPosition.Y + 2);
        static Inventory inventory = new Inventory();

        static Random random = new Random();
        static Array rarity = Enum.GetValues(typeof(Rarity));

        public static List<IItem> worldItems = new List<IItem>()
        {
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Resource(Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Material:Materials[random.Next(Materials.Count)]),
            new Sword   (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Sword   (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Sword   (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Shield  (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Shield  (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Shield  (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            new Shield  (Quantity:random.Next(1, 10), Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)), Resource:new Resource(Quantity:1, Material:Materials[random.Next(Materials.Count)], Rarity:(Rarity)rarity.GetValue(random.Next(rarity.Length)))),
            null,
            null,
            null
        };
        static void Main(string[] args)
        {

            Console.ReadLine();
            Vector2 ItemsPosition = GroundPosition;
            Vector2 DisplayPosition = new Vector2(2, 2);
            IntPtr hWnd = GetConsoleWindow();

            // Maximiser la fenêtre
            ShowWindow(hWnd, SW_MAXIMIZE);

            // Randomize the list
            worldItems = worldItems.OrderBy(x => random.Next()).ToList();

            Console.SetCursorPosition((int)GroundPosition.X, (int)GroundPosition.Y);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");

            inventory.DisplayInventory();

            // Ask the user if they want to save the world items
            Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
            Console.Write("load world items (y,n) : ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                // Prompt the user for the file name
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("Nom du fichier : ");
                input = Console.ReadLine();

                // Ensure a valid file name is provided
                worldItems = SaveSystem.LoadFromCsv($@"{Environment.CurrentDirectory}\{input}");

                // Provide confirmation
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y + 1);
                Console.Write($"World items sauvegardé");
            }

            DisplayWorldItems(ItemsPosition, worldItems);

            SaveWorldItemsToCsv(InputPosition);

            inventory.Load(InputPosition);

            while (true)
            {
                // Ask for the index first
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("Entrer le numero de l'objet de 0 à " + (worldItems.Count - 1) + ": ");
                input = Console.ReadLine();
                // Read the user input


                int index;  // Declare the index variable

                // Try to parse the user input into an integer
                if (int.TryParse(input, out index))
                {
                    if (index >= 0 && index < worldItems.Count) // Check if the index is valid
                    {
                        Console.Write("                                                                                           ");
                        IItem selectedItem = worldItems[index];

                        // Call Display method based on the type of the selected item
                        if (selectedItem is Sword thisSword)
                        {
                            thisSword.Display(DisplayPosition, InputPosition, worldItems.Count);
                        }
                        else if (selectedItem is Shield thisShield)
                        {
                            thisShield.Display(DisplayPosition, InputPosition, worldItems.Count);
                        }
                        else if (selectedItem is Resource thisResource)
                        {
                            thisResource.Display(DisplayPosition, InputPosition, worldItems.Count);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y + 1);
                        Console.Write("Index hors limites. Veuillez entrer un index valide.");
                        Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                        Console.Write("                                                                                           ");
                        Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                        Console.Write("Entrer le numero de l'objet de 0 à " + (worldItems.Count - 1) + "): ");
                    }
                }
                else
                {
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y + 1);
                    Console.Write("Entrée invalide. Veuillez entrer un nombre entier.  ");
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("                                                                                           ");
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("Entrer le numero de l'objet de 0 à " + (worldItems.Count - 1) + "): ");
                }

                Console.SetCursorPosition((int)GroundPosition.X, (int)GroundPosition.Y);
                Console.WriteLine("-----------------------------------------------------------------");

                inventory.AddItem(worldItems[int.Parse(input)], InputPosition, true);
                DisplayWorldItems(ItemsPosition, worldItems);

                inventory.DisplayInventory();
                inventory.Save(InputPosition);
                inventory.DisplayInventory();

                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                Console.Write("prendre item de l'inventaire (y, n): ");
                input = Console.ReadLine();

                if (input == "y")
                {
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("                                                                                           ");
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("Item de l'inventaire n°: ");
                    input = Console.ReadLine();
                    IItem ReturnedItem = inventory.GetItemFromInventory(int.Parse(input));

                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("                                                                                           ");
                    Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
                    Console.Write("Ou mettere l'objet n°: ");
                    input = Console.ReadLine();

                    worldItems[int.Parse(input)] = ReturnedItem;
                    DisplayWorldItems(ItemsPosition, worldItems);
                    inventory.DisplayInventory();
                }
            }
        }

        public static void DisplayWorldItems(Vector2 ItemsPosition, List<IItem> worldItems)
        {
            int counter = 0;

            Console.SetCursorPosition((int)GroundPosition.X, (int)GroundPosition.Y - 1);
            Console.Write("                                                                                           ");

            foreach (IItem item in worldItems)
            {
                Console.SetCursorPosition((int)(ItemsPosition.X += 3), (int)GroundPosition.Y - 1);

                if (item != null)
                {
                    Console.ForegroundColor = ColorItem(item);

                    Console.Write($" {RetourneChar(item)}  ");

                    Console.ResetColor();
                }

                else
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition((int)(ItemsPosition.X), (int)GroundPosition.Y - 2);

                Console.Write($" {counter++} ");
            }
        }

        static ConsoleColor ColorItem(IItem item)
        {
            if (item is Resource resource)
                return ColorMaterial(resource.Material);
            if (item is Shield shield)
                return ColorMaterial(shield.Resource.Material);
            if (item is Sword sword)
                return ColorMaterial(sword.Resource.Material);
            else
                return ConsoleColor.White;
        }

        static ConsoleColor ColorMaterial(Material Material)
        {
            switch (Material.Name)
            {
                case "wood":
                    return ConsoleColor.DarkRed;
                case "stone":
                    return ConsoleColor.Green;
                case "iron":
                    return ConsoleColor.Red;
                case "steel":
                    return ConsoleColor.DarkGray;
                case "silver":
                    return ConsoleColor.Gray;
                case "gold":
                    return ConsoleColor.Yellow;
                case "diamond":
                    return ConsoleColor.Cyan;
                default:
                    break;
            }
            return ConsoleColor.White;
        }

        static char RetourneChar(IItem item)
        {
            if (item is Resource)
                return 'R';
            if (item is Shield)
                return 'S';
            if (item is Sword)
                return 'T';
            else
                return 'E';
        }

        public static void SaveWorldItemsToCsv(Vector2 inputPosition)
        {
            if (worldItems == null || worldItems.Count == 0)
            {
                Console.WriteLine("No world items to save.");
                return;
            }

            // Ask the user if they want to save the world items
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("Sauvegarder world items (y,n) : ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                // Prompt the user for the file name
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("Nom du fichier : ");
                input = Console.ReadLine();

                // Ensure a valid file name is provided
                string filePath = $@"{Environment.CurrentDirectory}\{input}.csv";

                // Save the world items to the CSV file
                SaveSystem.SaveToCsv4(worldItems, filePath);

                // Provide confirmation

                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
                Console.Write($"World items sauvegardé");
            }
        }
    }
}

