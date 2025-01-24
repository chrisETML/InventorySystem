/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Classe pour le système d'inventaire
*/

using System;
using System.Collections.Generic;
using System.Numerics;

namespace InventorySystem
{
    internal class Inventory
    {
        private Vector2 ConsolePosition;
        private List<IItem> items;
        public Inventory()
        {
            ConsolePosition.X = 50;
            ConsolePosition.Y = 20;
            items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public void DisplayInventory()
        {
            // Déplace le curseur à la position spécifiée par le Vector2
            Console.SetCursorPosition((int)ConsolePosition.X, (int)ConsolePosition.Y);

            // Affiche un titre du tableau
            Console.WriteLine("Inventory:");
            Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
            Console.WriteLine("------------------------------------------------");

            // Affichage des items avec une taille d'affichage pour chaque colonne
            foreach (var item in items)
            {
                Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
                Console.WriteLine($"| {item.Name,-15} | {item.Quantity,-10} |");
            }
            Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
            Console.WriteLine("------------------------------------------------");
        }
    }
}
