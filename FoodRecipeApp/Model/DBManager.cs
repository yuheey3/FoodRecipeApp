using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FoodRecipeApp.Persistence;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodRecipeApp.Model
{

    public class DBManager
    {
        private SQLiteAsyncConnection _connection;

        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        public async Task<ObservableCollection<MyFavorite>> CreateTable()
        {
            await _connection.CreateTableAsync<MyFavorite>();
            var myFavorites = await _connection.Table<MyFavorite>().ToListAsync();
            var _myFavorites = new ObservableCollection<MyFavorite>(myFavorites);
            return _myFavorites;
        }

        public void insertNewFavorite(MyFavorite myFavorites)
        {
            _connection.InsertAsync(myFavorites);
        }

        public void deleteFavorite(MyFavorite myFavorites)
        {
            _connection.DeleteAsync(myFavorites);
        }

        public void updateFavorite(MyFavorite myFavorites)
        {
            _connection.UpdateAsync(myFavorites);

        }

    }
}

