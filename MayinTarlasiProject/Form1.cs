using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasiProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TarlaOlustur(10, 10);
        }
        private void ortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TarlaOlustur(13, 13);
        }

        private void zorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TarlaOlustur(16, 16);
        }

        void TarlaOlustur(int satir, int sutun)
        {
            flowLayoutPanel1.Controls.Clear();
            int mayin = (satir * sutun) / 10;
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();
            for (int i = 0; i < mayinlar.Length; i++)
            {
                int secilen = rnd.Next(0, (satir * sutun));
                if (mayinlar.Contains(secilen))
                    i--;
                else
                    mayinlar[i] = secilen;
            }

            for (int i = 0; i < satir * sutun; i++)
            {
                Button btn = new Button();
                btn.Width = btn.Height = 30;
                btn.BackColor = Color.Green;
                if (mayinlar.Contains(i))
                {
                    btn.Tag = true;
                }
                else
                {
                    btn.Tag = false;
                }
                btn.Click += Btn_Click;
                btn.Margin = new Padding(5, 5, 0, 0);
                flowLayoutPanel1.Controls.Add(btn);
            }
            flowLayoutPanel1.Width = sutun * 35;
            flowLayoutPanel1.Height = satir * 35;
            this.Width = flowLayoutPanel1.Width + 50;
            this.Height = flowLayoutPanel1.Height + 80;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            if ((bool)tiklanan.Tag)
            {
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    Button btn = item as Button;
                    if ((bool)btn.Tag)
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.Green;
                }
                MessageBox.Show("Oyun Bitti.Yeni Oyun Başlatın!..");
                flowLayoutPanel1.Controls.Clear();
            }
            else
            {
                tiklanan.BackColor = Color.Gray;
            }
        }
    }
}
