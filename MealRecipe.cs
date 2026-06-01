public class MealRecipe : Recipe
{
    public MealRecipe(int id, string name, string instructions)
        : base(id, name, instructions) { }

    public override string GetRecipeType() => "Meal";
}
