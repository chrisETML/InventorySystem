/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Classe pour tester les objets 
*/

namespace InventorySystem
{
    internal class Obj : IResource
    {
        public string Name { get; private set; }
        public Rarity Rarity { get; private set; }
        public int Weight { get; private set; }
        public Category Category { get; private set; }
        public int Price { get; private set; }
        public int Quantity { get; set; }
        public Obj(string name, int quantity, Rarity rarity, int prix, int weight) 
        { 
            Name = name;
            Quantity = quantity;
            Rarity = rarity;
            Category = Category.Ressource;
            Price = prix;
            Weight = weight;
            
        }
    }
}
