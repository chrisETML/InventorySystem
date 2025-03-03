/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Classe pour le système d'inventaire
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using WorldSystem;

namespace InventorySystem
{
    internal sealed class Inventory
    {
        /// <summary>
        ///Position pour l'affichage de l'inventaire
        /// </summary>
        public static Vector2 Actualposition;
        public Vector2 DefaultPosition;
        public List<IItem> Items { get; private set; }
        public const int MaxCapacity = 100;
        private int currentCapacity;
        public Inventory()
        {
            DefaultPosition.X = Actualposition.X = 130;
            DefaultPosition.Y = Actualposition.Y = 5;
            Items = new List<IItem>();
        }

        public void AddItem(IItem item, Vector2 inputPosition, bool inputUsage)
        {
            int availableSpace = MaxCapacity - currentCapacity;
            string input = string.Empty;

            if (inputUsage)
            {
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write($"Ajouter {item.Category} dans inventaire (y,n) : ");
                input = Console.ReadLine();
            }

            if (input == "y" || !inputUsage)
            {
                if (item is Resource newResource)
                {
                    // Recherche d'une resource identique (même matériau et même rareté)
                    Resource existingResource = Items.OfType<Resource>()
                        .FirstOrDefault(r => r.Material.Name == newResource.Material.Name
                                          && r.Rarity == newResource.Rarity);

                    if (existingResource != null)
                    {
                        // Calcul du poids additionnel nécessaire pour la quantité à ajouter
                        int additionalWeight = newResource.Quantity * newResource.Material.Weight;

                        // Vérifier que l'ajout du nouveau poids ne dépasse pas la capacité
                        if (newResource.TotalWeight <= availableSpace)
                        {
                            // Mise à jour de la quantité
                            existingResource.Quantity += newResource.Quantity;
                            // Mise à jour du poids total : ici on recalcule en multipliant la nouvelle quantité par le poids unitaire
                            existingResource.TotalWeight = existingResource.Quantity * newResource.Material.Weight;
                            // Mise à jour de la capacité occupée
                            currentCapacity += additionalWeight;
                        }
                        else
                        {
                            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                            Console.Write("                                                                                           ");
                            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
                            Console.Write("Pas assez d'espace.");
                        }
                    }
                    else
                    {
                        if (newResource.TotalWeight <= availableSpace)
                        {
                            Items.Add(newResource);
                            currentCapacity += newResource.TotalWeight;
                        }
                        else
                        {
                            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                            Console.Write("                                                                                           ");
                            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
                            Console.Write("Pas assez d'espace.");
                        }
                    }
                }
                else if (item is Sword sword)
                {
                    if (sword.SwordWeight <= availableSpace)
                    {
                        Items.Add(item);
                        currentCapacity += sword.SwordWeight;
                    }
                    else
                    {
                        Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                        Console.Write("                                                                                           ");
                        Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
                        Console.Write("Pas assez d'espace.");
                    }
                }
                else if (item is Shield shield)
                {
                    if (shield.ShieldWeight <= availableSpace)
                    {
                        Items.Add(item);
                        currentCapacity += shield.ShieldWeight;

                    }
                    else
                    {
                        Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                        Console.Write("                                                                                           ");
                        Console.WriteLine("Pas assez d'espace.");
                    }
                }

                int index = Program.worldItems.IndexOf(item);
                if (index != -1)
                {
                    Program.worldItems[index] = null;
                }
            }
        }

        public IItem GetItemFromInventory(int itemNumber)
        {
            if (itemNumber >= 0 && itemNumber < Items.Count)
            {
                IItem copyItem = Items[itemNumber];
                RemoveItemFromInventory(itemNumber);
                return copyItem;
            }
            return null;
        }

        private void RemoveItemFromInventory(int itemNumber)
        {
            if (itemNumber >= 0 && itemNumber < Items.Count)
            {
                if (Items[itemNumber] is Resource resource)
                {
                    currentCapacity -= resource.TotalWeight;
                }
                else if (Items[itemNumber] is Sword sword)
                {
                    currentCapacity -= sword.SwordWeight;
                }
                else if (Items[itemNumber] is Shield shield)
                {
                    currentCapacity -= shield.ShieldWeight;
                }
                Items.RemoveAt(itemNumber);
            }
        }

        public void Save(Vector2 inputPosition)
        {
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("Sauvegarder inventaire (y,n) : ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("Nom du fichier : ");

                input = Console.ReadLine();

                SaveSystem.SaveToCsv(Items, $@"{Environment.CurrentDirectory}\{input}.csv");
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
                Console.Write($"Inventaire sauvegardé");
            }
        }

        public void Load(Vector2 inputPosition)
        {
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y + 1);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
            Console.Write("Charger inventaire (y,n) : ");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)inputPosition.X, (int)inputPosition.Y);
                Console.Write("Nom du fichier : ");
                input = Console.ReadLine();

                foreach (IItem item in SaveSystem.LoadFromCsv($@"{Environment.CurrentDirectory}\{input}"))
                {
                    AddItem(item, inputPosition, false);
                }
                DisplayInventory();
            }
        }

        public void DisplayInventory()
        {
            RefreshInventory();
            // Déplace le curseur à la position spécifiée par le Vector2
            Console.SetCursorPosition((int)Actualposition.X, (int)Actualposition.Y);

            // Affiche l'inventaire
            Console.Write("Inventaire : ");
            Console.Write("Poids ");

            // Calcul du ratio de capacité utilisée
            double ratio = (double)currentCapacity / MaxCapacity;

            // Choix de la couleur selon le ratio
            if (ratio < 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ratio < 0.8)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            // Affichage du poids actuel avec la couleur choisie
            Console.Write(currentCapacity);
            Console.ResetColor();

            // Affichage du reste du texte
            Console.Write($"/{MaxCapacity} kg");

            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("----------------------------------------------------------------------");

            // Affichage des items avec une taille d'affichage pour chaque colonne
            uint count = 0;
            foreach (IItem item in Items)
            {
                Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);

                if (item is Resource resource)
                    Console.WriteLine($"| n°{count} {resource.Material.Name.PadRight(Enum.GetNames(typeof(ShieldName)).Max(name => name.Length))} | {resource.Category.ToString().PadRight(Enum.GetNames(typeof(Category)).Max(name => name.Length))} | x{resource.Quantity,-4} | {resource.TotalWeight,3} kg |");
                else if (item is Sword sword)
                    Console.WriteLine($"| n°{count} {sword.SwordName.ToString().PadRight(Enum.GetNames(typeof(ShieldName)).Max(name => name.Length))} | {sword.Category.ToString().PadRight(Enum.GetNames(typeof(Category)).Max(name => name.Length))} | x{sword.Quantity,-4} | {sword.SwordWeight,3} kg |");
                else if (item is Shield shield)
                    Console.WriteLine($"| n°{count} {shield.ShieldName.ToString().PadRight(Enum.GetNames(typeof(ShieldName)).Max(name => name.Length))} | {shield.Category.ToString().PadRight(Enum.GetNames(typeof(Category)).Max(name => name.Length))} | x{shield.Quantity,-4} | {shield.ShieldWeight,3} kg |");

                ++count;
            }
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.Write("----------------------------------------------------------------------");
            Console.ResetColor();
        }

        private void RefreshInventory()
        {
            Actualposition = DefaultPosition;

            for (int i = 0; i < Items.Count + 3; ++i)
            {
                Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
                Console.Write("                                                                       ");
            }
            Actualposition = DefaultPosition;
        }
    }
}
