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
    /// Interaction logic for manageBooks.xaml
    /// </summary>
    public partial class manageBooks : Window
    {
        private XmlController xmlC;
        public manageBooks()
        {
            xmlC = new XmlController();
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            Book newBook = new Book();

            newBook.title = txtTitle.Text;
            newBook.author = txtAuthor.Text;
            newBook.year = txtYear.Text;
            newBook.publisher = txtPublisher.Text;
            if (int.TryParse(txtISBN.Text, out int ISBN) == false) 
            {
                MessageBox.Show("An ISBN must be a number");
                return;
            }
            newBook.isbn = ISBN;
            newBook.category = txtCategory.Text;

            xmlC.AddBook(newBook);
            MessageBox.Show("Book Record Added");
        }

        private void btnUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            Book newBook = new Book();

            newBook.title = txtTitle.Text;
            newBook.author = txtAuthor.Text;
            newBook.year = txtYear.Text;
            newBook.publisher = txtPublisher.Text;
            newBook.isbn = int.Parse(txtISBN.Text);
            newBook.category = txtCategory.Text;

            xmlC.updateBook(txtTitle.Text, newBook);
            MessageBox.Show("Book Record Updated");

        }

        private void btnDeleteBook_Click_1(object sender, RoutedEventArgs e)
        {
            if (xmlC.deleteBook(txtTitle.Text))
            {
                MessageBox.Show("Book Successfully Deleted.");
            }
            else
            {
                MessageBox.Show("Book Record Could Not Be Found.");
            }
            
        }


    }
}
