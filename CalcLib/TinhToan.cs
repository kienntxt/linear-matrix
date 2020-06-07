using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public static class TinhToan
    {
        /// <summary>
        /// Noi suy tuyen tinh Y tai X
        /// </summary>
        /// <param name="x1">x Diem dau</param>
        /// <param name="y1">y Diem dau</param>
        /// <param name="x2">x Diem cuoi</param>
        /// <param name="y2">y Diem cuoi</param>
        /// <param name="x">x noi suy</param>
        /// <returns>y tai x</returns>
        static decimal TinhY(decimal x1, decimal y1, decimal x2, decimal y2, decimal x)
        {
            /*  x  - x1   y  - y1           (x - x1) * (y2 - y1)
             *  ------- = -------   => y =  -------------------- + y1
             *  x2 - x1   y2 - y1                (x2 - x1)
             */

            if (x == x1) return y1;
            if (x == x2) return y2;
            if (x1 == x2) return y1;
            if (y1 == y2) return y1;
            return (x - x1) * (y2 - y1) / (x2 - x1) + y1;
        }
        /// <summary>
        /// Noi suy tuyen tinh X tai Y
        /// </summary>
        /// <param name="x1">x Diem dau</param>
        /// <param name="y1">y Diem dau</param>
        /// <param name="x2">x Diem cuoi</param>
        /// <param name="y2">y Diem cuoi</param>
        /// <param name="y">y noi suy</param>
        /// <returns>x tai y</returns>
        static decimal TinhX(decimal x1, decimal y1, decimal x2, decimal y2, decimal y)
        {
            /*  x  - x1   y  - y1           (y - y1) * (x2 - x1)
             *  ------- = -------   => x =  -------------------- + x1
             *  x2 - x1   y2 - y1                (y2 - y1)
             */

            if (y == y1) return x1;
            if (y == y2) return x2;
            if (y1 == y2) return x1;
            if (x1 == x2) return x1;
            return (y - y1) * (x2 - x1) / (y2 - y1) + x1;
        }
        /// <summary>
        /// Noi suy tuyen tinh H tu ma tran H theo R va K
        /// </summary>
        /// <param name="input">Ma tran H theo R,K</param>
        /// <param name="rx">Diem noi suy theo R</param>
        /// <param name="kx">Diem noi suy theo K</param>
        /// <returns>Gia tri noi suy H tai Rx,Kx</returns>
        public static decimal NoiSuyH(List<MucNuocLonNhatTaiViTriBai> input, decimal rx, decimal kx)
        {
            //R: area, K: distance
            /*
             R:     R1      R2      ...     Rn
             K1     h11     h12     ...     h1n
             K2     h21     h22     ...     h2n
             ..     ...     ...     ...     ...
             Km     hm1     hm2     ...     hmn
             */
            //Tim R1 = max(r <= rx)
            var r1 = input.Where(x => x.R <= rx).Select(x => x.R).Max();
            //Tim K = max(k <= kx) va H theo R1
            var r1k1h1 = input.Where(x => x.R == r1).Where(x => x.K <= kx).OrderBy(x => x.K).LastOrDefault();
            //Tim K = min(k >= kx) va H theo R1
            var r1k2h2 = input.Where(x => x.R == r1).Where(x => x.K >= kx).OrderBy(x => x.K).FirstOrDefault();
            //--- noi suy H tai kx theo R1:
            var r1h = TinhY(r1k1h1.K, r1k1h1.H, r1k2h2.K, r1k2h2.H, kx);

            //Tim R2 = min(r >= rx)
            var r2 = input.Where(x => x.R >= rx).Select(x => x.R).Min();
            //Tim K = max(k <= kx) va H theo R2
            var r2k1h1 = input.Where(x => x.R == r2).Where(x => x.K <= kx).OrderBy(x => x.K).LastOrDefault();
            //Tim K = min(k >= kx) va H theo R2
            var r2k2h2 = input.Where(x => x.R == r2).Where(x => x.K >= kx).OrderBy(x => x.K).FirstOrDefault();
            //--- noi suy H tai kx theo R1:
            var r2h = TinhY(r2k1h1.K, r2k1h1.H, r2k2h2.K, r2k2h2.H, kx);

            //--- noi suy H tai rx theo r1h va r2h
            var h = TinhY(r1, r1h, r2, r2h, rx);
            return h;
        }
    }
}
