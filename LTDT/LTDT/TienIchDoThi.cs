using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LTDT
{
    class TienIchDoThi
    {
        //ghi file
        public static void GhiFile(string fileName)
        {
            BinaryWriter bw;
            int soDinh = 6;

            //Nhap danh sach dinh ke
            string s0 = "1,2,3";
            string s1 = "0,2,3,4";
            string s2 = "0,1,4";
            string s3 = "0,1,5";
            string s4 = "1,2,5";
            string s5 = "3,4";

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
        //doc file
        public static List<LinkedList<int>> DocFile(string fileName)
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
            catch (Exception)
            {

                throw;
            }
        }

        //kiem tra tinh lien thong
        public static bool KiemTraTinhLienThong(List<LinkedList<int>> danhsachke)
        {
            bool ketQua = true;
            int[] dinhDaXet = new int[danhsachke.Count]; //Gắn nhãn đỉnh đã xét
            Queue<int> q = new Queue<int>(); //Hàng đợi để lưu các đỉnh đang xét
            int dinhXet = -1; //khởi tạo giá trị đỉnh chọn đầu tiên là -1

            //for (int i = 0; i < dinhDaXet.Length; i++)
            //{
            //    //dinhDaXet[i] = 0;
            //    Console.WriteLine(dinhDaXet[i]);
            //}

            dinhDaXet[0] = 1; //gán nhãn phần tử dã xét thành 1
            q.Enqueue(0);

            while (q.Count > 0) //tại đây count = 1
            {
                dinhXet = q.Dequeue(); // lấy ra phần tử đang xét #0
                if (danhsachke[dinhXet].Count != 0) //số lượng đỉnh kề của phần tử đang xét #0
                {
                    foreach (var item in danhsachke[dinhXet])//lặp số đỉnh kề của phần tử đang xét #0
                    {
                        if (dinhDaXet[item] == 0) //nhãn phần tử kề phần tử đang xét =0
                        {
                            dinhDaXet[item] = 1; //trả kết quả nhãn =1
                            q.Enqueue(item); // thêm vào hàng đợi các phần tử kề 
                        }
                    }
                }
            }
            //kiểm tra tính liên thông
            foreach (var item in dinhDaXet)
            {
                if (item == 0)
                {
                    ketQua = false;
                    break;
                }
            }
            return ketQua;

        }
        //Tinh bac cua dinh
        public static void BacCuaDinh(List<LinkedList<int>> danhsachke,string fileName)
        {
            BinaryWriter bw;
            int i = 0;
           
            try
            {
                bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                foreach (var item in danhsachke)
                {
                    bw.Write("Bac cua dinh " + i + item.Count);
                    i++;


                }
                //bw.Write(s0);
                //bw.Write(s1);
                //bw.Write(s2);
                //bw.Write(s3);
                //bw.Write(s4);
                //bw.Write(s5);
                bw.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("khong ghi duoc file");
            }
        }
    }
}
