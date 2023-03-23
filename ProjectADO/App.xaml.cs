using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectADO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const String ConectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=football_db;Integrated Security=True";
        public static readonly Random rand = new Random();
    }
}
