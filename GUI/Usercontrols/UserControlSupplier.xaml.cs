using BIZ;
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
    /// Interaction logic for UserControlSupplier.xaml
    /// </summary>
    public partial class UserControlSupplier : UserControl
    {
        ClassBIZ BIZ;
        public UserControlSupplier(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
        }
        private void ButtonOpret_Click(object sender, RoutedEventArgs e)
        {
            BIZ.enableSupplierEdit = true;
            BIZ.selectedSupplier = new ClassSupplier();
        }

        private void ButtonRediger_Click(object sender, RoutedEventArgs e)
        {
            BIZ.enableSupplierEdit = true;
        }

        private void ButtonGem_Click(object sender, RoutedEventArgs e)
        {
            BIZ.UpdateOrInsertSupplierInDB();
        }

        private void ButtonFortryd_Click(object sender, RoutedEventArgs e)
        {
            BIZ.RegretUpdateOrNewSupplierForDB();
        }
    }
}
