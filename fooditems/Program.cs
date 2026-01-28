using Mission__3_Assignment;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
     
        // create a list to store food items
        List<FoodItem> foodItems = new List<FoodItem>();

        RunMenu(foodItems);



    }
    public static void RunMenu(List<FoodItem> foodItems)
    {
        // a loop that runs while the program is running
        while (true)
        {
            Console.WriteLine("Please select an option: (1, 2, 3, 4) ");
            Console.WriteLine("1. Add a food item");
            Console.WriteLine("2. View food items");
            Console.WriteLine("3. Delete food items");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }


            // filter choice and call the appropriate method
            if (choice == "1")
            {
                AddFoodItem(foodItems);
            }
        
            if (choice == "2")
            {
                PrintFoodItems(foodItems);
            }

            if (choice == "3")
            {
                DeleteFoodItem(foodItems);
            }

            else if (choice == "4")
            {
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }


        }
    }
    public static void AddFoodItem(List<FoodItem> foodItems)
    {
        try
        {
            Console.WriteLine("Enter the food name:");
            string Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Error: Food name cannot be empty.");
                return;
            }

            Console.WriteLine("Enter the food category:");
            string Category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Category))
            {
                Console.WriteLine("Error: Category cannot be empty.");
                return;
            }

            Console.WriteLine("Enter the quantity:");
            if (!int.TryParse(Console.ReadLine(), out int Quantity))
            {
                Console.WriteLine("Error: Quantity must be a valid number.");
                return;
            }

            if (Quantity < 0)
            {
                Console.WriteLine("Error: Quantity cannot be a negative number.");
                return;
            }

            Console.WriteLine("Enter the expiration date (MM/DD/YYYY):");
            string Date = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Date))
            {
                Console.WriteLine("Error: Expiration date cannot be empty.");
                return;
            }

            FoodItem newFoodItem = new FoodItem(Name, Category, Quantity, Date);
            foodItems.Add(newFoodItem);
            Console.WriteLine("You have added a new food item!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }



    public static void PrintFoodItems(List<FoodItem> foodItems)
    {
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items to display.");
            return;
        }

        foreach (FoodItem item in foodItems)
        {
            Console.WriteLine(
                $"Name: {item.FoodName}, Category: {item.Category}, Quantity: {item.Quantity}, Expiration Date: {item.ExpirationDate}"
            );
        }
    }



    public static void DeleteFoodItem(List<FoodItem> foodItems)
    {
        if (foodItems.Count == 0)
        {
            Console.WriteLine("There are no food items to delete.");
            return;
        }

        Console.WriteLine("What is the name of the food item you want to remove?");
        string nametoRemove = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nametoRemove))
        {
            Console.WriteLine("Error: Name cannot be empty.");
            return;
        }

        for (int i = 0; i < foodItems.Count; i++)
        {
            if (foodItems[i].FoodName == nametoRemove)
            {
                foodItems.RemoveAt(i);
                Console.WriteLine("Food item removed.");
                return;
            }
        }

        Console.WriteLine("Food item not found.");
    }

}