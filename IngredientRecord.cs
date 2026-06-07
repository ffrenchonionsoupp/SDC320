/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: Represents a row in the Ingredients table.
 ************************************************************/

public class IngredientRecord
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public string Category { get; set; }
    public int RecipeId { get; set; }

    public IngredientRecord(int id, string name, double qty, string unit, string category, int recipeId)
    {
        IngredientId = id;
        Name = name;
        Quantity = qty;
        Unit = unit;
        Category = category;
        RecipeId = recipeId;
    }

    public IngredientRecord(string name, double qty, string unit, string category, int recipeId)
    {
        Name = name;
        Quantity = qty;
        Unit = unit;
        Category = category;
        RecipeId = recipeId;
    }
}
