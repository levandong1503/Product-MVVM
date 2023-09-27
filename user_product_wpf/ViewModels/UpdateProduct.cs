using Microsoft.Toolkit.Mvvm.Input;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using user_product_wpf.Models;

namespace user_product_wpf.ViewModels;

[AddINotifyPropertyChangedInterface]
public partial class UpdateProduct
{
    public ObservableCollection<Product> Products { get; init; }
    public UpdateProduct(ObservableCollection<Product> products, Product product)
    {
        Products = products;
        ProductInfo = product;
        ProductUpdateValue = product.Clone();
    }

    public Product ProductInfo { get; init; }
    public Product ProductUpdateValue { set; get; }

    public ICommand UpdateCommand { 
        get
        {
            return new RelayCommand(() =>
            {
                //ProductInfo.Name = ProductUpdateValue.Name;
                //ProductInfo.Description = ProductUpdateValue.Description;
                //ProductInfo.Price = ProductUpdateValue.Price;
                //ProductInfo.Unit = ProductUpdateValue.Unit;
                //OnPropertyChanged(nameof(ProductInfo));
            });
        }
    }

    public ICommand DeleteCommand
    {
        get
        {
            return new RelayCommand(() =>
            {
                Products.Remove(Products.First(item => item.Id == ProductUpdateValue.Id));
            });
        }
    }
}
