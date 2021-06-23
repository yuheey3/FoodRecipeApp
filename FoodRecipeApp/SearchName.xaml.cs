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
    public partial class SearchName : ContentPage
    {
        DBManager dbModel = new DBManager();
        // VaccinesData updatedVaccine;
        ObservableCollection<MyFavorite> MyFavoriteData;
      //  ObservableCollection<MyFavorite> allVaccines;
       
        MyFavorite newFavorite;
        bool isFavorite;

        public ObservableCollection<Food> food;
        public Manager manager = new Manager();
        private string fName = "";

        private string StrMeal = "";
        private string StrCategory = "";
        private string StrArea = "";
        private string StrInstructions = "";
        private string StrMealThumb = "";
        private string StrTags = "";
        private string StrYoutube = "";

        public SearchName(string text)
        {
            InitializeComponent();
            fName = text;
        }

        protected async override void OnAppearing()
        {
            
            var list = await manager.GetFoodByName(fName);
            food = new ObservableCollection<Food>(list);

            MyFavoriteData = await dbModel.CreateTable();
         

             StrMeal = food[0].strMeal;
            StrCategory = food[0].strCategory;
            StrArea = food[0].strArea;
            StrInstructions = food[0].strInstructions;
            StrMealThumb = food[0].strMealThumb;
            StrTags = food[0].strTags;
            StrYoutube = food[0].strYoutube;
            BindingContext = this;
            base.OnAppearing();

        }
     



        public string strMeal
        {
            get { return StrMeal; }
            set
            {
                StrMeal = value;
                OnPropertyChanged(nameof(strMeal)); // Notify that there was a change on this property
            }
        }


        public string strCategory
        {
            get { return StrCategory; }
            set
            {
                StrMeal = value;
                OnPropertyChanged(nameof(strCategory)); // Notify that there was a change on this property
            }
        }

        public string strArea
        {
            get { return StrArea; }
            set
            {
                StrArea = value;
                OnPropertyChanged(nameof(strArea)); // Notify that there was a change on this property
            }

        }



        public string strInstructions
        {
            get { return StrInstructions; }
            set
            {
                StrInstructions = value;
                OnPropertyChanged(nameof(strInstructions)); // Notify that there was a change on this property
            }
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
        public string strTags
        {
            get { return StrTags; }
            set
            {
                StrTags = value;
                OnPropertyChanged(nameof(strTags)); // Notify that there was a change on this property
            }
        }

        public string strYoutube
        {
            get { return StrYoutube; }
            set
            {
                StrYoutube = value;
                OnPropertyChanged(nameof(strYoutube)); // Notify that there was a change on this property
            }
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            newFavorite = new MyFavorite();
            newFavorite.dataMeal = StrMeal;
            newFavorite.dataCategory = StrCategory;
            newFavorite.dataArea = StrArea;
            newFavorite.dataMealThumb = StrMealThumb;
            newFavorite.dataTags = StrTags;
            newFavorite.isFavorite = true;
            Console.WriteLine(newFavorite.dataMeal); 
            MyFavoriteData.Add(newFavorite);
            await DisplayAlert("Success", "Added to My Favorite!", "Ok");
            dbModel.insertNewFavorite(newFavorite);
           // await Navigation.PopAsync();
        }
    }
}
