using System.Collections.Generic;
using System.Windows;
using E_Bazar.Models;
using E_Bazar.UserControls;

namespace E_Bazar.Views;

public partial class MainView : Window
{
    public List<Product>? Products { get; set; } = new();

    public MainView()
    {
        InitializeComponent();
        
        Products.Add(new Product("Egg", "Egg is a product", 0.30));
		Products.Add(new Product("Bread", "Bread is a product", 0.70));

		Refresh();
    }

	private void Refresh()
	{
		wrappanel1.Children.Clear();

		for (int i = 0; i < Products?.Count; i++)
		{
			UC_Product p1 = new(Products[i]);
			wrappanel1.Children.Add(p1);
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddView addView = new(Products);
        var result = addView.ShowDialog();
        
        if(result == true)
            Refresh();
    }

    private void Button_Click_Search(object sender, RoutedEventArgs e)
    {
        if (searchtxtbx1.Text == "")
        {
            MessageBox.Show("Search Box is empty...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        for (int i = 0; i < Products?.Count; i++)
        {
            if (Products[i].Name == searchtxtbx1.Text)
            {
                DetailsView dw = new(Products[i]);
                dw.ShowDialog();
                return;
            }
        }

        MessageBox.Show("Product is not found...", "", MessageBoxButton.OK);
    }
}