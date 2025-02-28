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
        public static Vector2 Actualposition;
        public Vector2 DefaultPosition;
        public List<IItem> Items {get; private set;}
        public const int MaxCapacity = 30; 
        private int currentCapacity;
        public Inventory()
        {
            DefaultPosition.X = Actualposition.X = 160;
            DefaultPosition.Y = Actualposition.Y = 5;
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

        public object GetItemFromInventory(int itemNumber)
        {
            Console.SetCursorPosition((int)Actualposition.X, (int)Actualposition.Y + 1);
            Console.Write("N° item à récupérer : ");
            if (itemNumber >= 0 && itemNumber < Items.Count)
                return Items[itemNumber];

            return null;
        }

        public void RemoveItemFromInventory(int itemNumber)
        {
            if (itemNumber >= 0 && itemNumber < Items.Count)
                Items.RemoveAt(itemNumber);
        }


        public void DisplayInventory()
        {
            RefreshInventory();
            // Déplace le curseur à la position spécifiée par le Vector2
            Console.SetCursorPosition((int)Actualposition.X, (int)Actualposition.Y);

            // Affiche l'inventaire
            Console.Write($"Inventaire : ");
            Console.Write($"Poids {currentCapacity}/{MaxCapacity}");

            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("------------------------------------------------");

            // Affichage des items avec une taille d'affichage pour chaque colonne
            uint count = 0;
            foreach (IItem item in Items)
            {
                Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
                Console.WriteLine($"| n°{count} {item.Material,-15} | x{item.Quantity,-4} |");
                ++count;
            }
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("------------------------------------------------");
            Console.ResetColor();
        }

        private void RefreshInventory()
        {
            Actualposition = DefaultPosition;
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("                                                         ");
            Actualposition = DefaultPosition;
        }
    }
}
