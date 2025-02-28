/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Interface pour les ressources
*/
namespace WorldSystem
{
    internal interface IResource : IItem
    {
        int TotalWeight { get; }
    }
}
