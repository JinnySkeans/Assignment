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
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : Window
    {
        public Member()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchBook searchBook = new SearchBook();
            searchBook.Show();
        }

        private void btnCheckoutReturn_Click(object sender, RoutedEventArgs e)
        {
            CheckoutReturn checkoutReturn = new CheckoutReturn();
            checkoutReturn.Show();
        }
    }
}
