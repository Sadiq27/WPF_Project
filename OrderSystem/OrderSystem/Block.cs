using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class BlockItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string? imagePath;
        private string? title;
        //private string? description;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        //public string Description
        //{
        //    get { return description; }
        //    set
        //    {
        //        description = value;
        //        OnPropertyChanged(nameof(Description));
        //    }
        //}
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModel
    {
        public ObservableCollection<BlockItem> BlockCollection { get; set; }

        public ViewModel()
        {
            BlockCollection = new ObservableCollection<BlockItem>()
            {
                new BlockItem()
                {
                    ImagePath = "Assets/images/burger.jpg",
                    Title = "Burgers",
                    //Description = "Delicious burgers for real gourmets"
                },
                new BlockItem()
                {
                    ImagePath = "Assets/images/pizza.png",
                    Title = "Pizzas",
                    //Description = "Appetizing pizza with various toppings"
                },
                new BlockItem()
                {
                    ImagePath = "Assets/images/sushi.jpg",
                    Title = "Sushi",
                    //Description = "Delicate sushi, the perfect combination of freshness and taste"
                },
                new BlockItem()
                {
                    ImagePath = "Assets/images/dr.png",
                    Title = "Drinks",
                    //Description = "Refreshing drinks, a real pleasure in every sip"
                },
            };
        }
    }
}
