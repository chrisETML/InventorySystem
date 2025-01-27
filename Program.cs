/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Programme principale pour le système d'inventaire 
*/

using System;
using System.IO;

namespace InventorySystem
{
    internal class Program
    {
        static void Main()
        {            
            var inventory = new Inventory();

            inventory.AddItem(new Obj("Potion", 10, Rarity.Common, 10,20));
            inventory.AddItem(new Obj("Meron", 10, Rarity.Rare, 10,20));
            inventory.AddItem(new Obj("Chris", 10, Rarity.Legendary, 10,20));


            InventorySaveSystem.SaveToCsv(inventory.items, $@"{Directory.GetCurrentDirectory()}\save");

            // Affichage de l'inventaire
            inventory.DisplayInventory();

            // Attente de l'utilisateur pour fermer la console
            Console.ReadKey();
        }
    }
}
