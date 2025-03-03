/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Programme principale pour le système d'inventaire 
*/

using System;
using System.Collections.Generic;
using static WorldSystem.Material_List;
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

            /*inventory.AddItem(new Resource(2, new Material("gold", 3, 10), Rarity.Rare));
            inventory.AddItem(new Sword(1, Rarity.Epic, new Resource(2, new Material(Materials[6].Name, Materials[6].Weight, 10), Rarity.Rare)));
            inventory.AddItem(new Shield(1, new Resource(2, new Material(Materials[3].Name, Materials[3].Weight, 10), Rarity.Legendary), Rarity.Legendary, ShieldName.The_Shield_of_the_Eternal_Champion));
            */
            //InventorySaveSystem.SaveToCsv(inventory.Items, $@"{Environment.CurrentDirectory}\saveInventory");
            List<IItem> i = InventorySaveSystem.LoadFromCsv($@"{Environment.CurrentDirectory}\saveInventory");

            foreach (IItem k in i)
            {
                inventory.AddItem(k);
            }

            inventory.DisplayInventory();
            Console.ReadKey();
        }
    }
}
