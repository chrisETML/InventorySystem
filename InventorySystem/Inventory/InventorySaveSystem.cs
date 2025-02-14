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

namespace InventorySystem
{
    internal static class InventorySaveSystem
    {
        private const Byte ESPACE = 5;
        public static void SaveToCsv(List<IItem> items, string filePath)
        {
            string csvContent = "";

            // Ajout des items dans la variable avant d'envoyer au CSV
            foreach (IItem item in items)
                csvContent += item.ToCsvLine();
            
            File.WriteAllText(filePath, csvContent);
            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
            Console.Write($"Inventaire sauvegardé");
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
                
                if (Enum.TryParse(parts[0].Trim(), out Category category))
                {
                    // Si la catégorie est "Resource", créer un objet Resource
                    if (category == Category.Resource)
                    {
                        if (Enum.TryParse(parts[1].Trim(), out Rarity rarity))
                            if (Enum.TryParse(parts[2].Trim(), out Material material))
                                if (int.TryParse(parts[3].Trim(), out int price))
                                    if (int.TryParse(parts[4].Trim(), out int quantity))
                                        //TODO constructeur Material() a donner a Resource!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                        items.Add(new Resource(rarity, material, price, quantity));
                    }
                    else
                    {
                        Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
                        Console.Write("                                                                                 ");
                        Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
                        Console.Write($"Catégorie non reconnue: {category}");
                    }                        
                }
            }
            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
            Console.Write("                                                                                              ");
            Console.SetCursorPosition((int)Inventory.Actualposition.X, (int)Inventory.Actualposition.Y + items.Count + ESPACE);
            Console.Write($"Inventaire chargé");
            return items;
        }
    }
}
