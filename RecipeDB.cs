/************************************************************
 * Name: Francis Hampton
 * Date: 6/7/2026
 * Purpose: CRUD operations for Recipes table.
 ************************************************************/

using System.Data.SQLite;

public class RecipeDB
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
        "CREATE TABLE IF NOT EXISTS Recipes (" +
        "RecipeId INTEGER PRIMARY KEY AUTOINCREMENT," +
        "Name TEXT," +
        "Instructions TEXT," +
        "Type TEXT);";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddRecipe(SQLiteConnection conn, RecipeRecord r)
    {
        string sql = string.Format(
            "INSERT INTO Recipes (Name, Instructions, Type) VALUES ('{0}', '{1}', '{2}')",
            r.Name, r.Instructions, r.Type);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void UpdateRecipe(SQLiteConnection conn, RecipeRecord r)
    {
        string sql = string.Format(
            "UPDATE Recipes SET Name='{0}', Instructions='{1}', Type='{2}' WHERE RecipeId={3}",
            r.Name, r.Instructions, r.Type, r.RecipeId);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void DeleteRecipe(SQLiteConnection conn, int id)
    {
        string sql = $"DELETE FROM Recipes WHERE RecipeId={id}";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<RecipeRecord> GetAllRecipes(SQLiteConnection conn)
    {
        List<RecipeRecord> list = new List<RecipeRecord>();
        string sql = "SELECT * FROM Recipes";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            list.Add(new RecipeRecord(
                rdr.GetInt32(0),
                rdr.GetString(1),
                rdr.GetString(2),
                rdr.GetString(3)
            ));
        }

        return list;
    }
}
