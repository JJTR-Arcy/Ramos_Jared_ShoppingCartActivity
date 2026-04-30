using System;

namespace Ramos_Jared_ShoppingCartActivity
{
    internal class Program
    {

        // Hello :3 This is Jared Ramos from BSIT 1-2 (irreg) here. I've decided to completely nuke my old code and rework it with the receieved comments and criticisms in mind, hopefully I've done a good job :)
        // Side note: Very very sorry that I submitted my repository's link inside of 1-1's google sheet! Complete accident T_T 
        static void Main(string[] args)
        {
            bool menuActivated = true;


            while menuActivated = true;
            {
                Console.WriteLine("Welcome to the JJTR Shop!");
                Console.WriteLine("What would you like to do today? Please Select a number.");
                Console.WriteLine("1 - View Items on stock");
                Console.WriteLine("2 - Put an Item in your Cart");
                Console.WriteLine("3 - Checkout")
                Console.WriteLine("4 - Exit")
                Console.WriteLine("The stage is yours, dear customer! What do you pick?: ");
                string userChoice = Console.ReadLine();
                menuActivated = false;

                switch (userChoice)

                    case "1";
                    Console.WriteLine("Welcome! Just window shopping? That's fine!")
                        // Shows the menu only
                    break;

                    case "2";
                    Console.WriteLine("Welcome! What would you like to select from the menu?")
                        // Shows the menu
                        // Shows id selection user input, product name user input, yada yada
                        // this is where all of the user input goes!

                    case "3";
                    Console.WriteLine("Will that be all that you want? (Y/N): ");
                    string checkoutDecision = Console.ReadLine().Lower;

                    if (checkoutDecision == "y")
                        // Continue to checkout

                    else if (checkoutDecision == "n")
                        // Loop back into the menu

            }

        }
    }

    // --- Classes Logic! --- 

    public class Product
    {
        public int id;
        public string name;
        public double price;
        public string category;
        public int remainingStock;

        public DisplayProduct()
            Console.WriteLine(Product[]);
    }

    public class CartItem
    {
        public string name;
        public double price;
        public int quantityBought;
        public double subtotal;
    }
}