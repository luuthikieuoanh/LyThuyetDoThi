using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DoThiTrongSo
{
    class TienIchDTTS
    {
        
        //ghi file
        public static void GhiFile(string fileName,List<Canh> l)
        {
            //BinaryWriter bw;
            //int soCanh = 5;
            //int soDinh = 5;

            ////Nhap danh sach canh
            //string s0 = "0,2,4"; //0
            //string s1 = "2,1,6";//1
            //string s2 = "0,1,5";//2
            //string s3 = "0,4,7";//3
            //string s4 = "1,4,9";//4


            //try
            //{
            //    bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            //    bw.Write(soCanh);
            //    bw.Write(s0);
            //    bw.Write(s1);
            //    bw.Write(s2);
            //    bw.Write(s3);
            //    bw.Write(s4);
            //    bw.Close();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("khong ghi duoc file");
            //}
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create)))
                {
                    Canh[] list = l.ToArray();

                    bw.Write(list.Length);
                    for (int i = 0; i < list.Length; i++)
                    {
                        bw.Write(list[i].Dau);
                        bw.Write(list[i].Cuoi);
                        bw.Write(list[i].TrongSo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        //doc file
        public static List<Canh> DocFile(string fileName)
        {
            //List<LinkedList<int>> danhsachtrongso = new List<LinkedList<int>>();

            //int x = 0;
            //string s0 = "";
            //BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));

            //try
            //{
            //    int soCanh = br.ReadInt32();
            //    Console.WriteLine("So canh: {0}", soCanh);

            //    for (int i = 0; i < soCanh; i++)
            //    {
            //        LinkedList<int> t = new LinkedList<int>();
            //        s0 = br.ReadString();

            //        if (s0 != "")
            //        {
            //            string[] dsdinhcuacanh = s0.Split(new Char[] { ',' });
            //            for (int j = 0; j < dsdinhcuacanh.Length; j++)
            //            {
            //                x = int.Parse(dsdinhcuacanh[j]);

            //                t.AddLast(x);
            //            }
            //        }
            //        danhsachtrongso.Add(t);
            //    }
            //    br.Close();
            //    return danhsachtrongso;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open)))
                {
                    List<Canh> list = new List<Canh>();
                    int length = br.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        list.Add(new Canh(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }



        //public static int[][] TaoMaTranTrongSoTuFile(string fileName)
        //{
        //    int[][] mtTrongSo;

        //    int x = 0;
        //    string str = "";
        //    BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));
        //    int soDinh = br.ReadInt32();
        //    mtTrongSo = new int[soDinh][];//số dòng
        //    //doc file tao danh sach dinh ke bang 
        //    try
        //    {

        //        Console.WriteLine("Du lieu int: {0}", soDinh);
        //        //doc lan luot cac dong, tao ma tran trong so
        //        for (int i = 0; i < soDinh; i++)
        //        {
        //            mtTrongSo[i] = new int[soDinh];

        //            Console.WriteLine("dinh dang xet {0}:  ", i);
        //            str = br.ReadString();
        //            if (str != "")
        //            {
        //                string[] dong = str.Split(new Char[] { ',' });
        //                for (int j = 0; j < soDinh; j++)
        //                {
        //                    x = int.Parse(dong[j]);
        //                    mtTrongSo[i][j] = x;
        //                }
        //            }
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.Message + "\n Khong the doc file.");

        //    }
        //    br.Close();
        //    return mtTrongSo;

        //}
    }
}
