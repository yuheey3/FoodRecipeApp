using System;
using SQLite;
namespace FoodRecipeApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}


