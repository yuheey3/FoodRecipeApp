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
    public partial class CategoryDetail : ContentPage
    {
        public ObservableCollection<Category2> food;
        public Manager manager = new Manager();
        Category2 selectedFood;
        private string categoryName = "";



        public CategoryDetail(string text)
        {
            InitializeComponent();
            categoryName = text;
        }

        protected async override void OnAppearing()
        {
            detailList3.ItemsSource = null;

            var list = await manager.SearchByCategory(categoryName);
            food = new ObservableCollection<Category2>(list);
            detailList3.ItemsSource = food;

            base.OnAppearing();

        }

        private async void detailList3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedFood = detailList3.SelectedItem as Category2;

            var name = selectedFood.strMeal;
            await Navigation.PushAsync(new SearchName(name));

        }


    }
}
