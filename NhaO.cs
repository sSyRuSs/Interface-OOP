using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuan08_Interface_THOOP
{
    public class NhaO : BatDongSan
    {
        private int soLau;

        public int SoLau
        {
            get { return soLau; }
            set { soLau = value; }
        }
    
        public NhaO():base()
        {
            this.soLau = 0;
        }
        public NhaO(string maSo, double chieuDai, double chieuRong, int soLau)
            : base(maSo,chieuDai,chieuRong)
        {
            this.soLau = soLau;
        }
        public override double tinhGiaBan()
        {
            return tinhDienTich() * 10000 + soLau * 100000;
        }

        public override string ToString()
        {
            return string.Format("++Loai:{0,-15}","NhaO") +  base.ToString() + "SoLau: " + soLau;
        }


        public override void xuat()
        {
            //chung
            base.xuat(); //xuat string maSo, double chieuDai, double chieuRong
            //rieng
            Console.WriteLine("So Lau: {0}", soLau);

            //Console.WriteLine(this.ToString());
        }
    }
}
