public class DrinkRecipe : Recipe
{
    public string ServingTemperature { get; private set; }

    public DrinkRecipe(int id, string name, string instructions, string temp)
        : base(id, name, instructions)
    {
        ServingTemperature = temp;
    }

    public override string GetRecipeType() => "Drink";

    public override string GetPrintableText()
    {
        return base.GetPrintableText() + $"\nServing Temperature: {ServingTemperature}";
    }
}
