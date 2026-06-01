/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Abstract base class for all food-related items.
 * Demonstrates abstraction, inheritance, and polymorphism.
 *******************************************************/
public abstract class FoodItem : IPrintable
{
    public string Name { get; protected set; }
    public string Category { get; protected set; }

    protected FoodItem(string name, string category)
    {
        Name = name;
        Category = category;
    }

    // Abstract method for getting details from derived classes
    public abstract string GetDetails();

    // Polymorphic output format
    public virtual string GetPrintableText()
    {
        return $"{Name} ({Category})";
    }
}
