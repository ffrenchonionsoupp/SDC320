/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: Represents a row in the GroceryItems table.
 ************************************************************/

public class GroceryItemRecord
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public string ExpirationDate { get; set; }

    public GroceryItemRecord(int id, string name, string category, int qty, string expiration)
    {
        ItemId = id;
        Name = name;
        Category = category;
        Quantity = qty;
        ExpirationDate = expiration;
    }

    public GroceryItemRecord(string name, string category, int qty, string expiration)
    {
        Name = name;
        Category = category;
        Quantity = qty;
        ExpirationDate = expiration;
    }
}
