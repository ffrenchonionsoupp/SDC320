/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: Represents a row in the Recipes table.
 ************************************************************/

public class RecipeRecord
{
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; }
    public string Type { get; set; }

    public RecipeRecord(int id, string name, string instructions, string type)
    {
        RecipeId = id;
        Name = name;
        Instructions = instructions;
        Type = type;
    }

    public RecipeRecord(string name, string instructions, string type)
    {
        Name = name;
        Instructions = instructions;
        Type = type;
    }
}
