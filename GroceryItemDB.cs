/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: CRUD operations for GroceryItems table.
 ************************************************************/

using System.Data.SQLite;

public class GroceryItemDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
        "CREATE TABLE IF NOT EXISTS GroceryItems (" +
        "ItemId INTEGER PRIMARY KEY AUTOINCREMENT," +
        "Name TEXT," +
        "Category TEXT," +
        "Quantity INTEGER," +
        "ExpirationDate TEXT);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddItem(SQLiteConnection conn, GroceryItemRecord g)
    {
        string sql = string.Format(
            "INSERT INTO GroceryItems (Name, Category, Quantity, ExpirationDate) " +
            "VALUES ('{0}', '{1}', {2}, '{3}')",
            g.Name, g.Category, g.Quantity, g.ExpirationDate);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<GroceryItemRecord> GetAllItems(SQLiteConnection conn)
    {
        List<GroceryItemRecord> list = new List<GroceryItemRecord>();
        string sql = "SELECT * FROM GroceryItems";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            list.Add(new GroceryItemRecord(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetInt32(3),
                rdr.GetString(4)
            ));
        }

        return list;
    }
}
