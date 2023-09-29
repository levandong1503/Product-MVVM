using PropertyChanged;
using System;
using System.Xml.Linq;

namespace user_product_wpf.Models;

[AddINotifyPropertyChangedInterface]
public partial class Product
{
    private string name;
    private string description;
    private int price;
    private string unit;
    public int Id { get; set; }
    public string Name 
    { 
        get 
        { 
            return name; 
        } 
        set 
        { 
            name = value;
            OnPropertyChanged(nameof(name)); 
        } 
    }
    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
            OnPropertyChanged(nameof(description));
        }
    }
    public int Price 
    { 
        get 
        { 
            return price; 
        }
set 
        {
            price = value;
            OnPropertyChanged(nameof(price)); 
        } 
    }
    public string Unit 
    { 
        get 
        { 
            return unit; 
        } 
        set
        {
            unit = value;
            OnPropertyChanged(nameof(Unit)); 
        } 
    }

    public Product Clone()
    {
        return new Product
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Price = Price,
            Unit = Unit,
        };
    }
}
