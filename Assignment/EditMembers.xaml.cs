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
    /// Interaction logic for EditMembers.xaml
    /// </summary>
    public partial class EditMembers : Window
        {
            //sets document to be used as xmlCm
            private XmlControllerM xmlCm;
            public EditMembers()
            {
                xmlCm = new XmlControllerM();
                InitializeComponent();
            }

            //event for adding a member on button click
            private void btnAddMember_Click(object sender, RoutedEventArgs e)
            {
                Member newMember = new Member();

                //uses the txtBoxes to say what is oing to be used to put in to the xml document
                newMember.firstName = txtFirstName.Text;
                newMember.lastName = txtLastName.Text;
                newMember.email = txtEmail.Text;
                newMember.phone = txtPhone.Text;
                newMember.libraryID = txtLibraryID.Text;
                
                //calls method
                xmlCm.AddMember(newMember);
                MessageBox.Show("Member Record Added");
            }

        //event for delete member
        private void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (xmlCm.deleteMember(txtLibraryID.Text))
            {
                MessageBox.Show("Member Successfully Deleted.");
            }
            else
            {
                MessageBox.Show("Member Record Could Not Be Found.");
            }
        }
         //event for update member
        private void btnUpdateMember_Click(object sender, RoutedEventArgs e)
        {
            Member newMember = new Member();

            newMember.firstName = txtFirstName.Text;
            newMember.lastName = txtLastName.Text;
            newMember.email = txtEmail.Text;
            newMember.phone = txtPhone.Text;
            

            xmlCm.updateMember(txtLibraryID.Text, newMember);
            MessageBox.Show("Member Record Updated");

        }
    }
}
