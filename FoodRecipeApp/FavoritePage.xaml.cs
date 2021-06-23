using FoodRecipeApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FoodRecipeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<MyFavorite> allFavorite;
        public Manager manager = new Manager();
        MyFavorite selectedFood;




        public FavoritePage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            detailList4.ItemsSource = null;

            allFavorite = await dbModel.CreateTable();
            detailList4.ItemsSource = allFavorite;

            base.OnAppearing();

        }

        private async void detailList4_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            selectedFood = detailList4.SelectedItem as MyFavorite;

            var name = selectedFood.dataMeal;
            await Navigation.PushAsync(new SearchName(name));
        }

        public void deleteFromDB(object sender, EventArgs e)
        {


            var item = sender as MenuItem;

            var myOrder = (item.CommandParameter as MyFavorite);

            allFavorite.Remove(myOrder);
            dbModel.deleteFavorite(myOrder);

            DisplayAlert("Sucess", " Sucessfully Deleted!", "OK");

        }
    }
}

