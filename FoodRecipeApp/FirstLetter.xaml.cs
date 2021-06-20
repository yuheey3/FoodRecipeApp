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
    public partial class FirstLetter : ContentPage
    {
        public ObservableCollection<Food> food;
        public Manager manager = new Manager();
        Food selectedFood;
        private string fLetter = "";


        public FirstLetter(String text)
        {
            InitializeComponent();
            fLetter = text;
        }

        protected async override void OnAppearing()
        {
            detailList.ItemsSource = null;
            var list = await manager.GetFood(fLetter);
            food = new ObservableCollection<Food>(list);
            detailList.ItemsSource = food;
            base.OnAppearing();

        }

        private async void detailList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedFood = detailList.SelectedItem as Food;

           
        }

    
    }
}
