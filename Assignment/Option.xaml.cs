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
    /// Interaction logic for Option.xaml
    /// </summary>
    public partial class Option : Window
    {
        public Option()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            MemberLogin memberLogin = new MemberLogin();
            memberLogin.Show();
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffLogin staffLogin = new StaffLogin();
            staffLogin.Show();
        }
    }
}
