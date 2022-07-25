using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Tuan08_Interface_THOOP
{
    public class Program
    {
        private static int soLanNhapSai = 0;
        public static void menu()
        {
            Console.WriteLine("-MENU-");
            Console.WriteLine("0.Thoat");
            Console.WriteLine("1.Xuat DS BDS");
            Console.WriteLine("2.Tra cuu thong tin");
            Console.WriteLine("3.Tong phi kinh doanh");
            Console.WriteLine("4.Dem so BDS tinh phi");
            Console.WriteLine("5.Xuat cac BDS tinh phi ");

        }

        static void Main(string[] args)
        {
           
            //DuAn da = new DuAn();
            //da.loadXMLFile("../../DuAnBDS.xml");
            //da.xuatThongTin();
            DuAn duAn = new DuAn();
            duAn.loadXMLFile("../../DuAnBDS.xml");
            
            int chon;
            do
            {
                
                menu();
                Console.WriteLine("Lua chon: ");
                while (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Nhap sai, vui long nhap lai!");
                    soLanNhapSai++;
                    if (soLanNhapSai >= 3)
                    {
                        Console.WriteLine("Tui met roi, khong cho nhap nua!");
                        for (int i = 3; i > 0; i--)
                        {
                            Console.WriteLine(i);
                            Thread.Sleep(1000);                            
                        }
                        Console.WriteLine("Nghi khoe!, bye!");
                        Environment.Exit(0);
                    }
                }



                switch(chon)
                {
                    case 0:
                        {
                            Console.WriteLine("Bye!");
                            break;
                        }
                    case 1:
                        {
                            duAn.xuatThongTin();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Nhap ma :");
                            string ma = Console.ReadLine();
                            BatDongSan bds = duAn.tim(ma);

                            if (bds == null)
                            {
                                Console.WriteLine("Tim khong co thay bds ma: {0}", ma);
                            }
                            else
                            {
                                bds.xuat();
                            }

                            break;
                        }
                    case 3:
                        {
                            double tongPhi = duAn.tongPhiKinhDoanh();
                            Console.WriteLine("Tong phi: {0:00}", tongPhi);
                            break;
                        }
                    case 4:
                        {
                            int demBDSPhi = duAn.demSoBDSTinhPhi();
                            Console.WriteLine("So: {0:00}", demBDSPhi);
                            break;
                        }
                    case 5:
                        {
                            duAn.xuatSoBDSTinhPhi();
                            break;
                        }
                }
                Console.ReadLine();
                Console.Clear();
            }while (chon!= 0);

        }
    }
}
