/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Interface pour tous les objets
*/

namespace InventorySystem
{
    internal interface IItem
    {
        
        string Name { get; }
        string Description { get; }
        int Prix { get; }
        int Quantity { get; }
    }
}
