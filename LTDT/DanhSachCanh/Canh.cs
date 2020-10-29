using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoThiTrongSo
{
    class Canh
    {
        private int dau;
        private int cuoi;
        private int trongSo;

        public int Dau
        {
            get
            {
                return dau;
            }

            set
            {
                dau = value;
            }
        }

        public int Cuoi
        {
            get
            {
                return cuoi;
            }

            set
            {
                cuoi = value;
            }
        }

        public int TrongSo
        {
            get
            {
                return trongSo;
            }

            set
            {
                trongSo = value;
            }
        }

        public Canh(int dau, int cuoi, int trongSo)
        {
            this.Dau = dau;
            this.Cuoi = cuoi;
            this.TrongSo = trongSo;
        }
        public override string ToString()
        {
            return dau + "," + cuoi + "," + trongSo;
        }
    }
}
