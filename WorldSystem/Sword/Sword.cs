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
    internal sealed class Sword : ISword
    {
        public Rarity Rarity { get; private set; }
        public Category Category { get; private set; } = Category.Sword;
        public int Quantity { get; private set; }
        public int SwordDamage { get; private set; }
        public Resource Resource { get; private set; }
        public SwordName SwordName { get; private set; }
        public int SwordPrice { get; private set; }
        public int SwordWeight { get; private set; } = 7;

        public Sword(int Quantity, Rarity Rarity, Resource Resource)
        {
            SwordName = GetRandomSwordName();
            this.Quantity = Quantity;
            this.Resource = Resource;
            this.Rarity = Rarity;
            SwordWeight += Resource.Material.Weight;
            switch (SwordName)
            {
                case SwordName.The_Sword_of_a_Thousand_Truths:
                    SwordPrice = 10000;
                    SwordDamage = 1;
                    break;
                case SwordName.Ashbringer:
                    SwordPrice = 1000;
                    SwordDamage = 2;
                    break;
                case SwordName.Excalibur:
                    SwordPrice = 8000;
                    SwordDamage = 3;
                    break;
                case SwordName.The_Zulqifar:
                    SwordPrice = 7000;
                    SwordDamage = 5;
                    break;
                case SwordName.Warglaives_of_Azzinoth:
                    SwordPrice = 5000;
                    SwordDamage = 6;
                    break;
                default:
                    break;
            }
        }

        public Sword(int Quantity, Rarity Rarity, Resource Resource, SwordName SwordName)
        {
            this.SwordName = SwordName;
            this.Quantity = Quantity;
            this.Resource = Resource;
            this.Rarity = Rarity;
            SwordWeight += Resource.Material.Weight;
            switch (SwordName)
            {
                case SwordName.The_Sword_of_a_Thousand_Truths:
                    SwordPrice = 10000;
                    SwordDamage = 1;
                    break;
                case SwordName.Ashbringer:
                    SwordPrice = 1000;
                    SwordDamage = 2;
                    break;
                case SwordName.Excalibur:
                    SwordPrice = 8000;
                    SwordDamage = 3;
                    break;
                case SwordName.The_Zulqifar:
                    SwordPrice = 7000;
                    SwordDamage = 5;
                    break;
                case SwordName.Warglaives_of_Azzinoth:
                    SwordPrice = 5000;
                    SwordDamage = 6;
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
                $@"SwordMaterial: {Resource.Material.Name}",
                $@"SwordWeight: {SwordWeight}",
                $@"SwordName: {SwordName}",
                $@"SwordPrice: {SwordPrice}",
                $@"SwordDamage: {SwordDamage}" +"\n"
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
        public SwordName GetRandomSwordName()
        {
            Random random = new Random();
            Array swordNames = Enum.GetValues(typeof(SwordName));
            return (SwordName)swordNames.GetValue(random.Next(swordNames.Length));
        }
        public string ToCsvLine()
        {
            return $"{Category},{Rarity},{SwordName},{Resource.Material.Name},{Quantity}";
        }
    }
}
