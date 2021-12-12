using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customProject.Common
{
    public class Table:Attribute
    {
        public string TableName { get; set; }
        public string PrimaryColum { get; set; }
        public string IdendityColum { get; set; }
    }
}
