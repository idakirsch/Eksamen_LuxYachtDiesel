using BIZ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UserControlDailyPrice.xaml
    /// Min mail
    ///     Hej Jens
    ///         Da det ikke er muligt at gemme tiden i databasen, spørger jeg om lov til at slette tids column’en i listView under UserControlDailyPrice
    ///     Med Venlig Hilsen
    ///     Ida Jessen Møller
    /// Svar
    ///     Det er naturligvis godkendt 
    /// </summary>
    public partial class UserControlDailyPrice : UserControl
    {
        ClassBIZ BIZ;
        public UserControlDailyPrice(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Hyperlink hl = (Hyperlink)sender;
            string navigateUri = hl.NavigateUri.ToString();
            Process.Start(new ProcessStartInfo(navigateUri));
            e.Handled = true;
        }

        private void ButtonSaveOrUpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            BIZ.InsertDieselPriceInDB();
        }
    }
}
