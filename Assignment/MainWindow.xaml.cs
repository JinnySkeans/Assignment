﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {
            //manageBooks manageBooks = new manageBooks();
            //manageBooks.Show();
            CheckoutReturn searchBooks = new CheckoutReturn();
            searchBooks.Show();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Option option = new Option();
            option.Show();
        }
    }
}
