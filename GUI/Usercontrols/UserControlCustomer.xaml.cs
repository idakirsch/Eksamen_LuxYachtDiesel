﻿using BIZ;
using Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        ClassBIZ BIZ;
        public UserControlCustomer(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
        }

        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            BIZ.enableCustomerEdit = true;
            BIZ.selectedCustomer = new ClassCustomer();
        }

        private void ButtonRediger_Click(object sender, RoutedEventArgs e)
        {
            BIZ.enableCustomerEdit = true;
        }

        private void ButtonGem_Click(object sender, RoutedEventArgs e)
        {
            BIZ.UpdateOrInsertCustomerInDB();
        }

        private void ButtonFortryd_Click(object sender, RoutedEventArgs e)
        {
            BIZ.RegretUpdateOrNewCustomerForDB();
        }
    }
}
