public class SnackRecipe : Recipe
{
    public SnackRecipe(int id, string name, string instructions)
        : base(id, name, instructions) { }

    public override string GetRecipeType() => "Snack";
}
