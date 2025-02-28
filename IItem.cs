/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Interface pour tous les objets
*/
namespace WorldSystem
{
    internal interface IItem
    {
        Rarity Rarity { get; }
        Category Category { get; }
        int Quantity { get; }
        string ToCsvLine();
    }
}
