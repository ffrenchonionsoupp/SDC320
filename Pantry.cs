/*******************************************************
 * Name: Francis Hampton
 * Date: 5/31/2026
 * Purpose: Abstract recipe class containing ingredients.
 * Demonstrates composition because Pantry contains GroceryItems
 *******************************************************/
public class Pantry
{
    public List<GroceryItem> Items { get; private set; } = new List<GroceryItem>();

    public void AddItem(GroceryItem item) => Items.Add(item);

    public void RemoveItem(int id)
    {
        Items.RemoveAll(i => i.Name.GetHashCode() == id);
    }

    public List<GroceryItem> GetExpiringSoon()
    {
        return Items.Where(i => i.ExpirationDate <= DateTime.Now.AddDays(3)).ToList();
    }

    public List<GroceryItem> GetByCategory(string category)
    {
        return Items.Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
