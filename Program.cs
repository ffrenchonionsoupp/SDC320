/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Assignment: Pantry Fairy – Week 4 Database Integration
 * Purpose: Demonstrates SQLite CRUD and LINQ for Recipes,
 *          Ingredients, and GroceryItems.
 ************************************************************/

using System.Data.SQLite;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Week 4 Project – The Pantry Fairy");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This demo shows SQLite CRUD operations for recipes,");
        Console.WriteLine("ingredients, and grocery items.\n");

        const string dbName = "PantryFairy.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            // Create tables
            RecipeDB.CreateTable(conn);
            IngredientDB.CreateTable(conn);
            GroceryItemDB.CreateTable(conn);

            // Crud Create: Recipes
            RecipeRecord r1 = new RecipeRecord("Spaghetti Bolognese",
                "Boil pasta. Cook meat. Mix sauce. Combine.", "Meal");
            RecipeRecord r2 = new RecipeRecord("Iced Tea",
                "Brew tea. Add sugar. Add ice.", "Drink");

            RecipeDB.AddRecipe(conn, r1);
            RecipeDB.AddRecipe(conn, r2);

            // Get IDs back with Crud Read
            List<RecipeRecord> allRecipes = RecipeDB.GetAllRecipes(conn);
            RecipeRecord spaghetti = allRecipes.First(r => r.Name == "Spaghetti Bolognese");
            RecipeRecord icedTea = allRecipes.First(r => r.Name == "Iced Tea");

            // Crud Create: Ingredients
            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Spaghetti", 1, "lb", "Grain", spaghetti.RecipeId));
            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Ground Beef", 1, "lb", "Meat", spaghetti.RecipeId));
            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Tomato Sauce", 2, "cups", "Vegetable", spaghetti.RecipeId));

            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Tea Bags", 4, "bags", "Drink", icedTea.RecipeId));
            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Sugar", 1, "cup", "Drink", icedTea.RecipeId));
            IngredientDB.AddIngredient(conn,
                new IngredientRecord("Ice Cubes", 10, "cubes", "Frozen", icedTea.RecipeId));

            // Crud Create: Grocery Items
            GroceryItemDB.AddItem(conn,
                new GroceryItemRecord("Milk", "Dairy", 1, DateTime.Now.AddDays(2).ToString("yyyy-MM-dd")));
            GroceryItemDB.AddItem(conn,
                new GroceryItemRecord("Eggs", "Dairy", 12, DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")));
            GroceryItemDB.AddItem(conn,
                new GroceryItemRecord("Bread", "Grain", 1, DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")));

            // Crud Read: Recipes + Ingredients
            Console.WriteLine("~ All Recipes ~");
            allRecipes = RecipeDB.GetAllRecipes(conn);
            PrintRecipes(conn, allRecipes);

            // LINQ: Filter recipes by type
            Console.WriteLine("~ Meal Recipes Only (LINQ) ~");
            var mealRecipes = allRecipes.Where(r => r.Type == "Meal").ToList();
            PrintRecipes(conn, mealRecipes);

            // Crud Read: Grocery Items
            Console.WriteLine("~ All Grocery Items ~");
            var allItems = GroceryItemDB.GetAllItems(conn);
            PrintGroceryItems(allItems);

            // LINQ: Items expiring within 3 days
            Console.WriteLine("~ Grocery Items Expiring Soon (<= 3 days) ~");
            var expiringSoon = allItems.Where(i =>
            {
                DateTime exp = DateTime.Parse(i.ExpirationDate);
                return exp <= DateTime.Now.AddDays(3);
            }).ToList();
            PrintGroceryItems(expiringSoon);

            // Crud Update: Recipe
            Console.WriteLine("~ Updating Iced Tea Recipe ~");
            icedTea.Instructions = "Brew tea. Chill. Add ice sugar, and lemon.";
            RecipeDB.UpdateRecipe(conn, icedTea);

            Console.WriteLine("~ Updated Iced Tea ~");
            allRecipes = RecipeDB.GetAllRecipes(conn);
            PrintRecipes(conn, allRecipes.Where(r => r.Name == "Iced Tea").ToList());

            // Crud Delete: Grocery Item
            Console.WriteLine("~ Deleting Bread from GroceryItems ~");
            var bread = allItems.FirstOrDefault(i => i.Name == "Bread");
            if (bread != null)
            {
                // delete by ItemId
                string sql = $"DELETE FROM GroceryItems WHERE ItemId={bread.ItemId}";
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("~ Grocery Items After Delete ~");
            allItems = GroceryItemDB.GetAllItems(conn);
            PrintGroceryItems(allItems);

            Console.WriteLine("\nEnd of Week 4 demonstration.");
        }
    }

    // Print recipes with their ingredients
    private static void PrintRecipes(SQLiteConnection conn, List<RecipeRecord> recipes)
    {
        foreach (var r in recipes)
        {
            Console.WriteLine($"Recipe {r.RecipeId}: {r.Name} ({r.Type})");
            Console.WriteLine($"Instructions: {r.Instructions}");

            var ingredients = IngredientDB.GetIngredientsByRecipe(conn, r.RecipeId);
            Console.WriteLine("Ingredients:");
            foreach (var ing in ingredients)
            {
                Console.WriteLine($" - {ing.Quantity} {ing.Unit} {ing.Name} ({ing.Category})");
            }
            Console.WriteLine();
        }
    }

    // Print grocery items
    private static void PrintGroceryItems(List<GroceryItemRecord> items)
    {
        foreach (var i in items)
        {
            Console.WriteLine($"Item {i.ItemId}: {i.Name} ({i.Category})");
            Console.WriteLine($"Quantity: {i.Quantity}");
            Console.WriteLine($"Expires: {i.ExpirationDate}\n");
        }
    }
}
