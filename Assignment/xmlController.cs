using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Assignment
{
    //Class for XML control using Library.xml
    public class XmlController
    {
        //sets the string "path" as Library.xml to call throughout the class with ease
        string path = "Library.xml";

        //method to add a book to the Library.xml file
        public void AddBook(Book newBook)
        {
            //loads the xml document Library.xml
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            //creates each node of the xml document
            XmlNode ROOT = doc.SelectSingleNode("/library");
            XmlNode Book = doc.CreateElement("book");
            XmlNode Title = doc.CreateElement("title");
            XmlNode Author = doc.CreateElement("author");
            XmlNode Year = doc.CreateElement("year");
            XmlNode Publisher = doc.CreateElement("publisher");
            XmlNode ISBN = doc.CreateElement("isbn");
            XmlNode Category = doc.CreateElement("category");

            //
            Title.InnerText = newBook.title;
            Author.InnerText = newBook.author;
            Year.InnerText = newBook.year;
            Publisher.InnerText = newBook.publisher;
            ISBN.InnerText = newBook.isbn.ToString();
            Category.InnerText = newBook.category;

            //defines which nodes to append on the child of the XML
            Book.AppendChild(Title);
            Book.AppendChild(Author);
            Book.AppendChild(Year);
            Book.AppendChild(Publisher);
            Book.AppendChild(ISBN);
            Book.AppendChild(Category);

            ROOT.AppendChild(Book);
            doc.Save(path);
        }

        //sets method for deleting a book
        public bool deleteBook(string title)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            //uses the title node to delete the entire child
            XmlNode node = doc.SelectSingleNode("//book[title = '" + title + "']");
            if (node == null)
            {
                return false;
            }
            node.ParentNode.RemoveChild(node);
            doc.Save(path);
            return true;

        }

        //method for updating a book
        public void updateBook(string title, Book newBook)
        {
            //uses the title node to append any other node of the book
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc!.SelectSingleNode("//book[title='" + title + "']");
            oldBook.ChildNodes.Item(0).InnerText = newBook.title;
            oldBook.ChildNodes.Item(1).InnerText = newBook.author;
            oldBook.ChildNodes.Item(2).InnerText = newBook.year;
            oldBook.ChildNodes.Item(3).InnerText = newBook.publisher;
            oldBook.ChildNodes.Item(4).InnerText = newBook.isbn.ToString();
            oldBook.ChildNodes.Item(5).InnerText = newBook.category;

            //saves the xml document
            doc.Save(path);


        }

        //method for checkingout a book
        public void checkoutBook(string title, DateTime dueDate, string checkedOutBy)
        {
            //loads xml document
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            //uses the title node to checkout book
            XmlNode oldBook = doc!.SelectSingleNode("//book[title='" + title + "']");
            //if statement to check if the book exists and displays a message if not
            if (oldBook == null)
            {
                MessageBox.Show($"We do not stock '{title}'.");
                return;
            }

            //if statement to check if the duedate node on teh xml file has any contents
            if (string.IsNullOrWhiteSpace(oldBook.ChildNodes.Item(6).InnerText) == false)
            {
                //if it does have contents it means its checked out
                MessageBox.Show($"{oldBook.ChildNodes.Item(0).InnerText} is currently checked out,\nPlease check back later.");
                return;
            }

            //if not update the checkedout and due date nodes
            oldBook.ChildNodes.Item(6).InnerText = checkedOutBy;
            oldBook.ChildNodes.Item(7).InnerText = dueDate.ToShortDateString();

            //save and display successful
            doc.Save(path);
            MessageBox.Show("Booking Successful.");

        }

        //method for returning a book
        public void returnBook(string title)
        {
            //loads document and checks by title
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc!.SelectSingleNode("//book[title='" + title + "']");

            if (oldBook == null)
            {
                MessageBox.Show($"We do not stock '{title}'.");
                return;
            }

            if (string.IsNullOrWhiteSpace(oldBook.ChildNodes.Item(6).InnerText) == true)
            {
                MessageBox.Show($"You have currently not checked out {oldBook.ChildNodes.Item(0).InnerText}.");
                return;
            }

            //if the book is checked out then change nodes to empty
            oldBook.ChildNodes.Item(6).InnerText = string.Empty;
            oldBook.ChildNodes.Item(7).InnerText = string.Empty;
            oldBook.ChildNodes.Item(8).InnerText = string.Empty;

            //save and display
            doc.Save(path);
            MessageBox.Show("Return Succesful.");
        }

        //method to renew a book
        public void renewBook (string title, DateTime dueDate) 
        {
            //load cml document
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc!.SelectSingleNode("//book[title='" + title + "']");
            
            if (oldBook == null)
            {
                MessageBox.Show($"We do not stock '{title}'.");
                return;
            }

            if (string.IsNullOrWhiteSpace(oldBook.ChildNodes.Item(8).InnerText) == false)
            {
                MessageBox.Show($"You have already renewed {oldBook.ChildNodes.Item(0).InnerText}.");
                return;
            }

            //check to see if the checkedoutby node of the title book has any contents 
            if (string.IsNullOrWhiteSpace(oldBook.ChildNodes.Item(6).InnerText) == true)
            {
                //if not then you have not checked the book out
                MessageBox.Show($"You have not checked out {oldBook.ChildNodes.Item(0).InnerText}.");
                return;
            }
            //change the due date and the renewed nodes
            oldBook.ChildNodes.Item(7).InnerText = dueDate.ToShortDateString();
            oldBook.ChildNodes.Item(8).InnerText = "Renewed";

            //save document
            doc.Save(path);
            MessageBox.Show("Renew Succesful.");
        }
    }
}
