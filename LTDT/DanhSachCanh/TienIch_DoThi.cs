using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoThi
{
    class TienIch_DoThi
    {
        /// <summary>
        /// in ma tran 
        /// </summary>
        /// <param name="mt"></param>
        public static void inMaTran(int[][] mt)
        {
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(0); j++)
                {
                    Console.Write(mt[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// in danh sach
        /// </summary>
        /// <param name="ds"></param>
        public static void inList(List<int> ds)
        {
            foreach (int x in ds)
            {
                Console.Write(x + "\t");
            }
        }

        /// <summary>
        /// tao file dong dau: so dinh
        /// tu dong thu 2 tro di la cac danh sach dinh ke tuong ung
        /// </summary>
        /// <param name="fileName"></param>
        public static void ghiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            // danh sach ke
            string s0 = "1,2,3";
            string s1 = "0,2,3,4";
            string s2 = "0,1,4";
            string s3 = "0,1,5";
            string s4 = "1,2,5";
            string s5 = "3,4";

            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Khong the tao file.");
                return;
            }

            //ghi du lieu vao file
            try
            {
                bw.Write(soDinh);
                bw.Write(s0);
                bw.Write(s1);
                bw.Write(s2);
                bw.Write(s3);
                bw.Write(s4);
                bw.Write(s5);
                //bw.Write(s6);
                //bw.Write(s7);
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Khong the ghi du lieu vao file.");
                return;
            }
            bw.Close();
            Console.WriteLine("ghi file thanh cong");
        }

        /// <summary>
        /// tao danh sach ke tu file du lieu dinh ke
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<LinkedList<int>> docFile(string fileName)
        {
            List<LinkedList<int>> danhSachKe = new List<LinkedList<int>>();
            int x = 0;
            string s0 = "";
            BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));

            //doc file tao danh sach dinh ke  
            try
            {
                int soDinh = br.ReadInt32();
                Console.WriteLine("Du lieu int: {0}", soDinh);
                //doc lan luot cac dong, tao linkedlist cac dinh ke
                for (int i = 0; i < soDinh; i++)
                {
                    LinkedList<int> t = new LinkedList<int>();

                    //Console.WriteLine("dinh dang xet {0}:  ", i);
                    s0 = br.ReadString();
                    if (s0 != "")
                    {
                        string[] danhSachDinhKe = s0.Split(new Char[] { ',' });
                        for (int j = 0; j < danhSachDinhKe.Length; j++)
                        {
                            x = int.Parse(danhSachDinhKe[j]);
                            t.AddLast(x);
                        }
                    }

                    danhSachKe.Add(t);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Khong the doc file.");

            }
            br.Close();
            return danhSachKe;

        }
        
        ///// <summary>
        ///// //tạo danh sách kề bằng cách nhập các đỉnh kề từ console
        ///// </summary>
        ///// <returns></returns>
        //public static List<LinkedList<int>> taoDanhSachKe(int soDinh)
        //{
        //    List<LinkedList<int>> danhSachKe = new List<LinkedList<int>>();
        //    int x;

        //    //tạo danh sách kề bằng cách nhập các đỉnh kề từ console
        //    for (int i = 0; i < soDinh; i++)
        //    {
        //        LinkedList<int> t = new LinkedList<int>();
        //        //nhập lần lượt các đỉnh kề của đỉnh i, thêm vào danh sách kề, dừng khi nhap -1
        //        Console.WriteLine("dinh dang xet {0}:, ", i);
        //        do
        //        {
        //            Console.Write("nhap dinh ke ket thuc bang -1: ");
        //            x = int.Parse(Console.ReadLine());
        //            if (x == -1)
        //            {
        //                break;
        //            }
        //            t.AddLast(x);
        //        } while (x != -1);

        //        danhSachKe.Add(t);
        //    }
        //    return danhSachKe;
        //}

        

        ///// <summary>
        ///// tao ma tran ke tu danh sach ke
        ///// </summary>
        ///// <param name="danhSachKe"></param>
        ///// <returns></returns>
        //public static int[][] chuyenDSKeThanhMaTranKe(List<LinkedList<int>> danhSachKe)
        //{
        //    int[][] maTranKe = new int[danhSachKe.Count][];

        //    for (int i = 0; i < danhSachKe.Count; i++)
        //    {
        //        maTranKe[i] = new int[danhSachKe.Count];

        //        foreach (int x in danhSachKe[i])
        //        {
        //            maTranKe[i][x] = 1;
        //        }

        //    }
        //    return maTranKe;
        //}

        //public static int[][] TaoMaTranTrongSoTuFile(string fileName)
        //{
        //    int[][] mtTrongSo;

        //    int x = 0;
        //    string str = "";
        //    BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));
        //    int soDinh = br.ReadInt32();
        //    mtTrongSo = new int[soDinh][];
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
        
        /// <summary>
        /// in danh sach cac dinh ke
        /// </summary>
        /// <param name="danhSachKe"></param>
        public static void inDanhSachKe(List<LinkedList<int>> danhSachKe)
        {
            for (int i = 0; i < danhSachKe.Count; i++)
            {
                Console.Write("dinh {0}, ke cac dinh: ", i);
                foreach (int xx in danhSachKe[i])
                {
                    Console.Write(xx + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// in danh sach bac o dinh
        /// </summary>
        /// <param name="danhSachKe"></param>
        public static List<int> taoDanhSachBac(List<LinkedList<int>> danhSachKe)
        {
            List<int> danhSachBac = new List<int>();
            for (int i = 0; i < danhSachKe.Count; i++)
            {
                danhSachBac.Add(danhSachKe[i].Count);
            }

            return danhSachBac;
        }
        /// <summary>
        /// tao danh sach bac o dinh
        /// </summary>
        /// <param name="danhSachKe"></param>
        /// <returns></returns>
        public static int[] taoListDanhSachBac(List<LinkedList<int>> danhSachKe)
        {
            int[] danhSachBac = new int[danhSachKe.Count];
            for (int i = 0; i < danhSachKe.Count; i++)
            {
                danhSachBac[i] = danhSachKe[i].Count;
            }

            return danhSachBac;
        }

        
        /// <summary>
        /// tra ket qua true neu do thi lien thong
        /// </summary>
        /// <param name="danhSachKe"></param>
        /// <returns></returns>
        public static bool kiemTraLienThong(List<LinkedList<int>> danhSachKe)
        {
            //chuan bi
            bool ketQua = true;
            int[] dinhDaXet = new int[danhSachKe.Count];
            Queue<int> q = new Queue<int>();
            int dinhXet = -1;

            for (int i = 0; i < dinhDaXet.Length; i++)
            {
                dinhDaXet[i] = 0;
            }

            //buoc 1
            dinhDaXet[0] = 1;
            q.Enqueue(0);

            //buoc 2, 3
            while (q.Count > 0)
            {
                dinhXet = q.Dequeue();
                if (danhSachKe[dinhXet].Count != 0)
                {
                    foreach (int x in danhSachKe[dinhXet])
                    {
                        if (dinhDaXet[x] == 0)
                        {
                            dinhDaXet[x] = 1;
                            q.Enqueue(x);
                        }
                    }
                }
            }

            //buoc 4
            foreach (int x in dinhDaXet)
            {
                if (x == 0)
                {
                    ketQua = false;
                    break;
                }
            }
            return ketQua;
        }
    }
}
