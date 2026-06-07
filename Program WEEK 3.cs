/************************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Week 3 (First week of coding) demonstraction for The Pantry Fairy.
 * Demonstrates abstraction, inheritance, polymorphism, composition, constructors, and formatted output.
 ************************************************************/

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Week 3 Project – The Pantry Fairy");
        Console.WriteLine("Created by: Francis Hampton");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Welcome! This demo shows the core OOP features of the");
        Console.WriteLine("Pantry Fairy application using simple test data (No database integration yet).\n");

        //Abstraction & Composition through Recipe & Ingredient
        Recipe meal = new MealRecipe(
            id: 1,
            name: "Spaghetti Bolognese",
            instructions: "Boil pasta. Cook meat. Mix sauce. Combine."
        );

        meal.AddIngredient(new Ingredient("Spaghetti", "Grain", 1, "lb", 1));
        meal.AddIngredient(new Ingredient("Ground Beef", "Meat", 1, "lb", 1));
        meal.AddIngredient(new Ingredient("Tomato Sauce", "Vegetable", 2, "cups", 1));

        Console.WriteLine("~ Sample Recipe Output ~");
        Console.WriteLine(meal.GetPrintableText());
        Console.WriteLine();

        //Composition through GroceryItem & Pantry
        Pantry pantry = new Pantry();
        pantry.AddItem(new GroceryItem("Milk", "Dairy", 1, DateTime.Now.AddDays(2)));
        pantry.AddItem(new GroceryItem("Eggs", "Dairy", 12, DateTime.Now.AddDays(7)));
        pantry.AddItem(new GroceryItem("Bread", "Grain", 1, DateTime.Now.AddDays(1)));

        Console.WriteLine("~ Pantry Items ~");
        foreach (var item in pantry.Items)
        {
            Console.WriteLine(item.GetPrintableText());
            Console.WriteLine();
        }

        //Polymorphism through Recipe types
        List<Recipe> recipes = new List<Recipe>()
        {
            meal,
            new DrinkRecipe(2, "Iced Tea", "Brew tea. Add sugar. Add ice.", "Cold"),
            new SnackRecipe(3, "Trail Mix", "Mix nuts, chocolate chips, and raisins."),
            new DessertRecipe(4, "Brownies", "Prepare baking dish. Mix batter. Bake.")
        };

        Console.WriteLine("~ Polymorphism Demo: Recipe Types ~");
        foreach (var r in recipes)
        {
            Console.WriteLine($"{r.Name} → Type: {r.GetRecipeType()}");
        }

        Console.WriteLine("\nEnd of Week 3 demonstration.");
    }
}
