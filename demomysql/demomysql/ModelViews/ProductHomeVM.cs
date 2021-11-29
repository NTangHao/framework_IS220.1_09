using demomysql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.ModelViews
{
    public class ProductHomeVM
    {
        public Danhmuc danhmuc { get; set; }
        public List<Sanpham> lsSanpham { get; set; }
    }
}
