using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Appliances
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider ServiceProvider;
        public App()
        {
            ServiceCollection Services = new ServiceCollection();
            Services.AddDbContext<Data.dbContext>(option => option.UseSqlite("Data Source=Database.db"));
            Services.AddSingleton<AuthWindow>();
            ServiceProvider = Services.BuildServiceProvider();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var Window = ServiceProvider.GetService<AuthWindow>();
            Window.Show();
        }
    }
}
