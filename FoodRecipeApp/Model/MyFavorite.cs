using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace FoodRecipeApp.Model
{
    public class MyFavorite : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string _dataMeal { get; set; }
        public string _dataCategory { get; set; }
        public string _dataArea { get; set; }
        public string _dataMealThumb { get; set; }
        public string _dataTags { get; set; }




        public string dataMeal
        {
            get { return _dataMeal; }
            set
            {
                if (value == _dataMeal)
                    return;
                _dataMeal = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(dataMeal)));
                }
            }
        }
        public string dataCategory
        {
            get { return _dataCategory; }
            set
            {
                if (value == _dataCategory)
                    return;
                _dataCategory = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(dataCategory)));
                }
            }
        }
        public string dataArea
        {
            get { return _dataArea; }
            set
            {
                if (value == _dataArea)
                    return;
                _dataArea = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(dataArea)));
                }
            }
        }
    
        public string dataMealThumb
        {
            get { return _dataMealThumb; }
            set
            {
                if (value == _dataMealThumb)
                    return;
                _dataMealThumb = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(dataMealThumb)));
                }
            }
        }
        public string dataTags
        {
            get { return _dataTags; }
            set
            {
                if (value == _dataTags)
                    return;
                _dataTags = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(dataTags)));
                }
            }
        }
   
        public bool isFavorite{ get; set; }
   

        public string statusFavorite
        {
            get
            {
                if (isFavorite)
                    return "Added to My Favorite";
                else
                    return "Add to My Favorite";
            }
            set { }
        }

     

    }
}
