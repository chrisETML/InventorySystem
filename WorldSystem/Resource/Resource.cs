/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : 
*/
using System;
using System.Numerics;
namespace WorldSystem
{
    internal sealed class Resource : IResource
    {
        public Rarity Rarity { get; private set; }
        public Category Category { get; private set; } = Category.Resource;
        public int Quantity { get; set; }
        public int TotalWeight { get; set; }
        public Material Material { get; private set; }

        public Resource(int Quantity, Material Material, Rarity Rarity)
        {
            this.Rarity = Rarity;
            this.Material = Material;
            this.Quantity = Quantity;
            this.TotalWeight = Material.Weight * Quantity;
        }
        public void Display(Vector2 Position, Vector2 InputPosition, int worldItems)
        {
            string[] str = {
                $"Category: {Category}",
                $@"Rarity: {Rarity}",
                $@"Quantity: {Quantity}",
                $@"MaterialName: {Material.Name}",
                $@"MaterialPrice {Material.Price}",
                $@"MaterialWeight {Material.Weight}"+"\n",
                $@"                                "+ "\n",
                $@"                                "+ "\n"
            };
            foreach (string item in str)
            {
                Console.SetCursorPosition((int)Position.X, (int)Position.Y);
                Console.Write("                                                                                           ");
                Console.SetCursorPosition((int)Position.X, (int)Position.Y++);
                Console.Write(item);
            }

            Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
            Console.Write("                                                                                           ");
            Console.SetCursorPosition((int)InputPosition.X, (int)InputPosition.Y);
            Console.Write("Entrer le numero de l'objet de 0 à " + (worldItems - 1) + "): ");
        }

        public string ToCsvLine()
        {
            return $"{Category},{Rarity},{Material.Name},{Material.Price},{Quantity}";
        }
    }
}
