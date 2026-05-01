using System;
using System.Security.Cryptography.X509Certificates;

namespace Ramos_Jared_ShoppingCartActivity
{

    public class Product
    {   // Product Fields
        public int id;
        public string name;
        public double price;
        public int remainingStock;

        // Product Methods
        public void DisplayProducts() // Logic to display all the items in a menu
        {


            Console.WriteLine($"[ID: {id} ] Name: {name}, Price: {price}, Stock: {remainingStock}");
            Console.WriteLine("------------------------");

        }

        public void DeductStock(int amountToSubtract)
        {
            remainingStock = (remainingStock - amountToSubtract);
        }



    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region - Item Logic | Arrays of shopMenu - This region holds the arrays for all of the items and their respective data.
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
            #region - The Menu | Greetings, While loops, If statements, and Math
            Console.WriteLine("Greetings! Welcome to the JJTR Shop! What would you like to buy today?");
            Console.WriteLine("Please add what you want to buy in your shopping cart! ");
            Console.WriteLine("Here are the current items for today!");
            Console.WriteLine("");

            for (int i = 0; i < 5; i++) // For loop that loops through the DisplayProducts method to show all the products!
            {
                shopMenu[i].DisplayProducts();
            }

            double cartTotal = 0; // The cash register!


            while (true)
            {


                Console.WriteLine("Please type the ID of the item that you want to buy: ");
                string userInput = Console.ReadLine();
                // if the user types in anything else but a number, the loop will replay.


                if (int.TryParse(userInput, out int productID))
                { // userInput becomes productID

                    if (productID > 0 && productID <= 5)
                    {
                        Console.WriteLine($"Excellent choice picking {shopMenu[productID - 1].name}" + "!");
                        Console.WriteLine($"Now, Please pick how much of {shopMenu[productID - 1].name} you would like to buy: ");
                        Console.WriteLine($"The current stock for {shopMenu[productID - 1].name} is: {shopMenu[productID - 1].remainingStock}");
                        string userStock = Console.ReadLine();
                        if (int.TryParse(userStock, out int buyAmount))
                        {
                            if (buyAmount > 0 && buyAmount <= shopMenu[productID - 1].remainingStock) // Checks if the user inputted a valid stock number
                            {
                                shopMenu[productID - 1].DeductStock(buyAmount);
                                cartTotal = (cartTotal + shopMenu[productID - 1].price * buyAmount);
                                Console.WriteLine($"Successfully put in the cart! Current stock of {shopMenu[productID - 1].name} is: {shopMenu[productID - 1].remainingStock}");

                                if (shopMenu[productID - 1].remainingStock == 0)
                                {
                                    Console.WriteLine($"It seems we're now out of stock for {shopMenu[productID - 1].name}. Thank you for shopping with us! ^^");
                                }

                                else if (buyAmount <= 0)
                                {
                                     // Logic checker in case the user types a string or a negative number.
                                     Console.WriteLine("Invalid input, Please Try again.");
                                }


                            }

                                else
                                {
                                    // Logic checker in case the user types a number that is higher than the stock
                                     Console.WriteLine("We're sorry, but we dont have enough for you!");
                                }

                        }
                        else if (productID >= 6 || productID < 0) // Logic Checker for Invalid user input
                        {
                            Console.WriteLine("We apologise, but that product isnt available right now :( Please reconsider.");
                        }
                    }

                    else // Logic Checker for invalid User Input
                    {
                        Console.WriteLine("Hey! That isnt a valid input, please try again! ");
                    }

                    Console.WriteLine("Would you like to finish up your shopping? (Y/N)");
                    string userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "y")
                    {
                        break;
                    }

                    else if (userDecision != "n")
                    {
                        Console.WriteLine("Hey! Keep your answer within the choices.");
                        Console.WriteLine("Would you like to finish up your shopping? (Y/N)");
                        
                       
                    }


            
                }

            }
            #endregion
            #region - Farewell | Discounts, Totals, and Goodbyes
            double totalEnd = 0;
            double discountedTotal = 0; // Set the discounted total payment as 0 for now so it can update later
            if (cartTotal >= 5000)
            {
                discountedTotal = (cartTotal * 0.10); // 10% Discount if the user reaches 5000+ in total
                totalEnd = (cartTotal - discountedTotal);
                Console.WriteLine("------RECEIPT------");
                Console.WriteLine($"Your grand total payment (discount included) is: {totalEnd}");
            }

            else if (cartTotal < 5000)
            {
                Console.WriteLine("------RECEIPT------");
                Console.WriteLine($"Your grand total payment is: {cartTotal}");
                
            }
            Console.WriteLine("");
            Console.WriteLine("------UPDATED MENU------");
            for (int i = 0; i < 5; i++) // For loop that loops through the DisplayProducts method to show all the products AFTER the user's purchase.
            {
                shopMenu[i].DisplayProducts();
            }
            Console.WriteLine("");
            Console.WriteLine("Thank you for shopping with us, Please come back soon!");
           
            Console.ReadLine();
            #endregion
        }

    }
}
