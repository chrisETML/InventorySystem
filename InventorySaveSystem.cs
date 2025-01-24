/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 24.01.2025
Description : Système pour sauvegarder l'inventaire dans un fichier CSV et load la sauvegarde
*/

using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace InventorySystem
{
    internal class InventorySaveSystem
    {
        public void SaveToCsv(List<IResource> items, string filePath)
        {
            var csvContent = "Name,Quantity\n";  // Entête du CSV

            foreach (var item in items)
            {
                csvContent += $"{item.Name},{item.Quantity}\n";
            }

            File.WriteAllText(filePath, csvContent);
            Console.WriteLine($"Inventaire sauvegardé dans le fichier CSV : {filePath}");
        }

        
        public List<IItem> LoadFromCsv(string filePath)
        {
            var items = new List<IItem>();

            // Lire toutes les lignes du fichier CSV
            var lines = File.ReadAllLines(filePath);

            // Ignorer l'entête et charger les items
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                var name = parts[0].Trim();
                var quantity = int.Parse(parts[1].Trim());

                items.Add(new Obj(name, quantity));
            }

            Console.WriteLine($"Inventaire chargé depuis le fichier CSV : {filePath}");
            return items;
        }
    }
}
