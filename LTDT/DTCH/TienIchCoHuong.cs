using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BaiTap2
{
    class TienIchCoHuong
    {
        public static void ghiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            //Nhap danh sach dinh
            string s0 = "1,3"; //0
            string s1 = "4";//1
            string s2 = "0,1";//2
            string s3 = "1,5";//3
            string s4 = "2";//4
            string s5 = "3,4";//5

            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                bw.Write(soDinh);
                bw.Write(s0);
                bw.Write(s1);
                bw.Write(s2);
                bw.Write(s3);
                bw.Write(s4);
                bw.Write(s5);
                bw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("khong ghi duoc file");
            }
        }

        public static List<LinkedList<int>> docFile(string fileName)
        {
            List<LinkedList<int>> danhsachke = new List<LinkedList<int>>();
            int x = 0;
            string s0 = "";
            BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));

            try
            {
                int soDinh = br.ReadInt32();
                Console.WriteLine("So dinh: {0}", soDinh);

                for (int i = 0; i < soDinh; i++)
                {
                    LinkedList<int> t = new LinkedList<int>();
                    s0 = br.ReadString();

                    if (s0 != "")
                    {
                        string[] danhsachdinhke = s0.Split(new Char[] { ',' });
                        for (int j = 0; j < danhsachdinhke.Length; j++)
                        {
                            x = int.Parse(danhsachdinhke[j]);

                            t.AddLast(x);
                        }
                    }
                    danhsachke.Add(t);
                }
                return danhsachke;
            }
            catch
            {
                return null;
            }
        }
    }
}
