using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
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
using System.Xml;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MemberLogin.xaml
    /// </summary>
    public partial class MemberLogin : Window
    {
        //sets document to be used as xmlCm
        private XmlControllerM xmlCm;

        public MemberLogin()
        {
            xmlCm = new XmlControllerM();
            InitializeComponent();
        }

        private void btnMemberLogin_Click(object sender, RoutedEventArgs e)
        {   
            //string settings the libraryID as the value of the text box
            string libraryID = txtLibraryID.Text;

            // calls the Singleton class and set currentUser to the contents of the text box
            Singleton single = Singleton.GetInstance();
            single.currentUser = txtLibraryID.Text;
            
            //calls xml document
            XmlDocument doc = new XmlDocument();
            doc.Load("Members.xml");
           
            //compares the library_card_number in the xml with the libraryID string
            XmlNode oldMember = doc!.SelectSingleNode("/members/member[library_card_number ='" + libraryID + "']");
            //uses the txtBoxes to say what is going to be used to put in to the xml document          

            //if statement to check if the member exists and displays a message if not
            if (oldMember == null)
            {
                MessageBox.Show($"User: '{libraryID}' not found, please try again.");
                return;
            }

            //if statement to check if the LibraryID is correct and grant access with display message
            if (string.IsNullOrWhiteSpace(oldMember.ChildNodes.Item(4).InnerText) == false)
            {
                //if it does have contents display message and grant access
                MessageBox.Show($"Welcome, {oldMember.ChildNodes.Item(0).InnerText}");
                

                SearchBook searchBook = new SearchBook();
                searchBook.Show();
            }
        }
    }
}
