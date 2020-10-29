using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoThiTrongSo
{
    class Test
    {
        static void Main(string[] args)
        {
            string fileName = "DonDoThiVoHuong.DAT";
            List<Canh> list = new List<Canh>();
            list.Add(new Canh(0, 1, 5));
            list.Add(new Canh(0, 2, 4));
            list.Add(new Canh(0, 4, 7));
            list.Add(new Canh(1, 2, 6));
            list.Add(new Canh(1, 4, 9));

            TienIchDTTS.GhiFile(fileName, list);
            
            InThongTin(TienIchDTTS.DocFile(fileName));

        }
        static void InThongTin(List<Canh> danhsachtrongso)
        {
            int i = 0;
            foreach (var item in danhsachtrongso)
            {
                Console.Write("Canh {0}: ", i);
                Console.Write(item + " ");
                Console.WriteLine();
                i++;
            }
        }
    }
}
