namespace ShoppingCartActivity_Pt._3_Encapsulation
{
    internal class Program
    {
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
            storeInventory[0].Id = 1;
            storeInventory[0].Name = "Instant Noodles";
            storeInventory[0].Price = 15.50;
            storeInventory[0].remainingStock = 100;
            storeInventory[0].Category = "Food";

            storeInventory[1] = new Product();
            storeInventory[1].Id = 2;
            storeInventory[1].Name = "Safeguard White Soap";
            storeInventory[1].Price = 50;
            storeInventory[1].remainingStock = 120;
            storeInventory[1].Category = "Cleaning Products";

            storeInventory[2] = new Product();
            storeInventory[2].Id = 3;
            storeInventory[2].Name = "Canned Corned Beef";
            storeInventory[2].Price = 60;
            storeInventory[2].remainingStock = 70;
            storeInventory[2].Category = "Food";

            storeInventory[3] = new Product();
            storeInventory[3].Id = 4;
            storeInventory[3].Name = "Cotton Balls";
            storeInventory[3].Price = 80;
            storeInventory[3].remainingStock = 90;
            storeInventory[3].Category = "Cleaning Product";

            storeInventory[4] = new Product();
            storeInventory[4].Id = 5;
            storeInventory[4].Name = "Face Cleanser";
            storeInventory[4].Price = 120;
            storeInventory[4].remainingStock = 60;
            storeInventory[4].Category = "Cleaning Product";

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
                        string CategoryQuery = "";

                        if (shopOption == "2")
                        {
                            Console.Write("Enter product Name to search: ");
                            searchQuery = Console.ReadLine().ToLower();
                        }
                        else if (shopOption == "3")
                        {
                            Console.WriteLine("Categories: Food, Cleaning Product");
                            Console.Write("Enter Category: ");
                            CategoryQuery = Console.ReadLine().ToLower();
                        }

                        Console.WriteLine("\n[STORE INVENTORY]");
                        bool itemFound = false;

                        // 1. The Search & Filter Loop
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            bool isMatch = false;

                            if (shopOption == "1") isMatch = true; // Show all
                            else if (shopOption == "2" && storeInventory[i].Name.ToLower().Contains(searchQuery)) isMatch = true;
                            else if (shopOption == "3" && storeInventory[i].Category.ToLower() == CategoryQuery) isMatch = true;

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
                        string IdInput = Console.ReadLine();

                        
                        if (int.TryParse(IdInput, out int selectedId))
                        {

                            int arrayIndex = selectedId - 1;


                            if (arrayIndex >= 0 && arrayIndex < storeInventory.Length)
                            {

                                Console.WriteLine($"You selected ID: {selectedId}, {storeInventory[arrayIndex].Name}");
                                Console.WriteLine("Excellent choice! How many would you like to buy?");
                                string quantityInput = Console.ReadLine();

                                if (int.TryParse(quantityInput, out int quantity))
                                {
                                    if (quantity <= 0 || quantity > storeInventory[arrayIndex].remainingStock)
                                    {
                                        Console.WriteLine("ERROR: Quantity requested either too high or too low. Please reconsIder");
                                    }

                                    else
                                    {
                                        storeInventory[arrayIndex].DeductStock(quantity);
                                        Console.WriteLine($"Success! Added {quantity} of {storeInventory[arrayIndex].Name} to your cart.");


                                        double itemTotal = storeInventory[arrayIndex].Price * quantity;


                                        CartItem newItem = new CartItem();
                                        newItem.Name = storeInventory[arrayIndex].Name;
                                        newItem.Price = storeInventory[arrayIndex].Price;
                                        newItem.QuantityBought = quantity;
                                        newItem.Subtotal = itemTotal;

                                        bool itemFoundInCart = false;

                                        for (int i = 0; i < cartItemCount; i++)
                                        {
                                            if (shoppingCart[i].Name == newItem.Name)
                                            {

                                                shoppingCart[i].QuantityBought += quantity;
                                                shoppingCart[i].Subtotal += itemTotal;

                                                Console.WriteLine($"\nSuccess! Updated {newItem.Name} in your cart.");
                                                Console.WriteLine($"New Quantity: {shoppingCart[i].QuantityBought} | New Subtotal: Php {shoppingCart[i].Subtotal}");

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
                                                Console.WriteLine($"\nSuccess! Added {quantity}x {newItem.Name} to your cart. Subtotal: Php {newItem.Subtotal}");
                                            }

                                            else
                                            {
                                                Console.WriteLine("\nERROR: Your shopping cart is completely full!");
                                            }
                                        }

                                        Console.WriteLine($"\nSuccess! {quantity}x {newItem.Name} added. Subtotal: Php {newItem.Subtotal}");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("InvalId input! Please enter a real number for the quantity.");
                                }
                            }


                            else if (arrayIndex <= 0 || arrayIndex >= storeInventory.Length)
                            {
                                Console.WriteLine("InvalId ID! That item does not exist on our shelves.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("InvalId input! Please enter a real number.");
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
                                        Console.WriteLine($"[{i + 1}] {shoppingCart[i].QuantityBought}x {shoppingCart[i].Name} - Php {shoppingCart[i].Subtotal}");
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
                                            if (storeInventory[s].Name == shoppingCart[realIdx].Name)
                                            {
                                                storeInventory[s].remainingStock += shoppingCart[realIdx].QuantityBought;
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
                                    else Console.WriteLine("InvalId item number.");
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
                                        Console.Write($"Enter new quantity for {shoppingCart[realIdx].Name}: ");
                                        if (int.TryParse(Console.ReadLine(), out int newQty) && newQty > 0)
                                        {
                                            int diff = newQty - shoppingCart[realIdx].QuantityBought;
                                            bool canUpdate = true;

                                            // ADJUST STOCK ON SHELVES :D
                                            for (int s = 0; s < storeInventory.Length; s++)
                                            {
                                                if (storeInventory[s].Name == shoppingCart[realIdx].Name)
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
                                                shoppingCart[realIdx].QuantityBought = newQty;
                                                shoppingCart[realIdx].Subtotal = shoppingCart[realIdx].Price * newQty;
                                                Console.WriteLine("Quantity successfully updated!");
                                            }
                                        }
                                        else Console.WriteLine("InvalId quantity.");
                                    }
                                    else Console.WriteLine("InvalId item number.");
                                }
                            }
                            else if (cartChoice == "4") // CLEAR CART >:0
                            {
                                // REFUND EVERYTHING IN THE CART :[
                                for (int c = 0; c < cartItemCount; c++)
                                {
                                    for (int s = 0; s < storeInventory.Length; s++)
                                    {
                                        if (storeInventory[s].Name == shoppingCart[c].Name)
                                        {
                                            storeInventory[s].remainingStock += shoppingCart[c].QuantityBought;
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
                                    Console.WriteLine($"{shoppingCart[i].QuantityBought}x {shoppingCart[i].Name} - Php {shoppingCart[i].Subtotal}");
                                    grandTotal += shoppingCart[i].Subtotal;
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

                                // Payment ValIdation Loop X_X
                                double paymentAmount = 0;
                                while (true)
                                {
                                    Console.Write("Enter payment amount: Php ");
                                    string payInput = Console.ReadLine();

                                    if (double.TryParse(payInput, out paymentAmount))
                                    {
                                        if (paymentAmount >= finalTotal) break;
                                        else Console.WriteLine("Insufficient payment. Please enter a valId amount.");
                                    }
                                    else Console.WriteLine("InvalId input. Please enter numbers only.");
                                }

                                double change = paymentAmount - finalTotal;
                                string currentDate = DateTime.Now.ToString("MMMM dd, yyyy h:mm tt");

                                Console.WriteLine("\n========== TRANSACTION COMPLETE ==========");
                                Console.WriteLine($"Receipt No: {receiptNumber:D4}");
                                Console.WriteLine($"Date: {currentDate}");
                                Console.WriteLine($"Amount PaId: Php {paymentAmount}");
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
                                        Console.WriteLine($"ALERT: {storeInventory[i].Name} has only {storeInventory[i].remainingStock} stocks left!");
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
                                Console.WriteLine("\nInvalId option. Please try again.");
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
        public int Id { get; set; }
        public string Name { get; set;  }
        public double Price { get; set; }
        public string Category { get; set; }

        private int _remainingStock;
        public int remainingStock
        {
            get { return _remainingStock; }
            set
            {
                if (value >= 0)
                {
                    _remainingStock = value;
                }
            }
        }



        public void DisplayProduct()
        {
            Console.WriteLine($"[{Id}] {Name} {Category} - Php {Price} (Stock: {remainingStock})");
        }

        public void DeductStock(int amountToBuy)
        {
            remainingStock -= amountToBuy;
        }
    }




    public class CartItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityBought { get; set; }
        public double Subtotal { get; set; }
    }


}