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
    internal sealed class Shield : IShield
    {
        public Rarity Rarity { get; private set; }
        public Category Category { get; private set; } = Category.Shield;
        public int Quantity { get; private set; }
        public int ShieldProtection { get; private set; }
        public Resource Resource { get; private set; }
        public ShieldName ShieldName { get; private set; }
        public int ShieldPrice { get; private set; }
        public int ShieldWeight { get; private set; } = 10;

        public Shield(int Quantity, Resource Resource, Rarity Rarity)
        {
            ShieldName = GetRandomShieldName();
            this.Quantity = Quantity;
            this.Resource = Resource;
            this.Rarity = Rarity;
            ShieldWeight += Resource.Material.Weight;
            switch (ShieldName)
            {
                case ShieldName.Banner_of_the_Fallen:
                    ShieldPrice = 10000;
                    ShieldProtection = 1;
                    break;
                case ShieldName.Bulwark_of_Azzinoth:
                    ShieldPrice = 1000;
                    ShieldProtection = 2;
                    break;
                case ShieldName.Shield_of_the_Righteous:
                    ShieldPrice = 8000;
                    ShieldProtection = 3;
                    break;
                case ShieldName.Aegis_of_the_Scarlet_Crusade:
                    ShieldPrice = 7000;
                    ShieldProtection = 5;
                    break;
                case ShieldName.The_Shield_of_the_Eternal_Champion:
                    ShieldPrice = 5000;
                    ShieldProtection = 6;
                    break;
                default:
                    break;
            }
        }

        public Shield(int Quantity, Resource Resource, Rarity Rarity, ShieldName ShieldName)
        {
            this.ShieldName = ShieldName;
            this.Quantity = Quantity;
            this.Resource = Resource;
            this.Rarity = Rarity;
            ShieldWeight += Resource.Material.Weight;
            switch (ShieldName)
            {
                case ShieldName.Banner_of_the_Fallen:
                    ShieldPrice = 10000;
                    ShieldProtection = 1;
                    break;
                case ShieldName.Bulwark_of_Azzinoth:
                    ShieldPrice = 1000;
                    ShieldProtection = 2;
                    break;
                case ShieldName.Shield_of_the_Righteous:
                    ShieldPrice = 8000;
                    ShieldProtection = 3;
                    break;
                case ShieldName.Aegis_of_the_Scarlet_Crusade:
                    ShieldPrice = 7000;
                    ShieldProtection = 5;
                    break;
                case ShieldName.The_Shield_of_the_Eternal_Champion:
                    ShieldPrice = 5000;
                    ShieldProtection = 6;
                    break;
                default:
                    break;
            }
        }

        public void Display(Vector2 Position, Vector2 InputPosition, int worldItems)
        {
            string[] str = {
                $"Category: {Category}",
                $@"Rarity: {Rarity}",
                $@"Quantity: {Quantity}",
                $@"ShieldMaterial: {Resource.Material.Name}",
                $@"ShieldWeight {ShieldWeight}",
                $@"ShieldName: {ShieldName}",
                $@"ShieldPrice: {ShieldPrice}",
                $@"ShieldProtection: {ShieldProtection}"+"\n"
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

        public ShieldName GetRandomShieldName()
        {
            Random random = new Random();
            Array shieldNames = Enum.GetValues(typeof(ShieldName));
            return (ShieldName)shieldNames.GetValue(random.Next(shieldNames.Length));
        }
        public string ToCsvLine()
        {
            return $"{Category},{Rarity},{ShieldName},{Resource.Material.Name},{Quantity}";
        }
    }
}
