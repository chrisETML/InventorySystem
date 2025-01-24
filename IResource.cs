﻿/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Interface pour les ressources
*/

namespace InventorySystem
{
    internal interface IResource : IItem
    {
        Rarity Rarity { get; }
        int Weight { get; }

        void Display();
    }
}