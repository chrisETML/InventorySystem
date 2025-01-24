/*
Entreprise : ETML
Auteur : Christopher Ristic 
Date : 17.01.2025
Description : Classe pour tester les objets 
*/

namespace InventorySystem
{
    internal class Obj : IRessouce
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Prix { get; private set; }
        public int Quantity { get; private set; }
        public Obj(string name, int quantity) 
        { 
            Name = name;
            Quantity = quantity;
        }

    }
}
