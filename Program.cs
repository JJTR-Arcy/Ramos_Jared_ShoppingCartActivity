using System;
using System.Security.Cryptography.X509Certificates;

namespace Ramos_Jared_ShoppingCartActivity
{

    public class Product
    {
        public int id;
        public string name;
        public double price;
        public int remainingStock;

        public void DisplayProducts()
        {

            Console.WriteLine(Product);

        }
            
                

               

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region - Item Logic | Arrays of shopMenu
            Product[] shopMenu = new Product[5];

            shopMenu[0] = new Product();
            shopMenu[0].id = 1;
            shopMenu[0].name = "Safeguard Soap";
            shopMenu[0].price = 65;
            shopMenu[0].remainingStock = 30;

            shopMenu[1] = new Product();
            shopMenu[1].id = 2;
            shopMenu[1].name = "Cheezy";
            shopMenu[1].price = 46;
            shopMenu[1].remainingStock = 40;

            shopMenu[2] = new Product();
            shopMenu[2].id = 3;
            shopMenu[2].name = "Deodorant";
            shopMenu[2].price = 100;
            shopMenu[2].remainingStock = 100;

            shopMenu[3] = new Product();
            shopMenu[3].id = 4;
            shopMenu[3].name = "Alcohol - 500mL";
            shopMenu[3].price = 75;
            shopMenu[3].remainingStock = 80;

            shopMenu[4] = new Product();
            shopMenu[4].id = 5;
            shopMenu[4].name = "Ballpen Box - 12 pieces";
            shopMenu[4].price = 110;
            shopMenu[4].remainingStock = 90;
            #endregion

            Console.WriteLine("Greetings! Welcome to the JJTR Shop! What would you like to buy today?" +
                "Please add what you want to buy in your shopping cart! ");

            switch (shopMenu)
            {

            }
        }
    }

}
