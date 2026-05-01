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
            #region - Array of items in stock.
            Product[] storeInventory = new Product[5];
            CartItem[] shoppingCart = new CartItem[5];
            int cartItemCount = 0;
            string[] orderHistory = new string[10];
            int orderCount = 0;
            int receiptNumber = 1;

            storeInventory[0] = new Product();
            storeInventory[0].id = 1;
            storeInventory[0].name = "Instant Noodles";
            storeInventory[0].price = 15.50;
            storeInventory[0].remainingStock = 100;
            storeInventory[0].category = "Food";

            storeInventory[1] = new Product();
            storeInventory[1].id = 2;
            storeInventory[1].name = "Safeguard White Soap";
            storeInventory[1].price = 50;
            storeInventory[1].remainingStock = 120;
            storeInventory[1].category = "Cleaning Products";

            storeInventory[2] = new Product();
            storeInventory[2].id = 3;
            storeInventory[2].name = "Canned Corned Beef";
            storeInventory[2].price = 60;
            storeInventory[2].remainingStock = 70;
            storeInventory[2].category = "Food";

            storeInventory[3] = new Product();
            storeInventory[3].id = 4;
            storeInventory[3].name = "Cotton Balls";
            storeInventory[3].price = 80;
            storeInventory[3].remainingStock = 90;
            storeInventory[3].category = "Cleaning Product";

            storeInventory[4] = new Product();
            storeInventory[4].id = 5;
            storeInventory[4].name = "Face Cleanser";
            storeInventory[4].price = 120;
            storeInventory[4].remainingStock = 60;
            storeInventory[4].category = "Cleaning Product";

            #endregion

            bool menuActivated = true;
            while (menuActivated == true)
            {

                Console.WriteLine("Welcome to the JJTR Shop!");
                Console.WriteLine("What would you like to do today? Please Select a number.");
                Console.WriteLine("1 - Shop (View & Purchase Items)");
                Console.WriteLine("2 - Manage Cart & Checkout");
                Console.WriteLine("3 - View Order History");
                Console.WriteLine("4 - Exit Store");
                Console.WriteLine("The stage is yours, dear customer! What do you pick?: ");
                string userChoice = Console.ReadLine();

                #region - Switch Case logic for the entire menu system
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("\n========== SHOPPING MENU ==========");
                        Console.WriteLine("1 - View All Items");
                        Console.WriteLine("2 - Search by Name");
                        Console.WriteLine("3 - Filter by Category");
                        Console.Write("How would you like to browse?: ");
                        string shopOption = Console.ReadLine();

                        string searchQuery = "";
                        string categoryQuery = "";

                        if (shopOption == "2")
                        {
                            Console.Write("Enter product name to search: ");
                            searchQuery = Console.ReadLine().ToLower();
                        }
                        else if (shopOption == "3")
                        {
                            Console.WriteLine("Categories: Food, Cleaning Product");
                            Console.Write("Enter category: ");
                            categoryQuery = Console.ReadLine().ToLower();
                        }

                        Console.WriteLine("\n[STORE INVENTORY]");
                        bool itemFound = false;

                        // 1. The Search & Filter Loop
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            bool isMatch = false;

                            if (shopOption == "1") isMatch = true; // Show all
                            else if (shopOption == "2" && storeInventory[i].name.ToLower().Contains(searchQuery)) isMatch = true;
                            else if (shopOption == "3" && storeInventory[i].category.ToLower() == categoryQuery) isMatch = true;

                            if (isMatch)
                            {
                                storeInventory[i].DisplayProduct();
                                itemFound = true;
                            }
                        }

                        // 2. If nothing was found, exit back to main menu
                        if (itemFound == false)
                        {
                            Console.WriteLine("No items found matching your search. Returning to Main Menu...");
                            break;
                        }

                        // 3. Continue to purchase...
                        Console.WriteLine("\nWhich item number would you like to buy? (Enter the ID): ");
                        string idInput = Console.ReadLine();

                        // (YOUR TRYPARSE CODE STAYS EXACTLY THE SAME BELOW THIS LINE!)
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
                                            {

                                                shoppingCart[i].quantityBought += quantity;
                                                shoppingCart[i].subtotal += itemTotal;

                                                Console.WriteLine($"\nSuccess! Updated {newItem.name} in your cart.");
                                                Console.WriteLine($"New Quantity: {shoppingCart[i].quantityBought} | New Subtotal: Php {shoppingCart[i].subtotal}");

                                                itemFoundInCart = true;
                                                break;
                                            }
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


                    case "2": // --- PART 2: CART MANAGEMENT MENU :O ---
                        bool managingCart = true;
                        while (managingCart)
                        {
                            Console.WriteLine("\n========== CART MANAGEMENT ==========");
                            Console.WriteLine("1 - View Cart");
                            Console.WriteLine("2 - Remove an Item");
                            Console.WriteLine("3 - Update Item Quantity");
                            Console.WriteLine("4 - Clear Entire Cart");
                            Console.WriteLine("5 - Proceed to Checkout");
                            Console.WriteLine("6 - Go Back to Main Menu");
                            Console.Write("What would you like to do?: ");
                            string cartChoice = Console.ReadLine();

                            if (cartChoice == "1")
                            {
                                Console.WriteLine("\n[YOUR CART]");
                                if (cartItemCount == 0) Console.WriteLine("Your cart is completely empty!");
                                else
                                {
                                    for (int i = 0; i < cartItemCount; i++)
                                    {
                                        Console.WriteLine($"[{i + 1}] {shoppingCart[i].quantityBought}x {shoppingCart[i].name} - Php {shoppingCart[i].subtotal}");
                                    }
                                }
                            }
                            else if (cartChoice == "2") // REMOVE ITEM (luh)
                            {
                                if (cartItemCount == 0) Console.WriteLine("Cart is empty!");
                                else
                                {
                                    Console.Write("Enter the cart item number to remove: ");
                                    if (int.TryParse(Console.ReadLine(), out int removeIdx) && removeIdx > 0 && removeIdx <= cartItemCount)
                                    {
                                        int realIdx = removeIdx - 1;

                                        // 1. REFUND THE STOCK TO THE SHELF (why would u do that :[)
                                        for (int s = 0; s < storeInventory.Length; s++)
                                        {
                                            if (storeInventory[s].name == shoppingCart[realIdx].name)
                                            {
                                                storeInventory[s].remainingStock += shoppingCart[realIdx].quantityBought;
                                                break;
                                            }
                                        }

                                        // 2. SHIFT ARRAY TO DELETE ITEM (omg)
                                        for (int i = realIdx; i < cartItemCount - 1; i++)
                                        {
                                            shoppingCart[i] = shoppingCart[i + 1];
                                        }
                                        cartItemCount--;
                                        Console.WriteLine("Item removed and stock refunded to shelves.");
                                    }
                                    else Console.WriteLine("Invalid item number.");
                                }
                            }
                            else if (cartChoice == "3") // UPDATE QUANTITY :P
                            {
                                if (cartItemCount == 0) Console.WriteLine("Cart is empty!");
                                else
                                {
                                    Console.Write("Enter the cart item number to update: ");
                                    if (int.TryParse(Console.ReadLine(), out int updateIdx) && updateIdx > 0 && updateIdx <= cartItemCount)
                                    {
                                        int realIdx = updateIdx - 1;
                                        Console.Write($"Enter new quantity for {shoppingCart[realIdx].name}: ");
                                        if (int.TryParse(Console.ReadLine(), out int newQty) && newQty > 0)
                                        {
                                            int diff = newQty - shoppingCart[realIdx].quantityBought;
                                            bool canUpdate = true;

                                            // ADJUST STOCK ON SHELVES :D
                                            for (int s = 0; s < storeInventory.Length; s++)
                                            {
                                                if (storeInventory[s].name == shoppingCart[realIdx].name)
                                                {
                                                    if (diff > 0 && storeInventory[s].remainingStock < diff)
                                                    {
                                                        Console.WriteLine($"Not enough stock! Only {storeInventory[s].remainingStock} left on shelves.");
                                                        canUpdate = false;
                                                    }
                                                    else
                                                    {
                                                        storeInventory[s].remainingStock -= diff;
                                                    }
                                                    break;
                                                }
                                            }

                                            if (canUpdate)
                                            {
                                                shoppingCart[realIdx].quantityBought = newQty;
                                                shoppingCart[realIdx].subtotal = shoppingCart[realIdx].price * newQty;
                                                Console.WriteLine("Quantity successfully updated!");
                                            }
                                        }
                                        else Console.WriteLine("Invalid quantity.");
                                    }
                                    else Console.WriteLine("Invalid item number.");
                                }
                            }
                            else if (cartChoice == "4") // CLEAR CART >:0
                            {
                                // REFUND EVERYTHING IN THE CART :[
                                for (int c = 0; c < cartItemCount; c++)
                                {
                                    for (int s = 0; s < storeInventory.Length; s++)
                                    {
                                        if (storeInventory[s].name == shoppingCart[c].name)
                                        {
                                            storeInventory[s].remainingStock += shoppingCart[c].quantityBought;
                                        }
                                    }
                                }
                                cartItemCount = 0;
                                shoppingCart = new CartItem[5];
                                Console.WriteLine("\nCart cleared and ALL stock refunded to shelves!");
                            }
                            else if (cartChoice == "5")
                            {
                                // --- CHUNK 2: THE CHECKOUT SYSTEM >;] ---
                                Console.WriteLine("\n========== OFFICIAL RECEIPT ==========");

                                if (cartItemCount == 0)
                                {
                                    Console.WriteLine("Your cart is empty! Add items before checking out.");
                                    continue;
                                }

                                double grandTotal = 0;
                                for (int i = 0; i < cartItemCount; i++)
                                {
                                    Console.WriteLine($"{shoppingCart[i].quantityBought}x {shoppingCart[i].name} - Php {shoppingCart[i].subtotal}");
                                    grandTotal += shoppingCart[i].subtotal;
                                }

                                double finalTotal = grandTotal;
                                if (grandTotal >= 5000)
                                {
                                    double discount = grandTotal * 0.10;
                                    finalTotal = grandTotal - discount;
                                    Console.WriteLine($"\n*** 10% BIG SPENDER DISCOUNT APPLIED! (-Php {discount}) ***");
                                }

                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"FINAL TOTAL TO PAY: Php {finalTotal}");

                                // Payment Validation Loop X_X
                                double paymentAmount = 0;
                                while (true)
                                {
                                    Console.Write("Enter payment amount: Php ");
                                    string payInput = Console.ReadLine();

                                    if (double.TryParse(payInput, out paymentAmount))
                                    {
                                        if (paymentAmount >= finalTotal) break;
                                        else Console.WriteLine("Insufficient payment. Please enter a valid amount.");
                                    }
                                    else Console.WriteLine("Invalid input. Please enter numbers only.");
                                }

                                double change = paymentAmount - finalTotal;
                                string currentDate = DateTime.Now.ToString("MMMM dd, yyyy h:mm tt");

                                Console.WriteLine("\n========== TRANSACTION COMPLETE ==========");
                                Console.WriteLine($"Receipt No: {receiptNumber:D4}");
                                Console.WriteLine($"Date: {currentDate}");
                                Console.WriteLine($"Amount Paid: Php {paymentAmount}");
                                Console.WriteLine($"Change: Php {change}");

                                // Save to Order History :P
                                if (orderCount < orderHistory.Length)
                                {
                                    orderHistory[orderCount] = $"Receipt #{receiptNumber:D4} - Date: {currentDate} - Final Total: Php {finalTotal}";
                                    orderCount++;
                                }
                                receiptNumber++;

                                // Low Stock Alert >:O
                                Console.WriteLine("\n[LOW STOCK ALERTS]");
                                bool hasLowStock = false;
                                for (int i = 0; i < storeInventory.Length; i++)
                                {
                                    if (storeInventory[i].remainingStock <= 5)
                                    {
                                        Console.WriteLine($"ALERT: {storeInventory[i].name} has only {storeInventory[i].remainingStock} stocks left!");
                                        hasLowStock = true;
                                    }
                                }
                                if (!hasLowStock) Console.WriteLine("All items have sufficient stock.");

                                // Clear cart and exit cart menu! ;]
                                cartItemCount = 0;
                                shoppingCart = new CartItem[5];
                                managingCart = false;
                            }
                            else if (cartChoice == "6")
                            {
                                managingCart = false;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid option. Please try again.");
                            }
                        }
                        break;

                    case "3": // --- PART 2: ORDER HISTORY ^^ ---
                        Console.WriteLine("\n========== ORDER HISTORY ==========");
                        if (orderCount == 0)
                        {
                            Console.WriteLine("No completed transactions yet.");
                        }
                        else
                        {
                            for (int i = 0; i < orderCount; i++)
                            {
                                Console.WriteLine(orderHistory[i]);
                            }
                        }
                        break;

                    case "4": // --- EXIT :[ ---
                        Console.WriteLine("\nThank you for visiting the JJTR Shop! Shutting down...");
                        menuActivated = false;
                        break;
                }
                #endregion
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
            Console.WriteLine($"[{id}] {name} {category} - Php {price} (Stock: {remainingStock})");
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