using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuan08_Interface_THOOP
{
    public class BietThu : BatDongSan, IPhiKinhDoanh
    {
        public BietThu():base()
        {
            
        }

        public BietThu(string maSo, double chieuDai, double chieuRong)
            : base(maSo,chieuDai,chieuRong)
        {
            
        }

        public override double tinhGiaBan()
        {
            return tinhDienTich() * 400000;
        }
        public double tinhPhiKinhDoanh()
        {
            return chieuRong * 5000;
        }
        public override string ToString()
        {
            return string.Format("++Loai:{0,-15}", "BietThu") + base.ToString();
        }
        public override void xuat()
        {
            //chung
            base.xuat(); //xuat string maSo, double chieuDai, double chieuRong
            //rieng
            //
        }
    }
}
