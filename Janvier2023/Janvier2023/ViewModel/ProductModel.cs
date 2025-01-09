using Janvier2023.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Janvier2023.ViewModel
{
    public class ProductModel
    {
        private readonly Product _product;

        public ProductModel(Product product)
        {
            _product = product;
        }

        public Product Product
        {
            get => _product;
        }

        public int ProductID
        {
            get => _product.ProductId;
        }

        public string ProductName
        {
            get => _product.ProductName;
        }

        public string Category
        {
            get => _product.Category?.CategoryName ?? "N/A";
        }

        public string ContactName
        {
            get => _product.Supplier?.ContactName ?? "N/A";
        }

    }
}