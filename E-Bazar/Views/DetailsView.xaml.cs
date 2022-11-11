using E_Bazar.Models;
using System.Windows;
using System.Windows.Controls;

namespace E_Bazar.Views;

public partial class DetailsView : Window
{
    public Product? BazarProduct { get; set; }

    public DetailsView(Product? product)
    {
        InitializeComponent();
        
        DataContext = this;
		
        BazarProduct = product;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(sender is Button btn)
        {
            if (btn.Content.ToString() == "Edit")
            {
                btn.Content = "Save";
                nametxtbox2.IsEnabled = true;
                desctxtbox2.IsEnabled = true;
                pricetxtbox2.IsEnabled = true;
            }
            else if (btn.Content.ToString() == "Save")
            {
                BazarProduct.Name = nametxtbox2.Text;
                BazarProduct.Description = desctxtbox2.Text;
				BazarProduct.Price = double.Parse(pricetxtbox2.Text);
                if (nametxtbox2.Text == "" || desctxtbox2.Text == "" || pricetxtbox2.Text == "")
                {
                    MessageBox.Show("Property is Empty...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
             
                btn.Content = "Edit";
                nametxtbox2.IsEnabled = false;
                desctxtbox2.IsEnabled = false;
                pricetxtbox2.IsEnabled = false;
            }
        }
    }
}