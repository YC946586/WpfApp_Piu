using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp_Piu.SqlSugar.Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class Piu
    {
        public Piu()
        {

        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>    
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:NULL
        /// Nullable:False
        /// </summary>           
        public byte[] Path { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreateDate { get; set; }

    }
}