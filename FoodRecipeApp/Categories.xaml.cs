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
    public partial class Categories : ContentPage
    {
        public ObservableCollection<Category> category;
        public Manager manager2 = new Manager();
        Category selectedCategory;
     


        public Categories()
        {
            InitializeComponent();
         
        }

        protected async override void OnAppearing()
        {
            detailList2.ItemsSource = null;
            var list = await manager2.GetCategory();
            category = new ObservableCollection<Category>(list);
            detailList2.ItemsSource = category;
            base.OnAppearing();

        }

        private async void detailList2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedCategory = detailList2.SelectedItem as Category;

            var name = selectedCategory.strCategory;
            await Navigation.PushAsync(new CategoryDetail(name));


        }


    }
}
