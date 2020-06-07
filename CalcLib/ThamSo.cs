using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    /// <summary>
    /// Tham so dau vao
    /// </summary>
    public class MucNuocLonNhatTaiViTriBai
    {
        public decimal R { get; set; }
        public decimal K { get; set; }
        public decimal H { get; set; }
    }

    /// <summary>
    /// Tham so cua phuong trinh duong thang noi suy
    /// </summary>
    public class DuongThang
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
    }

    /// <summary>
    /// Toa do 2 chieu
    /// </summary>
    public class ToaDo
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}
