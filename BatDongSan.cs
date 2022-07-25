using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuan08_Interface_THOOP
{
    public abstract class BatDongSan
    {
        private string maSo;

        public string MaSo
        {
            get { return maSo; }
            set { maSo = value; }
        }

        protected double chieuDai;
        protected double chieuRong;

        public BatDongSan()
        {
            this.maSo = "000";
            this.chieuDai = 0.0;
            this.chieuRong = 0.0;
        }

        public BatDongSan(string maSo, double chieuDai, double chieuRong)
        {
            this.maSo = maSo;
            this.chieuDai = chieuDai;
            this.chieuRong = chieuRong;
        }

        public abstract double tinhGiaBan();

        public double tinhDienTich()
        {
            return chieuRong * chieuDai;
        }

        public virtual void xuat()
        {
            Console.WriteLine("Ma: {0,-10}, Dai: {1,-5} x Rong: {2, -5}",maSo,chieuDai,chieuRong);
        }

        public override string ToString()
        {
            return string.Format("Ma:{0,-5}\tDai:{1,-5} x Rong: {2,-5}",maSo, chieuDai, chieuRong); 
        }
    }
}
