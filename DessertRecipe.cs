public class DessertRecipe : Recipe
{
    public DessertRecipe(int id, string name, string instructions)
        : base(id, name, instructions) { }

    public override string GetRecipeType() => "Dessert";
}
