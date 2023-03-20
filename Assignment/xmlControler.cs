﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment
{
    public class XmlController
    {
        string path = "Library.xml";
        public void AddBook(Book newBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode ROOT = doc.SelectSingleNode("/book_library");
            XmlNode Book = doc.CreateElement("book");
            XmlNode Title = doc.CreateElement("title");
            XmlNode Author = doc.CreateElement("author");
            XmlNode Year = doc.CreateElement("year");
            XmlNode Publisher = doc.CreateElement("publisher");
            XmlNode ISBN = doc.CreateElement("isbn");
            XmlNode Category = doc.CreateElement("category");

            Title.InnerText = newBook.title;
            Author.InnerText = newBook.author;
            Year.InnerText = newBook.year;
            Publisher.InnerText = newBook.year;
            ISBN.InnerText = newBook.length.ToString();
            Category.InnerText = newBook.rating;

            Book.AppendChild(Title);
            Book.AppendChild(Author);
            Book.AppendChild(Year);
            Book.AppendChild(Publisher);
            Book.AppendChild(ISBN);
            Book.AppendChild(Category);

            ROOT.AppendChild(Book);
            doc.Save(path);
        }

        public void deleteBook(string title)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//book[title = '" + title + "']");
            nodes.ParentNode.RemoveChild(nodes);
            doc.Save(path);

        }

        public void updateBook(string title, Book newBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldBook = doc!.SelectSingleNode("//book[title='" + title + "']");
            oldBook.ChildNodes.Item(0).InnerText = newBook.title;
            oldBook.ChildNodes.Item(1).InnerText = newBook.author;
            oldBook.ChildNodes.Item(2).InnerText = newBook.year;
            oldBook.ChildNodes.Item(3).InnerText = newBook.publisher;
            oldBook.ChildNodes.Item(4).InnerText = newBook.isbn.ToString();
            oldBook.ChildNodes.Item(5).InnerText = newBook.category;

            doc.Save(path);


        }
    }
}