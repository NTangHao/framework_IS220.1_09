using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
using demomysql.ModelViews;

namespace demomysql.ViewHome
{
    public class HomeViewVM
    {
        public List<Tintuc> tintucs { get; set; }

        public List<ProductHomeVM> Products { get; set; }
        
    }
}
