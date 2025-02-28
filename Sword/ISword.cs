/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : 
*/
using System.Numerics;

namespace WorldSystem
{
    internal interface ISword : IItem
    {
        int SwordWeight { get; }
        int SwordDamage { get; }
        Resource Resource { get; }
        void Display(Vector2 Position, Vector2 InputPosition, int worldItems);

    }
}
