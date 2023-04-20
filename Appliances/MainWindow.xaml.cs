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

namespace Appliances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbContext DbContext;
        public MainWindow(dbContext DbContext, Employee User)
        {
            this.DbContext = DbContext;
            InitializeComponent();
            var AppliancesData = DbContext.Passports.Join(DbContext.Types,
                p => p.TypeId,
                t => t.Id,
                (p, t) => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Model = p.Model,
                    Type = t.Name,
                    Cost = p.Cost,
                    DateOfIssue = p.DateOfIssue
                });
            var ContractsData = from cont in DbContext.MainContracts
                                join emp in DbContext.Employees on cont.EmployeeId equals emp.Id
                                join cust in DbContext.Customers on cont.CustomerId equals cust.Id
                                select new
                                {
                                    Id = cont.Id,
                                    EmployeeName = emp.LastName + " " + emp.FirstName,
                                    CustomerName = cust.LastName + " " + cust.FirstName,
                                    PassportId = cont.PassportId,
                                    DateOfConfirmation = cont.DateOfConfirmation,
                                    DateOfBeginning = cont.DateOfBeginning,
                                    DateOfEnding = cont.DateOfEnding
                                };

            AppliancesTable.ItemsSource = AppliancesData.ToList();
            ClientsTable.ItemsSource = DbContext.Customers.ToList();
            ContractsTable.ItemsSource = ContractsData.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}
