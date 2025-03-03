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
    internal sealed class Inventory
    {
        /// <summary>
        ///Position pour l'affichage de l'inventaire
        /// </summary>
        public static Vector2 Actualposition;
        public Vector2 DefaultPosition;
        public List<IItem> Items { get; private set; }
        public const int MaxCapacity = 300;
        private int currentCapacity;
        public Inventory()
        {
            DefaultPosition.X = Actualposition.X = 140;
            DefaultPosition.Y = Actualposition.Y = 5;
            Items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            int availableSpace = MaxCapacity - currentCapacity;

            // Vérification si l'espace disponible est suffisant pour ajouter l'objet

            if (item is Resource resource)
            {
                if (resource.TotalWeight <= availableSpace)
                {
                    // Ajouter l'objet si l'espace est suffisant
                    Items.Add(item);
                    currentCapacity += resource.TotalWeight;  // Mettre à jour la capacité actuelle
                }
            }
            else if (item is Sword sword)
            {
                if (sword.SwordWeight <= availableSpace)
                {
                    Items.Add(item);
                    currentCapacity += sword.SwordWeight;
                }
            }
            else if (item is Shield shield)
            {
                if (shield.ShieldWeight <= availableSpace)
                {
                    Items.Add(item);
                    currentCapacity += shield.ShieldWeight;
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
                Items.RemoveAt(itemNumber);
        }


        public void DisplayInventory()
        {
            RefreshInventory();
            // Déplace le curseur à la position spécifiée par le Vector2
            Console.SetCursorPosition((int)Actualposition.X, (int)Actualposition.Y);

            // Affiche l'inventaire
            Console.Write($"Inventaire : ");
            Console.Write($"Poids {currentCapacity}/{MaxCapacity} kg");

            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("---------------------------------------------------------");

            // Affichage des items avec une taille d'affichage pour chaque colonne
            uint count = 0;
            foreach (IItem item in Items)
            {
                Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);

                if (item is Resource resource)
                    Console.WriteLine($"| n°{count} {resource.Material.Name,-15} | x{resource.Quantity,-4} | {resource.TotalWeight} kg");
                else if (item is Sword sword)
                    Console.WriteLine($"| n°{count} {sword.SwordName,-15} | x{sword.Quantity,-4} | {sword.SwordWeight} kg");
                else if (item is Shield shield)
                    Console.WriteLine($"| n°{count} {shield.ShieldName,-15} | x{shield.Quantity,-4} | {shield.ShieldWeight} kg");

                ++count;
            }
            Console.SetCursorPosition((int)Actualposition.X, (int)++Actualposition.Y);
            Console.WriteLine("---------------------------------------------------------");
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
