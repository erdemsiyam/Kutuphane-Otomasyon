using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneApp
{
    public partial class Giris : Form
    {
        KutuphaneDataContext ctx;
        public Giris()
        {
            InitializeComponent();
            ctx = new KutuphaneDataContext();
        }
        private void Giris_Load(object sender, EventArgs e)
        {

        }
        private void btnGiris_Click(object sender, EventArgs e)
        {

            Rol r = new Rol();
            r = ctx.Rols.FirstOrDefault(x => x.Adi == "Admin");


            Uye uye = ctx.Uyes.FirstOrDefault(x => x.Email == txtAd.Text.ToString() && x.Sifre == txtSifre.Text.ToString() && x.Rol.ID == r.ID);
            
            if (uye != null)
            {
                new Menu(uye).Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hata.");
                txtSifre.Text = "";
            }

        }
    }
}
