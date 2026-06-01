/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Represents a grocery item stored in the pantry.
 *******************************************************/
public class GroceryItem : FoodItem
{
    public int Quantity { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public GroceryItem(string name, string category, int quantity, DateTime expiration)
        : base(name, category)
    {
        Quantity = quantity;
        ExpirationDate = expiration;
    }

    public override string GetDetails()
    {
        return $"{Name} x{Quantity}, expires {ExpirationDate.ToShortDateString()}";
    }

    public override string GetPrintableText()
    {
        return $"{Name} ({Category})\nQuantity: {Quantity}\nExpires: {ExpirationDate:d}";
    }
}
