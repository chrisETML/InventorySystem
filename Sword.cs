/*
Entreprise : ETML
Auteur : Meron Essayas
Date : 24.01.2025
Description : 
*/

using System;

namespace WorldSystem
{
    internal class Sword
    {

        /*//public SwordName SwordName { get; private set; }
        public InventorySystem.Category Category { get; } = InventorySystem.Category.Sword; 
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        public int Damage { get; private set; }
        public Resource Resource { get; private set; }
        public InventorySystem.Rarity Rarity { get; private set; }
        public Material Material { get; private set; }


        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="Name">nom de l'objet</param>
        /// <param name="Category">categorie de l'objet</param>
        /// <param name="Price">prix de l'objet</param>
        /// <param name="Quantity">quantite de l'objet</param>
        public Sword(int Quantity, int Damage, Resource Resource, InventorySystem.Rarity Rarity)
        {
            SwordName = GetRandomSwordName();
            this.Quantity = Quantity;
            this.Damage = Damage;
            this.Resource = Resource;
            this.Rarity = Rarity;
            switch (SwordName)
            {
                case SwordName.The_Sword_of_a_Thousand_Truths:
                    Price = 10000;
                    break;
                case SwordName.Ashbringer:
                    Price = 1000;
                    break;
                case SwordName.Excalibur:
                    Price = 8000;
                    break;
                case SwordName.The_Zulqifar:
                    Price = 7000;
                    break;
                case SwordName.Warglaives_of_Azzinoth:
                    Price = 5000;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Display the sword
        /// </summary>
        public void DisplaySword()
        {
            Console.WriteLine($"The {Category} is called {SwordName} and it can deal {Damage} damage. It is {Rarity} rarity. It is made of {Resource.Material} and it costs {Price} coins.\n");
        }

        public SwordName GetRandomSwordName()
        {
            Random random = new Random();
            Array swordNames = Enum.GetValues(typeof(SwordName));
            return (SwordName)swordNames.GetValue(random.Next(swordNames.Length));
        }

        public string ToCsvLine()
        {
            throw new NotImplementedException();
        }*/
    }
}
