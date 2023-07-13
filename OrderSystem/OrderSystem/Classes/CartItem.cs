using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrderSystem.Classes
{
    public class CartItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? title;
        private int quantity;
        private decimal price;
        public decimal Total => Quantity * Price;
        public decimal TotalPrice => Quantity * Price;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
