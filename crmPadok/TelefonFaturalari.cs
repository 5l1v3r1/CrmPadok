using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crmPadok
{
    class TelefonFaturalari
    {
        string telNo, isim, faturaDonemi, fiyat;

        public string FaturaDonemi
        {
            get
            {
                return faturaDonemi;
            }

            set
            {
                faturaDonemi = value;
            }
        }

        public string Fiyat
        {
            get
            {
                return fiyat;
            }

            set
            {
                fiyat = value;
            }
        }

        public string TelNo
        {
            get
            {
                return telNo;
            }

            set
            {
                telNo = value;
            }
        }

        public string Isim
        {
            get
            {
                return isim;
            }

            set
            {
                isim = value;
            }
        }
        public override string ToString()
        {
            return telNo + " " + isim + " " + faturaDonemi + " " + fiyat + " TL";
        }
        public TelefonFaturalari(string telNo, string isim, string faturaDonemi, string fiyat)
        {
            this.TelNo = telNo;
            this.Isim = isim;
            this.FaturaDonemi = faturaDonemi;
            this.Fiyat = fiyat;
        }
    }
}
