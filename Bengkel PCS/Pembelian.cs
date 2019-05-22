using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bengkel_PCS
{
    public class Pembelian
    {
        private string idbarang;
        private string namabarang;
        private long harga;
        private int jumlah;
        private int hbeli;

        public string Idbarang
        {
            get
            {
                return idbarang;
            }

            set
            {
                idbarang = value;
            }
        }

        public string Namabarang
        {
            get
            {
                return namabarang;
            }

            set
            {
                namabarang = value;
            }
        }

        public long Harga
        {
            get
            {
                return harga;
            }

            set
            {
                harga = value;
            }
        }

        public int Jumlah
        {
            get
            {
                return jumlah;
            }

            set
            {
                jumlah = value;
            }
        }

        public int Hbeli
        {
            get
            {
                return hbeli;
            }

            set
            {
                hbeli = value;
            }
        }

        public Pembelian(string idbarang, string namabarang, long harga, int jumlah, int hbeli)
        {
            this.Idbarang = idbarang;
            this.Namabarang = namabarang;
            this.Harga = harga;
            this.Jumlah = jumlah;
            this.Hbeli = hbeli;
        }
    }
}
