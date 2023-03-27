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
            private XmlControllerM xmlCm;
            public EditMembers()
            {
                xmlCm = new XmlControllerM();
                InitializeComponent();
            }

            private void btnAddMember_Click(object sender, RoutedEventArgs e)
            {
                Member newMember = new Member();

                newMember.firstName = txtFirstName.Text;
                newMember.lastName = txtLastName.Text;
                newMember.firstLineAddress = txtFirstAddress.Text;
            newMember.secondLineAddress = txtSecondAddress.Text;
                newMember.city = txtCity.Text;
                newMember.county = txtCounty.Text;
                newMember.postcode = txtPostcode.Text;
                newMember.libraryID = txtLibraryID.Text;

                xmlCm.AddMember(newMember);
                MessageBox.Show("Member Record Added");
            }

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

        private void btnUpdateMember_Click(object sender, RoutedEventArgs e)
        {
            Member newMember = new Member();

            newMember.firstName = txtFirstName.Text;
            newMember.lastName = txtLastName.Text;
            newMember.firstLineAddress = txtFirstAddress.Text;
            newMember.secondLineAddress = txtSecondAddress.Text;
            newMember.city = txtCity.Text;
            newMember.county = txtCounty.Text;
            newMember.postcode = txtPostcode.Text;

            xmlCm.updateMember(txtLibraryID.Text, newMember);
            MessageBox.Show("Member Record Updated");

        }
    }
}
