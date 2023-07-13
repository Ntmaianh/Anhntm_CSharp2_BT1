using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP2
{
    internal class BikeService
    {
        Bike xeDap;
        public void NhapThongTin(List<Bike> lstXeDap)
        {
            int id = 1;
            string tiepTuc;
            do
            {
                xeDap = new Bike();
                // so sánh id với id đã có trong list :))
                while (lstXeDap.Any(b => b.Id == id))
                {
                    id++;
                }
                xeDap.Id = id;
                Console.WriteLine("Nhập tên: ");
                xeDap.Name = Console.ReadLine();
                Console.WriteLine("Nhập HSX: ");
                xeDap.Hsx = Console.ReadLine();
                Console.WriteLine("Bạn có muốn tiếp tục không?(y/n) ");
                tiepTuc = Console.ReadLine();
                lstXeDap.Add(xeDap);
            } while (tiepTuc.Equals("y"));
        }

        public void InThongTin(List<Bike> lstXeDap)
        {
            if (lstXeDap.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
            }
            else
            {
                foreach (var item in lstXeDap)
                {
                    item.InThongTin();
                }
            }
        }
        public void GhiFile(string path, List<Bike> lstXeDap)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Không tồn tại file này!");
            }
            else
            {
                foreach (var item in lstXeDap)
                {
                    string lines = item.ObjToString();
                    File.AppendAllText(path, lines);
                }
                Console.WriteLine("Ghi file thành công");
            }
        }
        public List<Bike> Docfile(string path)
        {
            List<Bike> lstFile = new List<Bike>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Trim().Length == 0)
                {
                    continue;
                }
                else
                {
                    string[] attr = line.Split('|');
                    Bike b = new Bike();
                    b.Id = Convert.ToInt32(attr[0]);
                    b.Name = attr[1];
                    b.Hsx = attr[2];
                    lstFile.Add(b);
                }
            }
            return lstFile;
        }
        public void XoaXeDapTheoId(List<Bike> lstXeDap)
        {
            Console.WriteLine("Nhập id cần xóa: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var xeDap = (from b in lstXeDap
                         where b.Id == id
                         select b).FirstOrDefault();
            if (xeDap != null)
            {
                lstXeDap.Remove(xeDap);
                Console.WriteLine("Đã xóa thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }
        }
    }
}

