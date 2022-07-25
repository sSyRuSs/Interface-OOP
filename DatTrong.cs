using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuan08_Interface_THOOP
{
    public class DatTrong : BatDongSan
    {
        public DatTrong():base()
        {
            
        }
        public DatTrong(string maSo, double chieuDai, double chieuRong)
            : base(maSo,chieuDai,chieuRong)
        {

        }
        public override double tinhGiaBan()
        {
            return tinhDienTich() * 10000;
        }

        public override string ToString()
        {
            return string.Format("++Loai:{0,-15}","DatTrong") + base.ToString();
        }
        public override void xuat()
        {
            base.xuat();
        }
    }
}
