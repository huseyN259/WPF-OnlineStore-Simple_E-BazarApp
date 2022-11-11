using E_Bazar.Models;
using E_Bazar.Views;
using System.Windows;
using System.Windows.Controls;

namespace E_Bazar.UserControls;

public partial class UC_Product : UserControl
{
    public Product? BazarProduct { get; set; }

    public UC_Product(Product? product)
    {
        InitializeComponent();
        
        DataContext = this;

		BazarProduct = product;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DetailsView detailsView = new(BazarProduct);
		detailsView.ShowDialog();
    }
}