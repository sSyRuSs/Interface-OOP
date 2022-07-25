using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tuan08_Interface_THOOP
{
    public class KhachSan : BatDongSan, IPhiKinhDoanh
    {
        private int soSao;

        public int SoSao
        {
            get { return soSao; }
            set { soSao = value; }
        }
    
        public KhachSan():base()
        {
         
        }
        public KhachSan(string maSo, double chieuDai, double chieuRong, int soSao)
            : base(maSo, chieuDai, chieuRong)
        {
            this.soSao = soSao;
        }
    
        public override double tinhGiaBan()
        {
            return 100000 * soSao + 50000;
        }

        public double tinhPhiKinhDoanh()
        {
            return tinhDienTich() * 1000;
        }
        public override string ToString()
        {
            return string.Format("++Loai:{0,-15}","KhachSan") + base.ToString() + "SoSao: " + soSao;
        }
        public override void xuat()
        {
           // Console.WriteLine(this.ToString());
            base.xuat();
            Console.WriteLine("So sao: {0}", soSao);
        }
    }
}
