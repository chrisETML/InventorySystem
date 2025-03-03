/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 24.01.2025
Description : Système pour sauvegarder l'inventaire dans un fichier CSV et load la sauvegarde
*/

using System.Collections.Generic;
using System;
using System.IO;
using WorldSystem;
using static WorldSystem.Material_List;

namespace InventorySystem
{
    internal static class SaveSystem
    {
        private const Byte ESPACE = 5;
        public static void SaveToCsv(List<IItem> items, string filePath)
        {
            string csvContent = "";

            // Ajout des items dans la variable avant d'envoyer au CSV
            foreach (IItem item in items)
                csvContent += item.ToCsvLine() + "\n";

            File.WriteAllText(filePath, csvContent);
            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);            
        }

        public static List<IItem> LoadFromCsv(string filePath)
        {
            List<IItem> items = new List<IItem>();

            // Lire toutes les lignes du fichier CSV
            string[] lines = File.ReadAllLines(filePath);

            // Ignorer l'entête et charger les items
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0].Trim() == "null")
                {
                    items.Add(null);
                }

                else if (Enum.TryParse(parts[0].Trim(), out Category category))
                {
                    // Si la catégorie est "Resource", créer un objet Resource
                    if (category == Category.Resource)
                    {
                        if (Enum.TryParse(parts[1].Trim(), out Rarity rarity))
                            if (int.TryParse(parts[4].Trim(), out int quantity))
                            {
                                foreach (Material newMaterial in Materials)
                                {
                                    if (newMaterial.Name == parts[2].Trim())
                                        items.Add(new Resource(quantity, newMaterial, Rarity.Rare));
                                }
                            }
                    }
                    // Si la catégorie est "Sword", créer un objet Sword
                    else if (category == Category.Sword)
                    {
                        if (Enum.TryParse(parts[1].Trim(), out Rarity rarity))
                            if (Enum.TryParse(parts[2].Trim(), out SwordName swordName))
                                if (int.TryParse(parts[4].Trim(), out int quantity))
                                {
                                    foreach (Material newMaterial in Materials)
                                    {
                                        if (newMaterial.Name == parts[3].Trim())
                                            items.Add(new Sword(quantity, rarity, new Resource(quantity, newMaterial, Rarity.Rare), swordName));
                                    }

                                }
                    }
                    // Si la catégorie est "Shield", créer un objet Shield
                    else if (category == Category.Shield)
                    {
                        if (Enum.TryParse(parts[1].Trim(), out Rarity rarity))
                            if (Enum.TryParse(parts[2].Trim(), out ShieldName shieldName))
                                if (int.TryParse(parts[4].Trim(), out int quantity))
                                {
                                    foreach (Material newMaterial in Materials)
                                    {
                                        if (newMaterial.Name == parts[3].Trim())
                                            items.Add(new Shield(quantity, new Resource(quantity, newMaterial, Rarity.Rare), rarity, shieldName));
                                    }

                                }
                    }
                }
                else
                {
                    Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
                    Console.Write("                                                                                 ");
                    Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
                    Console.Write($"Catégorie non reconnue: {category}");
                }
            }

            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
            Console.Write("                                                                                              ");
            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
            Console.Write($"Fichier chargé");
            return items;
        }

        public static void SaveToCsv4(List<IItem> items, string filePath)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items to save.");
                return;
            }

            string csvContent = "";

            // Iterate through the items in the list and ensure none of them are null
            foreach (IItem item in items)
            {
                if (item != null)  // Skip null items
                {
                    csvContent += item.ToCsvLine() + "\n";
                }
                else
                {
                    csvContent+= "null\n";
                }
            }

            // If no valid items were found, skip saving
            if (string.IsNullOrEmpty(csvContent))
            {
                Console.WriteLine("No valid items to save.");
                return;
            }

            // Save the valid items to the file
            File.WriteAllText(filePath, csvContent);
            //Console.WriteLine($"Saved {items.Count} items to {filePath}");
        }

    }
}

