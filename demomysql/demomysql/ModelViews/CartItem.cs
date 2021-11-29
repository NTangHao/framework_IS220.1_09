using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
namespace demomysql.ModelViews
{
    public class CartItem
    {
        public int masp { get; set; }
        public string  tensp { get; set; }
        public string  hinhanh { get; set; }
        public double   dongia { get; set; }      
        public int soluong { get; set; }
        
        public double thanhtien => soluong * dongia;
        
    }
}
