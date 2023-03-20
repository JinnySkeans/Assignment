using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for CheckoutReturn.xaml
    /// </summary>
    public partial class CheckoutReturn : Window
    {
        public CheckoutReturn()
        {
            InitializeComponent();
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a book title.");
                return;
            }
            DateTime dueDate = DateTime.Now.AddDays(14);
            MessageBoxResult mbr =MessageBox.Show("Your book will be due back on: " + dueDate.ToShortDateString() + "\nIs this okay?", "Confirmation", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                MessageBox.Show("Booking Cancelled"); 
                return;
            }

            XmlController xmlc = new XmlController();
            xmlc.checkoutBook(txtTitle.Text, dueDate, " TODO libray cardnumbrt here" );

        }
    }
}
