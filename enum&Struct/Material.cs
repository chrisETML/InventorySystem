/*
Entreprise : ETML
Auteur : Meron Essayas 
Date : 14.0122025
Description : struct pour materials avec name, price and weight
*/
namespace WorldSystem
{
    internal struct Material
    {
        public string Name;
        public int Weight;
        public int Price;

        public Material(string name, int weight, int price)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }
    }
}

