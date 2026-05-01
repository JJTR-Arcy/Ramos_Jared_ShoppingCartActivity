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
            CartItem[] shoppingCart = new CartItem[5];
            int cartItemCount = 0;

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
                Console.WriteLine("1 - View and Purchase items currently in stock");
                Console.WriteLine("2 - Checkout & Exit");
                Console.WriteLine("The stage is yours, dear customer! What do you pick?: ");
                string userChoice = Console.ReadLine();
                

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Welcome!");
                        Console.WriteLine("------------------!");
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            storeInventory[i].DisplayProduct();
                        }
                        Console.WriteLine("\nWhich item number would you like to buy? (Enter the ID): ");
                        string idInput = Console.ReadLine();


                        if (int.TryParse(idInput, out int selectedId))
                        {
                          
                            int arrayIndex = selectedId - 1;

                            
                            if (arrayIndex >= 0 && arrayIndex < storeInventory.Length)
                            {
                                
                                Console.WriteLine($"You selected ID: {selectedId}, {storeInventory[arrayIndex].name}");
                                Console.WriteLine("Excellent choice! How many would you like to buy?");
                                string quantityInput = Console.ReadLine();

                                if (int.TryParse(quantityInput, out int quantity))
                                {
                                    if (quantity <= 0 || quantity > storeInventory[arrayIndex].remainingStock)
                                    {
                                        Console.WriteLine("ERROR: Quantity requested either too high or too low. Please reconsider");
                                    }

                                    else
                                    {
                                        storeInventory[arrayIndex].DeductStock(quantity);
                                        Console.WriteLine($"Success! Added {quantity} of {storeInventory[arrayIndex].name} to your cart.");

                                   
                                        double itemTotal = storeInventory[arrayIndex].price * quantity;

                                    
                                        CartItem newItem = new CartItem();
                                        newItem.name = storeInventory[arrayIndex].name;
                                        newItem.price = storeInventory[arrayIndex].price;
                                        newItem.quantityBought = quantity;
                                        newItem.subtotal = itemTotal;

                                        bool itemFoundInCart = false;

                                        for (int i = 0; i < cartItemCount; i++)
                                        {
                                            if (shoppingCart[i].name == newItem.name)
                                            shoppingCart[i].quantityBought += quantity;
                                            shoppingCart[i].subtotal += itemTotal;

                                            Console.WriteLine($"\nSuccess! Updated {newItem.name} in your cart.");
                                            Console.WriteLine($"New Quantity: {shoppingCart[i].quantityBought} | New Subtotal: Php {shoppingCart[i].subtotal}");

                                            itemFoundInCart = true;
                                            break;
                                        }

                                        if (itemFoundInCart == false)
                                        {
                                            if (cartItemCount < shoppingCart.Length)
                                            {
                                                shoppingCart[cartItemCount] = newItem;
                                                cartItemCount++;
                                                Console.WriteLine($"\nSuccess! Added {quantity}x {newItem.name} to your cart. Subtotal: Php {newItem.subtotal}");
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nERROR: Your shopping cart is completely full!");
                                            }
                                        }

                                        Console.WriteLine($"\nSuccess! {quantity}x {newItem.name} added. Subtotal: Php {newItem.subtotal}");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("Invalid input! Please enter a real number for the quantity.");
                                }
                            }
                              
                            
                            else if (arrayIndex <= 0 ||  arrayIndex >= storeInventory.Length)
                            {
                                Console.WriteLine("Invalid ID! That item does not exist on our shelves.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a real number.");
                        }

                        break;


                    case "2":
                        Console.WriteLine("\n========== OFFICIAL RECEIPT ==========");

                        // 1. Check if they are trying to checkout with an empty cart
                        if (cartItemCount == 0)
                        {
                            Console.WriteLine("Your cart is completely empty! Going back to the menu...");
                            break;
                        }

                        double grandTotal = 0;

                        // 2. Loop through the cart and print the items
                        for (int i = 0; i < cartItemCount; i++)
                        {
                            Console.WriteLine($"{shoppingCart[i].quantityBought}x {shoppingCart[i].name} - Php {shoppingCart[i].subtotal}");
                            grandTotal += shoppingCart[i].subtotal; // Accumulate the total
                        }

                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine($"GRAND TOTAL: Php {grandTotal}");

                        // 3. The 10% Discount Check
                        if (grandTotal >= 5000)
                        {
                            double discount = grandTotal * 0.10; // Calculate 10%
                            double finalTotal = grandTotal - discount;

                            Console.WriteLine($"\n*** 10% BIG SPENDER DISCOUNT APPLIED! ***");
                            Console.WriteLine($"Discount Amount: -Php {discount}");
                            Console.WriteLine($"FINAL TOTAL: Php {finalTotal}");
                        }

                        Console.WriteLine("======================================");

                        // 4. Show updated remaining stock
                        Console.WriteLine("\n[STORE INVENTORY AFTER CHECKOUT]");
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            Console.WriteLine($"{storeInventory[i].name} - Remaining Stock: {storeInventory[i].remainingStock}");
                        }

                        // 5. End the program safely
                        Console.WriteLine("\nThank you for shopping at the JJTR Shop!");
                        menuActivated = false;
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
        public string category;

        

        public void DisplayProduct()
        {
            Console.WriteLine($"[{id}] {name} - Php {price} (Stock: {remainingStock})");
        }

        public void DeductStock(int amountToBuy)
        {
            remainingStock -= amountToBuy;
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