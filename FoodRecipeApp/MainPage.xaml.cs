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
        //private string imgUrl = "";
       // public ObservableCollection<RandomFood> randomFood;
   

        public MainPage()
        {
            InitializeComponent();
        
            //BindingContext = this;

        }

        //protected async override void OnAppearing()
        //{

        //    //var list = await manager.GetRandomFood();
        //    //randomFood = new ObservableCollection<RandomFood>(list);
        //    //imgUrl = (randomFood[0].strMealThumb).ToString();
        //    //Console.WriteLine(imgUrl);
        //    //BindingContext = this;
        //    base.OnAppearing();

        //}

        async private void Search_By_Name(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new FirstLetter());
        }
        async private void Search_By_FirstLetter(object sender, EventArgs e)
        {
        //    Entry entry = e as Entry;
           var firstLetter = fLetter.Text;
            await Navigation.PushAsync(new FirstLetter(firstLetter));
        }
        async private void Search_By_Category(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Categories());
        }


        //public string ImageUrl
        //{
        //    get { return imgUrl; }
        //    set
        //    {
        //        imgUrl = value;
        //        OnPropertyChanged(nameof(ImageUrl)); // Notify that there was a change on this property
        //    }
        //}
    }
}
