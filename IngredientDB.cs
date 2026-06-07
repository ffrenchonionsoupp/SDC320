/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: CRUD operations for Ingredients table.
 ************************************************************/

using System.Data.SQLite;

public class IngredientDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
        "CREATE TABLE IF NOT EXISTS Ingredients (" +
        "IngredientId INTEGER PRIMARY KEY AUTOINCREMENT," +
        "Name TEXT," +
        "Quantity REAL," +
        "Unit TEXT," +
        "Category TEXT," +
        "RecipeId INTEGER);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddIngredient(SQLiteConnection conn, IngredientRecord i)
    {
        string sql = string.Format(
            "INSERT INTO Ingredients (Name, Quantity, Unit, Category, RecipeId) " +
            "VALUES ('{0}', {1}, '{2}', '{3}', {4})",
            i.Name, i.Quantity, i.Unit, i.Category, i.RecipeId);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<IngredientRecord> GetIngredientsByRecipe(SQLiteConnection conn, int recipeId)
    {
        List<IngredientRecord> list = new List<IngredientRecord>();
        string sql = $"SELECT * FROM Ingredients WHERE RecipeId={recipeId}";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            list.Add(new IngredientRecord(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetDouble(2),
                rdr.GetString(3),
                rdr.GetString(4),
                rdr.GetInt32(5)
            ));
        }

        return list;
    }
}
