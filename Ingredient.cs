/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Represents an ingredient used in a recipe.
 *******************************************************/
public class Ingredient : FoodItem
{
    public double Quantity { get; private set; }
    public string Unit { get; private set; }
    public int RecipeId { get; private set; }

    public Ingredient(string name, string category, double quantity, string unit, int recipeId)
        : base(name, category)
    {
        Quantity = quantity;
        Unit = unit;
        RecipeId = recipeId;
    }

    public override string GetDetails()
    {
        return $"{Quantity} {Unit} of {Name}";
    }

    public override string GetPrintableText()
    {
        return $"{GetDetails()} (Category: {Category})";
    }
}
