using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTDT
{
    class Test
    {
        static void Main(string[] args)
        {
            string fileName = "DanhSachBacVoHuong.DAT";
            List<LinkedList<int>> danhsachke = new List<LinkedList<int>>();
            TienIchDoThi.GhiFile(fileName);
            danhsachke = TienIchDoThi.DocFile(fileName);
            Console.WriteLine();
            InThongTin(danhsachke);
            Console.WriteLine();
            TienIchDoThi.BacCuaDinh(danhsachke,fileName);
            Console.WriteLine();
            if (TienIchDoThi.KiemTraTinhLienThong(danhsachke)==false)
            {
                Console.WriteLine("Do thi khong co tinh lien thong");
            }
            else
            {
                Console.WriteLine("Do thi co tinh lien thong");

            }
          
        }

        static void InThongTin(List<LinkedList<int>> danhsachke)
        {
            int i = 0;
            foreach (var item in danhsachke)
            {
                Console.Write("Dinh {0}: ", i);
                foreach (var item1 in item)
                {
                    Console.Write(item1 + " ");
                }
                Console.WriteLine();
                i++;
            }
        }


    }
}
