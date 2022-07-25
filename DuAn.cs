using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tuan08_Interface_THOOP
{
    public class DuAn
    {
        private string tenDuAn;
        private string chuDauTu;
        private List<BatDongSan> danhSachBDS;

        public DuAn()
        {
             tenDuAn ="";
             chuDauTu ="";
             danhSachBDS = new List<BatDongSan>();
        }

        public BatDongSan tim(string ma)
        {
            return danhSachBDS.Find(t => t.MaSo == ma);
        }
        public void them(BatDongSan x)
        {
            if (x == null) return;

            BatDongSan bds = tim(x.MaSo);
            if (bds == null)
            {
                danhSachBDS.Add(x);
            }
            else
            {
                Console.WriteLine("BDS co ma {0} da ton tai trong danh sach!!", x.MaSo);
            }
        }

        public void loadXMLFile(string fileName)
        {
            XmlDocument reader = new XmlDocument();
            try
            {
                reader.Load(fileName);

                XmlNode duAnNode = reader.SelectSingleNode("DuAn");
                this.tenDuAn = duAnNode["TenDuAn"].InnerText;
                this.chuDauTu = duAnNode["ChuDauTu"].InnerText;
                XmlNodeList bdsNodeList = duAnNode["DanhSachBatDongSan"].SelectNodes("BatDongSan");
                foreach (XmlNode node in bdsNodeList)
                {
                    BatDongSan bds = getObject(node);
                   
                   // danhSachBDS.Add(bds); //khong kiem tra
                    them(bds); //co kiem tra ma so
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Tinh nangg moi :"+ e.Message);
            }
        }

        //co the dat lop getOject vao lop BatDongSan
        private BatDongSan getObject(XmlNode node)
        {
            BatDongSan bds = null;

            string maSo = node["MaSo"].InnerText;
            double chieuDai = double.Parse(node["ChieuDai"].InnerText);
            double chieuRong = double.Parse(node["ChieuRong"].InnerText);
            string loai = node.Attributes["Loai"].Value;
            if (loai == "Nha")
            {
                int soLau = int.Parse(node["SoLau"].InnerText);
                bds = new NhaO(maSo, chieuDai, chieuRong, soLau);
            }
            else if (loai == "Dat")
            {
                bds = new DatTrong(maSo, chieuDai, chieuRong);
            }
            else if (loai == "KS")
            {
                int soSao = int.Parse(node["SoSao"].InnerText);
                bds = new KhachSan(maSo, chieuDai, chieuRong, soSao);
            }
            else
            {
                bds = new BietThu(maSo, chieuDai, chieuRong);
            }

            return bds;
        }


        public void xuatThongTin()
        {
            Console.WriteLine("TenDuAn: " + tenDuAn);
            Console.WriteLine("ChuDauTu: " + chuDauTu);
            Console.WriteLine("Danh sach cac BDS: ");
            foreach(BatDongSan bds in danhSachBDS)
            {
                Console.WriteLine(bds);
                //bds.xuat();
            }
        }


        public double tongGiaBan()
        {
            return danhSachBDS.Sum(t => t.tinhGiaBan());
        }

        public double tongPhiKinhDoanh()
        {
            double tong = 0;
            foreach (BatDongSan bds in danhSachBDS)
            {
                if (bds is IPhiKinhDoanh)
                {
                    IPhiKinhDoanh phiKD = (IPhiKinhDoanh)bds;
                    tong += phiKD.tinhPhiKinhDoanh();
                }

            }
            return tong;

            // return danhSachBDS.Where(t => t is IPhiKinhDoanh).Sum(t => ((IPhiKinhDoanh)t).tinhPhiKinhDoanh());
        }
        public int demSoBDSTinhPhi()
        {
            int dem = 0;
            foreach (BatDongSan bds in danhSachBDS)
            {
                if (bds is IPhiKinhDoanh)
                    dem++;
            }
            return dem;

            //return danhSachBDS.Count(t => t is IPhiKinhDoanh);
        }
        public void xuatSoBDSTinhPhi()
        {
            foreach (BatDongSan bds in danhSachBDS)
            {
                if (bds is IPhiKinhDoanh)
                {
                    IPhiKinhDoanh phiKD = (IPhiKinhDoanh) bds;
                    Console.WriteLine(bds.ToString());
                    Console.WriteLine("==>PhiKinhDoanh: {0:0.00}", phiKD.tinhPhiKinhDoanh());
                }
            }

            //danhSachBDS.Where(t=>t is IPhiKinhDoanh).ToList().ForEach(t => t.xuat());
           ///danhSachBDS.Where(t => t is IPhiKinhDoanh).ToList().ForEach(t => Console.WriteLine(t));
        }

    }
}
