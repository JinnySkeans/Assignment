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
using System.Xml;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for StaffLogin.xaml
    /// </summary>
    public partial class StaffLogin : Window
    {
        //sets document to be used as xmlCm
        private XmlControllerM xmlCm;

        public StaffLogin()
        {
            xmlCm = new XmlControllerM();
            InitializeComponent();
        }

        private void btnStaffLogin_Click(object sender, RoutedEventArgs e)
        {
            //string settings the libraryID as the value of the text box
            string staffID = txtStaffID.Text;

            //calls xml document
            XmlDocument doc = new XmlDocument();
            doc.Load("Staff.xml");

            //compares the library_card_number in teh xml with the libraryID string
            XmlNode staff = doc!.SelectSingleNode("/staff/librarian[staff_card_number ='" + staffID + "']");
            //uses the txtBoxes to say what is going to be used to put in to the xml document          

            //if statement to check if the member exists and displays a message if not
            if (staff == null)
            {
                MessageBox.Show($"User: '{staffID}' not found, please try again.");
                return;
            }

            //if statement to check if the LibraryID is correct and grant access with display message
            if (string.IsNullOrWhiteSpace(staff.ChildNodes.Item(2).InnerText) == false)
            {
                //if it does have contents display message and grant access
                MessageBox.Show($"Welcome, {staff.ChildNodes.Item(0).InnerText}");


                Staff newStaff = new Staff();
                newStaff.Show();
            }
        }
    }
}

