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

        ObservableCollection<MyFavorite> MyFavoriteData;


        MyFavorite newFavorite;
        

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

            if (isFavoriteAdded(StrMeal))
                isFavoriteStr.Text = "You already have this receipe";
            else
                isFavoriteStr.Text = "Add to my Favorite Food";

            BindingContext = this;
            base.OnAppearing();


        }


        public bool isFavoriteAdded(string name)
        {
            bool check = false;
            int size = MyFavoriteData.Count;
            Console.WriteLine(size);
            for (int i = 0; i < size; i++)
            {
                if (check)
                {
                    break;
                }
                var n = MyFavoriteData[i].dataMeal;

                if (n == name)
                {
                    check = true;
                }

            }
            return check;
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
            Console.WriteLine(newFavorite.dataMeal);

            if (isFavoriteAdded(StrMeal))
            {
                await DisplayAlert("Alert", "You already have this receipe!", "Ok");
            }
            else
            {
                MyFavoriteData.Add(newFavorite);
                await DisplayAlert("Success", "Added to My Favorite!", "Ok");
                isFavoriteStr.Text = "You already have this receipe";
                dbModel.insertNewFavorite(newFavorite);
            }





        }
    }
}
