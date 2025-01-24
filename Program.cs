/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Programme principale pour le système d'inventaire 
*/

using System;

namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            var inventory = new Inventory();

            inventory.AddItem(new Obj("Potion", 10, Rarity.Common, ));
            inventory.AddItem(new Obj("Sword", 1));
            inventory.AddItem(new Obj("Shield", 2));

            // Affichage de l'inventaire
            inventory.DisplayInventory();

            // Attente de l'utilisateur pour fermer la console
            Console.ReadKey();
        }
    }
}
