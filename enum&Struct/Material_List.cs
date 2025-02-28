/*
Entreprise : ETML
Auteur : Christopher Ristic
Date : 28.02.2025
Description : 
*/
using System.Collections.Generic;

namespace WorldSystem
{
    internal class Material_List
    {
        public static List<Material> Materials = new List<Material>()
        {
                new Material(name:"wood", weight:1, price:10),
                new Material(name:"stone", weight:2, price:20),
                new Material(name:"iron", weight:3, price:30),
                new Material(name:"steel", weight:4, price:40),
                new Material(name:"silver", weight:5, price:50),
                new Material(name:"gold", weight:6, price:60),
                new Material(name:"diamond", weight:7, price:70)
        };
    }
}
