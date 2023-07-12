using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Classes
{
    public class BlockItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? Clicked;
        private string? imagePath;
        private string? title;

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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
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
                    ImagePath = "../Assets/images/burger.jpg",
                    Title = "Burgers",
                },
                new BlockItem()
                {
                    ImagePath = "../Assets/images/pizza.png",
                    Title = "Pizzas",
                },
                new BlockItem()
                {
                    ImagePath = "../Assets/images/sushi.jpg",
                    Title = "Sushi",
                },
                new BlockItem()
                {
                    ImagePath = "../Assets/images/dr.png",
                    Title = "Drinks",
                },
            };
        }
    }
}
