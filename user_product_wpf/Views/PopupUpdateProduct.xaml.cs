using System.Windows;
using user_product_wpf.ViewModels;

namespace user_product_wpf.Views;

/// <summary>
/// Interaction logic for PopupUpdateProduct.xaml
/// param @updateProduct 
/// </summary>
public partial class PopupUpdateProduct : Window
{
    public UpdateProduct updateProduct { set; get; }
    public PopupUpdateProduct(UpdateProduct updateProduct)
    {
        InitializeComponent();
        this.updateProduct = updateProduct;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DataContext = updateProduct;
    }
}
