/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : 
*/
namespace WorldSystem
{
    internal interface ISword : IItem
    {
        int Damage { get; }

        Resource Resource { get; }

    }
}
