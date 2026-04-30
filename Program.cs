using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace Sanbox_for_Shopping_Cart_Activity_Parts_1_and_2
{
    internal class Program
    {
        // Hello :3 This is Jared Ramos from BSIT 1-2 (irreg) here. I've decided to completely nuke my old code and rework it with the receieved comments and criticisms in mind, hopefully I've done a good job :)
        // Side note: Very very sorry that I submitted my repository's link inside of 1-1's google sheet! Complete accident T_T 
        // By the time that I had realized, the google sheet was already locked! Completely my fault, it wont happen again <3
        static void Main(string[] args)
        {
            Product[] storeInventory = new Product[5];

            storeInventory[0] = new Product();
            storeInventory[0].id = 1;
            storeInventory[0].name = "Instant Noodles";
            storeInventory[0].price = 15.50;
            storeInventory[0].remainingStock = 100;

            storeInventory[1] = new Product();
            storeInventory[1].id = 2;
            storeInventory[1].name = "Safeguard White Soap";
            storeInventory[1].price = 50;
            storeInventory[1].remainingStock = 120;

            storeInventory[2] = new Product();
            storeInventory[2].id = 3;
            storeInventory[2].name = "Canned Corned Beef";
            storeInventory[2].price = 60;
            storeInventory[2].remainingStock = 70;

            storeInventory[3] = new Product();
            storeInventory[3].id = 4;
            storeInventory[3].name = "Cotton Balls";
            storeInventory[3].price = 80;
            storeInventory[3].remainingStock = 90;

            storeInventory[4] = new Product();
            storeInventory[4].id = 5;
            storeInventory[4].name = "Face Cleanser";
            storeInventory[4].price = 120;
            storeInventory[4].remainingStock = 60;

          bool menuActivated = true;
            while (menuActivated == true)
            {

                Console.WriteLine("Welcome to the JJTR Shop!");
                Console.WriteLine("What would you like to do today? Please Select a number.");
                Console.WriteLine("1 - View Items on stock");
                Console.WriteLine("2 - Put an Item in your Cart");
                Console.WriteLine("3 - Checkout");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("The stage is yours, dear customer! What do you pick?: ");
                string userChoice = Console.ReadLine();
                

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Welcome! Just window shopping? That's fine!");
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            storeInventory[i].DisplayProduct();
                        }
                        Console.WriteLine("\nWhich item number would you like to buy? (Enter the ID): ");
                        string idInput = Console.ReadLine();

                        
                        if (int.TryParse(idInput, out int selectedId))
                        {
                            Console.WriteLine($"You selected ID: {selectedId}. Let's check if we have it!");
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a real number.");
                        }
                       
                        break;

                    case "2":
                        Console.WriteLine("Welcome! What would you like to select from the menu?");
                        // Shows the menu
                        // Shows id selection user input, product name user input, yada yada
                        // this is where all of the user input goes!
                        break;

                    case "3":
                        Console.WriteLine("Will that be all that you want? (Y/N): ");
                        string checkoutDecision = Console.ReadLine().ToLower();

                        if (checkoutDecision == "y")
                        {

                        }
                        // Continue to checkout

                        else if (checkoutDecision == "n")
                        {
                            // Loop back into the menu
                           
                        }
                        break;
                }
            }


         
        }
    }

    // --- Classes Logic! --- 

    public class Product
    {
        public int id;
        public string name;
        public double price;
        public int remainingStock;

        

        public void DisplayProduct()
        {
        
        
                Console.WriteLine($"[{id}] {name} - Php {price} (Stock: {remainingStock})");
         
           
        }
    }
              
        
    

    public class CartItem
    {
        public string name;
        public double price;
        public int quantityBought;
        public double subtotal;
    }
}