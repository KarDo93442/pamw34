using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using static System.Reflection.Metadata.BlobBuilder;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class ShoesViewModel : ObservableObject
    {
        private readonly IShoeService _shoeService;

        public ObservableCollection<Shoe> Shoes { get; set; }
        private List<Shoe> _shoesDB;
        private int currPage = 0;
        private readonly int ELEMENTS_PER_PAGE = 6;



        public ShoesViewModel(IShoeService productService)
        {
            _shoeService = productService;
            Shoes = new ObservableCollection<Shoe>();          
        }

        public async void GetShoes()
        {
            var shoesResult = await _shoeService.GetProductsAsync();
            if (shoesResult.Success)
            {
                _shoesDB = shoesResult.Data.ToList();
                DisplayShoesONPage();
            }
        }
        private void DisplayShoesONPage()
        {
            Shoes.Clear();
            for (int i = currPage; i < _shoesDB.LongCount() && i < currPage + ELEMENTS_PER_PAGE; i++)
            {
                Shoes.Add(_shoesDB[i]);
            }
        }
        [RelayCommand]
        public void Last()
        {
            if (currPage > 0)
                currPage--;
            DisplayShoesONPage();
        }

        [RelayCommand]
        public void Next()
        {
            currPage++;
            DisplayShoesONPage();
        }

    }
}
