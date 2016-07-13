using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crmPadok
{
    public partial class FaturaGoster : Form
    {
        List<Faturalar> faturalar;
        public FaturaGoster(List<Faturalar> faturalar)
        {
            InitializeComponent();
            this.faturalar = faturalar;
        }

        private void FaturaGoster_Load(object sender, EventArgs e)
        {
            Sirala();
            foreach(var fatura in faturalar)
            {
                richTextBox1.Text += fatura.ToString() + "\n";
            }
        }
        private void Sirala()
        {
            Faturalar temp;
            for (int i = 0; i < faturalar.Count; i++)
            {
                for (int j = 0; j < faturalar.Count; j++)
                {
                    if(Convert.ToInt64(faturalar[i].AboneNo)<Convert.ToInt64(faturalar[j].AboneNo))
                    {
                        temp = faturalar[j];
                        faturalar[j] = faturalar[i];
                        faturalar[i] = temp;
                    }
                }
            }
        }
    }
}
