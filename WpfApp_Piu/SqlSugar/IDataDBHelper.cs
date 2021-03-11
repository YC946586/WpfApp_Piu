using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp_Piu.SqlSugar
{
    public interface IDataServerDBHelper
    {
        SqlSugarClient DbClient { get; }
    }
}
