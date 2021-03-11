using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp_Piu.SqlSugar;

namespace WpfApp_Piu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SqlSugarConfig sqlSugarConfig = new SqlSugarConfig();
            SqlSugarConfig.DbClient = sqlSugarConfig.GenerateDbClient();
        }
    }
}
