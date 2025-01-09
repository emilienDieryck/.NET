using Janvier2023.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Janvier2023.ViewModel;

namespace Janvier2023.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private NorthwindContext _context;
        private ProductModel _selectedProduct;

        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<CountryProductCount> CountryProductCounts { get; set; }

        public DelegateCommand AbandonProductCommand { get; set; }

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            _context = new NorthwindContext();
            Products = new ObservableCollection<ProductModel>(_context.Products
                .Where(p => !p.Discontinued)
                .Select(p => new ProductModel(p)));
            CountryProductCounts = new ObservableCollection<CountryProductCount>(GetCountryProductCounts());

            AbandonProductCommand = new DelegateCommand(AbandonProduct);
        }

        private void AbandonProduct()
        {
            if (SelectedProduct != null)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == SelectedProduct.ProductID);
                if (product != null)
                {
                    product.Discontinued = true;
                    _context.SaveChanges();
                    Products.Remove(SelectedProduct);
                }
            }
        }

        private ObservableCollection<CountryProductCount> GetCountryProductCounts()
        {
            var result = _context.OrderDetails
                .Where(od => od.Quantity > 0)
                .GroupBy(od => od.Order.ShipCountry)
                .Select(g => new CountryProductCount
                {
                    Country = g.Key,
                    Count = g.Select(od => od.ProductId).Distinct().Count()
                })
                .OrderByDescending(c => c.Count)
                .ToList();

            return new ObservableCollection<CountryProductCount>(result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class CountryProductCount
    {
        public string Country { get; set; }
        public int Count { get; set; }
    }
}