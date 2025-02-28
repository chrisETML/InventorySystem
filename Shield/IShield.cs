/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : Interface pour tous les objets
*/
using System.Numerics;

namespace WorldSystem
{
    internal interface IShield : IItem
    {
        int ShieldWeight { get; }
        int ShieldProtection { get; }
        Resource Resource { get; }
        void Display(Vector2 Position, Vector2 InputPosition, int worldItems);
    }
}
