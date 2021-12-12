﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customProject.Common;

namespace Customproject.Entity
{
    [Table(PrimaryColum = "CategoryID",TableName = "Categories", IdendityColum ="CategoryID")]
    public class Categories

    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

    }
}
