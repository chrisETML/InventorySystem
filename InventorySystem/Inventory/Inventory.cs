/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Classe pour le système d'inventaire
*/

using System;
using System.Collections.Generic;
using System.Numerics;
using WorldSystem;

namespace InventorySystem
{
    internal class Inventory
    {
        /// <summary>
        ///Position pour l'affichage de l'inventaire
        /// </summary>
        public static Vector2 ConsolePosition;
        public List<IItem> Items {get; private set;}
        public const int MaxCapacity = 30; 
        private int currentCapacity;
        public Inventory()
        {
            ConsolePosition.X = 100;
            ConsolePosition.Y = 20;
            Items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            int availableSpace = MaxCapacity - currentCapacity;

            // Vérification si l'espace disponible est suffisant pour ajouter l'objet
            if (item.Quantity <= availableSpace)
            {
                // Ajouter l'objet si l'espace est suffisant
                Items.Add(item);
                currentCapacity += item.Quantity;  // Mettre à jour la capacité actuelle
            }
        }

        public void DisplayInventory()
        {
            // Déplace le curseur à la position spécifiée par le Vector2
            Console.SetCursorPosition((int)ConsolePosition.X, (int)ConsolePosition.Y);

            // Affiche l'inventaire
            Console.Write($"Inventaire :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Poids {currentCapacity}/{MaxCapacity}");

            Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
            Console.WriteLine("------------------------------------------------");

            // Affichage des items avec une taille d'affichage pour chaque colonne
            uint count = 0;
            foreach (var item in Items)
            {
                Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
                Console.WriteLine($"| n°{count} {item.Material,-15} | {item.Quantity,-10} |");
                ++count;
            }
            Console.SetCursorPosition((int)ConsolePosition.X, (int)++ConsolePosition.Y);
            Console.WriteLine("------------------------------------------------");
            Console.ResetColor();
        }
    }
}
