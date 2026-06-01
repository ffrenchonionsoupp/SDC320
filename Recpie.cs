/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Abstract recipe class containing ingredients.
 * Demonstrates abstraction, composition, and polymorphism.
 *******************************************************/
public abstract class Recipe : IPrintable
{
    public int RecipeId { get; protected set; }
    public string Name { get; protected set; }
    public string Instructions { get; protected set; }
    public List<Ingredient> Ingredients { get; private set; } = new List<Ingredient>();

    protected Recipe(int recipeId, string name, string instructions)
    {
        RecipeId = recipeId;
        Name = name;
        Instructions = instructions;
    }

    public void AddIngredient(Ingredient i) => Ingredients.Add(i);

    public void RemoveIngredient(int ingredientId)
    {
        Ingredients.RemoveAll(i => i.RecipeId == ingredientId);
    }

    // Abstraction, forces derived classes to define type
    public abstract string GetRecipeType();

    public virtual string GetPrintableText()
    {
        string ingredientList = string.Join("\n", Ingredients.Select(i => "- " + i.GetDetails()));

        return $"{Name} ({GetRecipeType()})\n\nIngredients:\n{ingredientList}\n\nInstructions:\n{Instructions}";
    }
}
