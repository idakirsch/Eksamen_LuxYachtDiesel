using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
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
using BIZ;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Min Mail
    ///     Hej
    ///         Da det er svært at se bunden af teksten når det er Bold, spørger jeg om tilladelse til at ændre i Fontsize
    ///         Er dette okey?
    ///     Med Venlig Hilsen
    ///     Ida Jessen Møller
    /// Svar 
    ///     Hej Ida
    ///         Jeg har undersøgt sagen og har talt med ledelsen i LuxYachtDiesel omkring dine ønsker.
    ///         Vi er alle enige om, at det er et godt og hensigtsmæssigt ændringsforslag, som du hermed har tilladelse til at implementere.
    ///     Venlig hilsen
    ///     Jens Clausen
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ;
        UserControlCustomer UCC;
        UserControlDailyPrice UCDP;
        UserControlDiesel UCD;
        UserControlSupplier UCS;
        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();
            MainGrid.DataContext = BIZ;

            UCC = new UserControlCustomer(BIZ);
            UCDP = new UserControlDailyPrice(BIZ);
            UCD = new UserControlDiesel(BIZ);
            UCS = new UserControlSupplier(BIZ);

            DieselTab.Content = UCD;
            CustomerTap.Content = UCC;
            SupplierTap.Content = UCS;
            DailyPriceTap.Content = UCDP;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                await BIZ.GetAllCurrencysWebAPI();
                await Task.Delay(300000);
            }
        }
    }
}
