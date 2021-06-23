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

    public partial class MainPage : ContentPage
    {
        public Manager manager = new Manager();
        public ObservableCollection<Food> food;
        private string StrMealThumb = "";

        public MainPage()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {

            var list = await manager.RndomFood();

            food = new ObservableCollection<Food>(list);

        
            StrMealThumb = food[0].strMealThumb;
      

            BindingContext = this;
            base.OnAppearing();


        }

        public string strMealThumb
        {
            get { return StrMealThumb; }
            set
            {
                StrMealThumb = value;
                OnPropertyChanged(nameof(strMealThumb)); // Notify that there was a change on this property
            }
        }


        async private void Search_By_Name(object sender, EventArgs e)
        {
            var name = fName.Text;
            await Navigation.PushAsync(new SearchName(name));
            fName.Text = "";
        }
        async private void Search_By_FirstLetter(object sender, EventArgs e)
        {
            var firstLetter = fLetter.Text;
            await Navigation.PushAsync(new FirstLetter(firstLetter));
            fLetter.Text = "";
        }
        async private void Search_By_Category(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Categories());
        }

        async private void MyFavorite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritePage());
        }


    }
}
