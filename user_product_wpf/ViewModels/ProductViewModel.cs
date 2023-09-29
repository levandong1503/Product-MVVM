using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using user_product_wpf.Models;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;
using System;
using System.Linq;
using user_product_wpf.Views;
using System.Windows;

namespace user_product_wpf.ViewModels
{
    public partial class ProductViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> products;
        public ObservableCollection<Product> Products { get 
            { 
                return products;
            } set 
            {
                products = value;
                OnPropertyChanged(nameof(products));
            } 
        }
        private Product product;
        public Product SelectedProduct { get; set; }
        public Product ProductInfo
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                //OnPropertyChanged(nameof(product));
                OnPropertyChanged(nameof(product));
            }
        }
        /*
         get
            {
                return ProductInfo;
            }
            set
            {
                
                if (value.Id == 0 || string.IsNullOrEmpty(value.Name) || value.Price <= 0 || ProductInfo == value)
                {
                    
                }
                else
                {
                    ProductInfo = value;
                    OnPropertyChanged(nameof(ProductInfo));
                }
            }
         */
        public ProductViewModel()
        {
            ProductInfo = new Product();
            Products = new ObservableCollection<Product>()
            {
                new Product
                {
                    Id = 1,
                    Description = "Test 1",
                    Name = "Test 1",
                    Price = 1232,
                    Unit = "Pack",
                },
                new Product
                {
                    Id = 2,
                    Description = "Test 2",
                    Name = "Test 2",
                    Price = 1349287,
                    Unit = "Pack",
                }
            };
        }

        public ICommand AddProduct
        {
            get
            {
                return new RelayCommand(() =>
            {
                var newProduct = new Product
                {
                    Id = Products.Count + 1,
                    Name = ProductInfo.Name,
                    Price = ProductInfo.Price,
                    Unit = ProductInfo.Unit,
                    Description = ProductInfo.Description,
                };
                Products.Add(newProduct);

                //ProductInfo.Id = 0;
                //ProductInfo.Price = 0;
                //ProductInfo.Name = string.Empty;
                //ProductInfo.Description = string.Empty;
                //ProductInfo.Unit = string.Empty;
                ProductInfo = new Product();
            });
            //,
            //() =>
            //{
            //    if (string.IsNullOrEmpty(ProductInfo.Name) || ProductInfo.Price <= 0)
            //    {
            //        return false;
            //    }
            //    return true;
            //}
            //);
            }
        }

        public ICommand UpdateProduct
        {
            get
            {
                return new RelayCommand<object>((obj) =>
                {
                    if (obj is Product i)
                    {
                        //var selected = Products.Where(item => item.Id == SelectedProduct.Id).First();
                        var updateProductViewModel = new UpdateProduct(Products, i);
                        var popup = new PopupUpdateProduct(updateProductViewModel);
                        popup.Show();
                    }
                });
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public event NotifyCollectionChangedEventHandler? CollectionChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
