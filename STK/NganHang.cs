using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK
{
    public class NganHang
    {
        public string MaNganHang { get; set; }
        public string TenNganHang { get; set; }
        public List<SoTK> ListSoTK { get; set; }
    }
    public class SoTK
    {
        public int ID { get; set; }
        public double SoTienGui { get; set; }
    }
}
