using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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

        //event for search on data grid
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //fills datagrid with the contents of the xml file
            DataSet ds = new DataSet();
            ds.ReadXml(@"Library.xml");

            //defines how to view the data
            DataView dv = ds.Tables[0].DefaultView;

            //if statement to check title first, then author and then ISBN allowing all to be searched
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
            if (string.IsNullOrWhiteSpace(txtLibraryID.Text) == false)
            {
                filter.Append($" [checked_out_by] Like '%{txtLibraryID.Text}%' OR");
            }


            filter.Remove(filter.Length - 3, 3);
            dv.RowFilter = filter.ToString();

            dgBooks.ItemsSource = dv;
            dgBooks.Items.Refresh();
        }

        //class to allow the datagrid to be selectable and fill the text box able to be used for checkout / return
        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView row = dgBooks.SelectedItem as DataRowView;
            txtTitle.Text = (row.Row.ItemArray[0].ToString());
        }

        //event for checkout
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            //if box is empty display message
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a book title.");
                return;
            }
            //if not then give due date and ask for confirmation
            DateTime dueDate = DateTime.Now.AddDays(14);
            Member currentUser = new Member();
            MessageBoxResult mbr = MessageBox.Show("Your book will be due back on: " + dueDate.ToShortDateString() + "\nIs this okay?", "Confirmation", MessageBoxButton.YesNo);

            //if answer to messagebox is no, cancel and return display box
            if (mbr == MessageBoxResult.No)
            {
                MessageBox.Show("Booking Cancelled");
                return;
            }

            //if yes call method
            XmlController xmlc = new XmlController();
            xmlc.checkoutBook(txtTitle.Text, dueDate,"currentUser");

        }

        //event for return book
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

        //event to renew a book
        private void btnRenew_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Renew date Cancelled");
                return;
            }

            XmlController xmlc = new XmlController();
            xmlc.renewBook(txtTitle.Text, dueDate);

        }


    }
}

