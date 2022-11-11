using E_Bazar.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace E_Bazar.Views;

public partial class AddView : Window
{
    public List<Product> Products { get; set; }

    public AddView(List<Product> products)
    {
        InitializeComponent();
        
        Products = products;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        double price;
        bool result = Double.TryParse(pricetxtbox.Text, out price);
        
        if(result == false)
        {
            MessageBox.Show("Program Error...", "", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        Product product = new Product(nametxtbox.Text, desctxtbox.Text, price);
        Products.Add(product);
        this.DialogResult = true;
        this.Close();
    }
}