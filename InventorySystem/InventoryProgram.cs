/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Programme principale pour le système d'inventaire 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using WorldSystem;

namespace InventorySystem
{
    internal class InventoryProgram
    {
        // Déclaration de la fonction Windows qui peut être utilisée pour manipuler la fenêtre
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Constantes utilisées pour manipuler la fenêtre
        const int SW_MAXIMIZE = 3;
        static void Main()
        {
            IntPtr hWnd = GetConsoleWindow();

            // Maximiser la fenêtre
            ShowWindow(hWnd, SW_MAXIMIZE);

            Inventory inventory = new Inventory();

            inventory.AddItem(new Resource(2, new Material("gold", 3,10), Rarity.Rare));
            inventory.AddItem(new Resource(2, new Material("gold", 2, 10), Rarity.Common));
            inventory.AddItem(new Resource(3, new Material("gold", 3, 10), Rarity.Legendary));
            inventory.AddItem(new Resource(4, new Material("gold", 4, 10), Rarity.Uncommon));

            InventorySaveSystem.SaveToCsv(inventory.Items, $@"{Environment.CurrentDirectory}\save");
            List<IItem> i = InventorySaveSystem.LoadFromCsv($@"{Environment.CurrentDirectory}\save");
            

            foreach(IItem k in i)
            {
                inventory.AddItem(k);
            }

            inventory.DisplayInventory();

            
            Console.ReadKey();
        }
    }
}
