using MobileApp.Xamari.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp.Xamari.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}