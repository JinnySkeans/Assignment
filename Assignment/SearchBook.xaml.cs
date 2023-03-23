using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SearchBook.xaml
    /// </summary>
    public partial class SearchBook : Window
    {
        public SearchBook()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"Library.xml");

            DataView dv = ds.Tables[0].DefaultView;

            StringBuilder filter = new StringBuilder();
            if (string.IsNullOrWhiteSpace(txtTitle.Text) == false)
            {
                filter.Append($"[title] Like '%{txtTitle.Text}%' OR");
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text) == false)
            {
                filter.Append($" [author] Like '%{txtAuthor.Text}%' OR");
            }
            if (string.IsNullOrWhiteSpace(txtISBN.Text) == false)
            {
                filter.Append($" [isbn] Like '%{txtISBN.Text}%' OR");
            }

            filter.Remove(filter.Length - 3, 3);
            dv.RowFilter = filter.ToString();

            dgBooks.ItemsSource = dv;
            dgBooks.Items.Refresh();
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView row = dgBooks.SelectedItem as DataRowView;
            txtTitle.Text = (row.Row.ItemArray[0].ToString());
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a book title.");
                return;
            }
            DateTime dueDate = DateTime.Now.AddDays(14);
            MessageBoxResult mbr = MessageBox.Show("Your book will be due back on: " + dueDate.ToShortDateString() + "\nIs this okay?", "Confirmation", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                MessageBox.Show("Booking Cancelled");
                return;
            }

            XmlController xmlc = new XmlController();
            xmlc.checkoutBook(txtTitle.Text, dueDate, " TODO libray cardnumbrt here");

        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a book title.");
                return;
            }

            MessageBoxResult mbr = MessageBox.Show("Your book has been returned.");

            if (mbr == MessageBoxResult.No)
            {
                MessageBox.Show("Return Cancelled");
                return;
            }

            XmlController xmlc = new XmlController();
            xmlc.returnBook(txtTitle.Text);
        }
    }
}

