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
    }
}
