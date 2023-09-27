using System;

namespace user_product_wpf.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Unit { set; get; }

    public Product Clone()
    {
        return new Product { Id = Id, 
            Name = Name, 
            Description = Description, 
            Price = Price, 
        };
    }
}
