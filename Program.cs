using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP2
{
    internal class Program
    {
        public delegate void del<T>(T lst);

        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Menu();
        }
        static void Menu()
        {

            int choose;
            BikeService svBike = new BikeService();
            List<Bike> lstBike = new List<Bike>();
            string path = "D:\\C#\\CSHARP2\\xeDap.txt";
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Nhập danh sách đối tượng");
                Console.WriteLine("2.Xuất danh sách dối tượng");
                Console.WriteLine("3.Lưu file - đọc file");
                Console.WriteLine("4.Xóa đối tượng theo id");
                Console.WriteLine("0.Thoát");
                Console.WriteLine("Mời bạn lựa chọn: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        del<List<Bike>> nhapTT = svBike.NhapThongTin;
                        nhapTT(lstBike);
                        break;
                    case 2:
                        del<List<Bike>> xuatTT = svBike.InThongTin;
                        xuatTT(lstBike);
                        break;
                    case 3:
                        Console.WriteLine("Ghi file");
                        File.WriteAllText(path, "");
                        svBike.GhiFile(path, lstBike);
                        Console.WriteLine("Đọc file");
                        List<Bike> lstFile = svBike.Docfile(path);
                        foreach (var item in lstBike)
                        {
                            item.InThongTin();
                        }
                        break;
                    case 4:
                        svBike.XoaXeDapTheoId(lstBike);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lụa chọn không hợp lệ.Vui lòng chọn lại: ");
                        break;
                }

            } while (choose != 0);
        }
    }
}
