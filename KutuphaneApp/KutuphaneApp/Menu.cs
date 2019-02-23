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
    public partial class Menu : Form
    {
        Uye giris_yapan_uye;

        KutuphaneDataContext ctx;
        public Menu(Uye uye)
        {
            giris_yapan_uye = uye;
            InitializeComponent();
            ctx = new KutuphaneDataContext();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if(giris_yapan_uye != null)
                Text = "Kütüphane - İşlem Menüsü  -  Kullanici : " + giris_yapan_uye.AdSoyad;
            cagir_dgwKitapTipi();
            cagir_dgwYayinEvi();
            cagir_dgwTur();
            cagir_dgwYazar();
            cagir_dgwKitapTurleri_Kitaplar();
            cagir_dgwKitapIslem_Kitap();
            cagir_dgwUyeler_Uye();
            ofdKitapResim.Title = "Resim Seç";
            ofdKitapResim.Filter = "Resim Dosyası |*.jpg;*.png";
        }

        /////////////////////////////////////////////////////////////////////////////// KİTAP TİPİ  ( CİLDİ )
        private void btnKitapTipiEkle_Click(object sender, EventArgs e)
        {
            Tip t = new Tip();
            t.ID = Guid.NewGuid();
            t.Adi = txtKitapTipi.Text.ToString();
            ctx.Tips.InsertOnSubmit(t);
            ctx.SubmitChanges();

            cagir_dgwKitapTipi();
        }


        private void dgwKitapTipi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwKitapTipi.CurrentRow;
            txtKitapTipi.Text =  row.Cells["Adi"].Value.ToString();
            txtKitapTipi.Tag = row.Cells["ID"].Value;
        }

        private void btnKitapTipiDuzenle_Click(object sender, EventArgs e)
        {
            if (txtKitapTipi.Tag != null)
            {
                Tip t = ctx.Tips.FirstOrDefault(x => x.ID == (Guid)txtKitapTipi.Tag);
                t.Adi = txtKitapTipi.Text.ToString();
                ctx.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Seçiniz.");
            }
            txtKitapTipi.Text = "";
            txtKitapTipi.Tag = null;

            cagir_dgwKitapTipi();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid) dgwKitapTipi.CurrentRow.Cells["ID"].Value;
                Tip t = ctx.Tips.FirstOrDefault(x => x.ID == id);
                if (ctx.Kitaps.Where(x => x.TipID == id).Count() > 0)
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Kayıta bağlı Kitap bulunmakta.");
                    return;
                }
                ctx.Tips.DeleteOnSubmit(t);
                ctx.SubmitChanges();
                cagir_dgwKitapTipi();
            }
        }

        public void cagir_dgwKitapTipi()
        {
            dgwKitapTipi.DataSource = ctx.Tips.ToList();
            dgwKitapTipi.Columns["ID"].Visible = false;
            cmbKitapIslem_Tip.DataSource = ctx.Tips.ToList();
            cmbKitapIslem_Tip.DisplayMember = "Adi";
            cmbKitapIslem_Tip.ValueMember = "ID";

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////// YAYIN EVİ
        private void btnYayinEviEkle_Click(object sender, EventArgs e)
        {
            YayinEvi y = new YayinEvi();
            y.ID = Guid.NewGuid();
            y.Adi = txtYayinEviAdi.Text.ToString();
            ctx.YayinEvis.InsertOnSubmit(y);
            ctx.SubmitChanges();

            cagir_dgwYayinEvi();
        }

        private void btnYayinEviGuncelle_Click(object sender, EventArgs e)
        {
            if (txtYayinEviAdi.Tag != null)
            {
                YayinEvi y = ctx.YayinEvis.FirstOrDefault(x => x.ID == (Guid)txtYayinEviAdi.Tag);
                y.Adi = txtYayinEviAdi.Text.ToString();
                ctx.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Seçiniz.");
            }
            txtYayinEviAdi.Text = "";
            txtYayinEviAdi.Tag = null;

            cagir_dgwYayinEvi();
        }
       

        private void dgwYayinEvi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwYayinEvi.CurrentRow;
            txtYayinEviAdi.Text = row.Cells["Adi"].Value.ToString();
            txtYayinEviAdi.Tag = row.Cells["ID"].Value;
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwYayinEvi.CurrentRow.Cells["ID"].Value;
                YayinEvi y = ctx.YayinEvis.FirstOrDefault(x => x.ID == id);
                if (ctx.Kitaps.Where(x => x.YayinEviID == id).Count() > 0)
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Kayıta bağlı Kitap bulunmakta.");
                    return;
                }
                ctx.YayinEvis.DeleteOnSubmit(y);
                ctx.SubmitChanges();
                cagir_dgwYayinEvi();
            }
        }
        public void cagir_dgwYayinEvi()
        {
            dgwYayinEvi.DataSource = ctx.YayinEvis.ToList();
            dgwYayinEvi.Columns["ID"].Visible = false;

            cmbKayitIslem_YayinEvi.DataSource = ctx.YayinEvis.ToList();
            cmbKayitIslem_YayinEvi.DisplayMember = "Adi";
            cmbKayitIslem_YayinEvi.ValueMember = "ID";
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////// KİTAP TÜRÜ

        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            Tur t = new Tur();
            t.ID = Guid.NewGuid();
            t.Adi = txtTurAdi.Text.ToString();
            ctx.Turs.InsertOnSubmit(t);
            ctx.SubmitChanges();

            cagir_dgwTur();
        }


        private void btnTurGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTurAdi.Tag != null)
            {
                Tur t = ctx.Turs.FirstOrDefault(x => x.ID == (Guid)txtTurAdi.Tag);
                t.Adi = txtTurAdi.Text.ToString();
                ctx.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Seçiniz.");
            }
            txtTurAdi.Text = "";
            txtTurAdi.Tag = null;

            cagir_dgwTur();
        }

        private void silToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwTur.CurrentRow.Cells["ID"].Value;
                Tur t = ctx.Turs.FirstOrDefault(x => x.ID == id);
                if (ctx.KitapTurus.Where(x => x.TurID == id).Count() > 0)
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Kayıta bağlı Kitap bulunmakta.");
                    return;
                }
                ctx.Turs.DeleteOnSubmit(t);
                ctx.SubmitChanges();
                cagir_dgwTur();
            }
        }

        private void dgwTur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwTur.CurrentRow;
            txtTurAdi.Text = row.Cells["Adi"].Value.ToString();
            txtTurAdi.Tag = row.Cells["ID"].Value;
        }
        public void cagir_dgwTur()
        {
            dgwTur.DataSource = ctx.Turs.ToList();
            dgwTur.Columns["ID"].Visible = false;

            cagir_cmbKitapTurleri_Turler();
        }

        /////////////////////////////////////////////////////////////////////////////// YAZAR


        private void silToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwYazar.CurrentRow.Cells["ID"].Value;
                Yazar y = ctx.Yazars.FirstOrDefault(x => x.ID == id);
                if (ctx.Kitaps.Where(x => x.YazarID == id).Count() > 0)
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Kayıta bağlı Kitap bulunmakta.");
                    return;
                }
                ctx.Yazars.DeleteOnSubmit(y);
                ctx.SubmitChanges();
                cagir_dgwYazar();
            }
        }
        private void btnYazarEkle_Click(object sender, EventArgs e)
        {
            Yazar y = new Yazar();
            y.ID = Guid.NewGuid();
            y.Adi = txtYazarAdi.Text.ToString();
            ctx.Yazars.InsertOnSubmit(y);
            ctx.SubmitChanges();

            cagir_dgwYazar();
        }

        public void cagir_dgwYazar()
        {
            dgwYazar.DataSource = ctx.Yazars.ToList();
            dgwYazar.Columns["ID"].Visible = false;
            cmbKitapIslem_Yazar.DataSource = ctx.Yazars.ToList();
            cmbKitapIslem_Yazar.DisplayMember = "Adi";
            cmbKitapIslem_Yazar.ValueMember = "ID";
            
        }

        private void btnYazarGuncelle_Click(object sender, EventArgs e)
        {
            if (txtYazarAdi.Tag != null)
            {
                Yazar y = ctx.Yazars.FirstOrDefault(x => x.ID == (Guid)txtYazarAdi.Tag);
                y.Adi = txtYazarAdi.Text.ToString();
                ctx.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Seçiniz.");
            }
            txtYazarAdi.Text = "";
            txtYazarAdi.Tag = null;

            cagir_dgwYazar();
        }

        private void dgwYazar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwYazar.CurrentRow;
            txtYazarAdi.Text = row.Cells["Adi"].Value.ToString();
            txtYazarAdi.Tag = row.Cells["ID"].Value;
        }
       

        ////////////////////////////////////////////////////////////////////////////////////////////// Kitap Islemleri : Ekle / Sil / Düzenle


        private void btnKitapIslem_KitapEkle_Click(object sender, EventArgs e)
        {
            if (btnKitapIslem_ResimSec.Tag == null)
            {
                MessageBox.Show("Resim Seç");
                return;
            }
            ///////////////Resim Ekleme İşlemi

            Image img = Image.FromFile((string)btnKitapIslem_ResimSec.Tag);
            Bitmap bm = new Bitmap(img, img.Width, img.Height); 

            string uzanti = AppDomain.CurrentDomain.BaseDirectory;
            uzanti = uzanti.Remove(uzanti.Length - 36, 36);
            uzanti += "KutuphaneWeb\\KutuphaneWeb\\Content\\images\\";
            Guid yeni_id = Guid.NewGuid();
            string resimAdi = yeni_id.ToString() + Path.GetExtension(ofdKitapResim.FileName);
            bm.Save(uzanti + resimAdi);

            /////////////// Kitap Ekleme İşlemi

            Kitap k = new Kitap();
            k.ID = Guid.NewGuid();
            k.Adi = txtKitapIslem_Ad.Text.ToString();
            k.SayfaSayisi = (int)nudKitapIslem_SayfaSayisi.Value;
            k.YazarID = (Guid)cmbKitapIslem_Yazar.SelectedValue;
            k.TipID = (Guid)cmbKitapIslem_Tip.SelectedValue;
            k.ISBN = txtKitapIslem_Isbn.Text.ToString();
            k.AlimTarihi = Convert.ToDateTime(txtKitapIslem_AlimTarihi.Text.ToString());
            k.BasimTarihi = Convert.ToDateTime(txtKitapIslem_BasimTarihi.Text.ToString());
            k.Fiyati = (decimal)nudKitapIslem_Fiyat.Value;
            k.ResimURL = resimAdi;
            k.YayinEviID = (Guid)cmbKayitIslem_YayinEvi.SelectedValue;
            k.Dili = txtKayitIslem_Dil.Text.ToString();
            k.Aktif = true;
            k.OkunmaSayisi = 0;

            ctx.Kitaps.InsertOnSubmit(k);
            ctx.SubmitChanges();

            cagir_dgwKitapIslem_Kitap();
            cagir_dgwKitapTurleri_Kitaplar();
            btnKitapIslem_ResimSec.Tag = null;
        }

        private void btnKitapIslem_KitapGuncelle_Click(object sender, EventArgs e)
        {
            
            ///////////////Kitap Düzenleme İşlemi
            Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == (Guid)txtKitapIslem_Ad.Tag);
            k.Adi = txtKitapIslem_Ad.Text.ToString();
            k.SayfaSayisi = (int)nudKitapIslem_SayfaSayisi.Value;
            k.YazarID = (Guid)cmbKitapIslem_Yazar.SelectedValue;
            k.TipID = (Guid)cmbKitapIslem_Tip.SelectedValue;
            k.ISBN = txtKitapIslem_Isbn.Text.ToString();
            k.AlimTarihi = Convert.ToDateTime(txtKitapIslem_AlimTarihi.Text.ToString());
            k.BasimTarihi = Convert.ToDateTime(txtKitapIslem_BasimTarihi.Text.ToString());
            k.Fiyati = (decimal)nudKitapIslem_Fiyat.Value;
            k.YayinEviID = (Guid)cmbKayitIslem_YayinEvi.SelectedValue;
            k.Dili = txtKayitIslem_Dil.Text.ToString();

            ///////////////Resim Ekleme İşlemi

            if (chbKitapIslem_ResimGuncellensinMi.Checked)
            { 
                Image img = Image.FromFile((string)btnKitapIslem_ResimSec.Tag);
                if (img != null)
                {
                    string uzanti = AppDomain.CurrentDomain.BaseDirectory;
                    uzanti = uzanti.Remove(uzanti.Length - 36, 36);
                    uzanti += "KutuphaneWeb\\KutuphaneWeb\\Content\\images\\";

                    ///// Eski resimi Sileriz
                    if (k.ResimURL != null)
                    {
                        if (File.Exists(uzanti+k.ResimURL))
                        {
                            File.Delete(uzanti + k.ResimURL);
                        }
                    }
                    ///// Yeni Resim İşlemleri
                    Bitmap bm = new Bitmap(img,img.Width,img.Height ); 
                    
                    Guid yeni_id = Guid.NewGuid();
                    string resimAdi = yeni_id.ToString() + Path.GetExtension(ofdKitapResim.FileName);
                    bm.Save(uzanti + resimAdi);
                    k.ResimURL = resimAdi;
                }
            }
            //////////////////////////////////////////////

            ctx.SubmitChanges();
            cagir_dgwKitapIslem_Kitap();
        }

        public void cagir_dgwKitapIslem_Kitap()
        {
            dgwKitapIslem_Kitap.DataSource = ctx.Kitaps.Select(
                x=> new {
                       ID = x.ID,
                       Adi = x.Adi,
                       SayfaSayisi = x.SayfaSayisi,
                       Yazar = x.Yazar.Adi,
                       YayinEvi = x.YayinEvi.Adi,
                       CiltTipi = x.Tip.Adi,
                       Dili = x.Dili,
                       ISBN = x.ISBN,
                       OkunmaSayisi = x.OkunmaSayisi,
                       MevcutMu = x.Aktif,
                       AlimTarihi = x.AlimTarihi,
                       BasimTarihi = x.BasimTarihi,
                       Fiyati = x.Fiyati,
                       ResimUrl = x.ResimURL
                }
                ).ToList();

            dgwKitapIslem_Kitap.Columns["ID"].Visible = false;
        }

        private void dgwKitapIslem_Kitap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwKitapIslem_Kitap.CurrentRow;
            Guid id = (Guid)row.Cells["ID"].Value;

            Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == id);
            txtKitapIslem_Ad.Tag = id;
            txtKitapIslem_Ad.Text = k.Adi;
            nudKitapIslem_SayfaSayisi.Value = k.SayfaSayisi;
            cmbKitapIslem_Yazar.SelectedValue = k.YazarID;
            cmbKitapIslem_Tip.SelectedValue = k.TipID;
            txtKitapIslem_Isbn.Text = k.ISBN;
            txtKitapIslem_AlimTarihi.Text = k.AlimTarihi.ToString("yyyy-MM-dd");
            txtKitapIslem_BasimTarihi.Text = k.BasimTarihi.ToString("yyyy-MM-dd");
            nudKitapIslem_Fiyat.Value = k.Fiyati;
            cmbKayitIslem_YayinEvi.SelectedValue = k.YayinEviID;
            txtKayitIslem_Dil.Text = k.Dili;
        }
        private void btnKitapIslem_ResimSec_Click(object sender, EventArgs e)
        {
            if (ofdKitapResim.ShowDialog() == DialogResult.OK)
            {
                btnKitapIslem_ResimSec.Tag = ofdKitapResim.FileName; // bu butonun tagına seçilen resmin konumunu atarız
                
            }
        }

        private void seçiliKitabıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kitap Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwKitapIslem_Kitap.CurrentRow.Cells["ID"].Value;
                if (ctx.OduncKitaps.Where(x => x.KitapID == id).Count() > 0) // DEĞİŞTİR : o tarih te alan varsa hata verdir , yada kitap tablosuna eklenirse alındı alınmadı diye sütun öyle değiştir
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Kitaba bağlı Ödenç Alınma işlemi bulunmakta.");
                    return;
                }
                Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == id);
                ctx.Kitaps.DeleteOnSubmit(k);
                ctx.SubmitChanges();
                cagir_dgwKitapIslem_Kitap();
            }
        }
        private void seçiliKitabıKimAldıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guid id = (Guid)dgwKitapIslem_Kitap.CurrentRow.Cells["ID"].Value;
            OduncKitap ok = ctx.OduncKitaps.Where(x => x.KitapID == id && x.GeriAlindiMi==false).OrderByDescending(x => x.BaslangicTarih).FirstOrDefault();
            if (ok != null)
            {
                if (ok.BitisTarih >= DateTime.Now)
                {
                    MessageBox.Show(ok.Uye.AdSoyad + " tarafından \n" + ok.BaslangicTarih + " tarihinde alındı \n" + ok.BitisTarih + " tarihinde bitecektir. \n" + ((int)(ok.BitisTarih - DateTime.Now).TotalDays).ToString() + " gün sonra bitiyor");
                }
                else
                {
                    MessageBox.Show(ok.Uye.AdSoyad + " tarafından \n" + ok.BaslangicTarih + " tarihinde alındı \n" + ok.BitisTarih + " tarihinde BİTTİ ! \n" + ((int)(DateTime.Now - ok.BitisTarih).TotalDays).ToString() + " gündür kitap izinsiz kitap onda.");
                }

            }
            else {
                MessageBox.Show("Bilgi Bulunamadı");
            }
        }
        ///////////////////////////////////////////////////////////////////////////////  KİTABA TÜR EKLEME/SİLME

        public void cagir_dgwKitapTurleri_Kitaplar()
        {
            /*
            dgwKitapTurleri_Kitaplar.DataSource = ctx.Kitaps.Join(
                ctx.Yazars,
                k=> k.YazarID,
                y=>y.ID,
                (a, b) => new { a,b}

                ).Join(

                ctx.YayinEvis,
                c=>c.a.YayinEviID,
                d=>d.ID,
                (c,d) => new { c,d }

                ).Join(
                
                ctx.Tips,
                e=>e.c.a.TipID,
                f=>f.ID,
                (e,f) => new { e,f }

                ).Select(
                    x=> new {

                        ID = x.e.c.a.ID,
                        KitapAdi = x.e.c.a.Adi,
                        YazarAdi = x.e.c.b.Adi,
                        YayinEvi = x.e.d.Adi,
                        Tip = x.f.Adi
                    }
                ).ToList();
            */

            dgwKitapTurleri_Kitaplar.DataSource = ctx.Kitaps.Select(
                x => new
                {
                    ID = x.ID,
                    Adi = x.Adi,
                    YazarAdi = x.Yazar.Adi,
                    YayinEviAdi = x.YayinEvi.Adi,
                    Cildi = x.Tip.Adi
                }).ToList();

            dgwKitapTurleri_Kitaplar.Columns["ID"].Visible = false;
        }
        public void cagir_dgwKitapTurleri_Turler(Guid id)
        {
            dgwKitapTurleri_Turler.DataSource = ctx.KitapTurus.Where(x => x.KitapID == id).Select(
                x => new {
                    ID = x.ID,
                    Tur = x.Tur.Adi
                }
                ).ToList();

            dgwKitapTurleri_Turler.Columns["ID"].Visible = false;

        }
        public void cagir_cmbKitapTurleri_Turler()
        {
            cmbKitapTurleri_Turler.DataSource = ctx.Turs.ToList();
            cmbKitapTurleri_Turler.DisplayMember = "Adi";
            cmbKitapTurleri_Turler.ValueMember = "ID";
        }


        private void buTürüKitaptanSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwKitapTurleri_Turler.CurrentRow.Cells["ID"].Value;
                KitapTuru kt = ctx.KitapTurus.FirstOrDefault(x => x.ID == id);
                ctx.KitapTurus.DeleteOnSubmit(kt);
                ctx.SubmitChanges();
                cagir_dgwKitapTurleri_Turler((Guid)cmbKitapTurleri_Turler.Tag);
            }
        }
        private void dgwKitapTurleri_Kitaplar_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwKitapTurleri_Kitaplar.CurrentRow;
            cmbKitapTurleri_Turler.Tag = row.Cells["ID"].Value;
            cagir_dgwKitapTurleri_Turler((Guid)row.Cells["ID"].Value);
        }

        private void btnKitapTurleri_KitabaTurEkle_Click_1(object sender, EventArgs e)
        {
            Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == (Guid)cmbKitapTurleri_Turler.Tag);
            Tur t = ctx.Turs.FirstOrDefault(x => x.ID == (Guid)cmbKitapTurleri_Turler.SelectedValue);
            if (k != null && t != null)
            {
                KitapTuru kt = ctx.KitapTurus.FirstOrDefault(x => x.KitapID == k.ID && x.TurID == t.ID);
                if (kt == null)
                {
                    kt = new KitapTuru();
                    kt.ID = Guid.NewGuid();
                    kt.KitapID = k.ID;
                    kt.TurID = t.ID;
                    ctx.KitapTurus.InsertOnSubmit(kt);
                    ctx.SubmitChanges();
                }
            }
            cagir_dgwKitapTurleri_Turler(k.ID);
        }

        private void txtKitapTurleri_KitapAra_TextChanged_1(object sender, EventArgs e)
        {
            dgwKitapTurleri_Kitaplar.DataSource = ctx.Kitaps.Where(x => x.Adi.Contains(txtKitapTurleri_KitapAra.Text.ToString())).Select(
                x => new
                {
                    ID = x.ID,
                    Adi = x.Adi,
                    YazarAdi = x.Yazar.Adi,
                    YayinEviAdi = x.YayinEvi.Adi,
                    Cildi = x.Tip.Adi
                }).ToList();

            dgwKitapTurleri_Kitaplar.Columns["ID"].Visible = false;
        }


        /////////////////////////////////////////////////////////////////////////////// 

        public void cagir_dgwUyeler_Uye()
        {
            dgwUyeler_Uye.DataSource = ctx.Uyes.Select(
                    x => new
                    {
                        ID = x.ID,
                        Email = x.Email,
                        AdSoyad = x.AdSoyad,
                        DogumYili = x.DogumYili,
                        Sifre = x.Sifre,
                        Rol = x.Rol.Adi
                    }
                ).ToList();
            dgwUyeler_Uye.Columns["ID"].Visible = false;

            cmbUyeler_Rolu.DataSource = ctx.Rols.ToList();
            cmbUyeler_Rolu.DisplayMember = "Adi";
            cmbUyeler_Rolu.ValueMember = "ID";
        }

        private void dgwUyeler_Uye_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwUyeler_Uye.CurrentRow;

            Uye u = ctx.Uyes.FirstOrDefault(x => x.ID == (Guid)row.Cells["ID"].Value);

            txtUyeler_eMail.Tag = u.ID;

            txtUyeler_eMail.Text = u.Email;
            txtUyeler_AdiSoyadi.Text = u.AdSoyad;
            nudUyeler_DogumYili.Value= u.DogumYili;
            cmbUyeler_Rolu.SelectedValue = u.RolID;
            txtUyeler_Sifre.Text = u.Sifre;

        }

        private void btnUyeler_UyeEkle_Click(object sender, EventArgs e)
        {
            if (txtUyeler_Sifre.Text == "")
            {
                MessageBox.Show("Şifre Belirlenmeli");
                return;
            }
            Uye u = new Uye();
            u.ID = Guid.NewGuid();
            u.Email = txtUyeler_eMail.Text;
            u.AdSoyad = txtUyeler_AdiSoyadi.Text;
            u.DogumYili = (int)nudUyeler_DogumYili.Value;
            u.RolID = (Guid)cmbUyeler_Rolu.SelectedValue;
            u.Sifre = txtUyeler_Sifre.Text;

            ctx.Uyes.InsertOnSubmit(u);
            ctx.SubmitChanges();

            cagir_dgwUyeler_Uye();
        }

        private void btnUyeler_UyeGuncelle_Click(object sender, EventArgs e)
        {
            Uye u = ctx.Uyes.FirstOrDefault(x => x.ID == (Guid)txtUyeler_eMail.Tag);
            if (u != null)
            {
                u.Email = txtUyeler_eMail.Text;
                u.AdSoyad = txtUyeler_AdiSoyadi.Text;
                u.DogumYili = (int)nudUyeler_DogumYili.Value;
                u.RolID = (Guid)cmbUyeler_Rolu.SelectedValue;
                u.Sifre = txtUyeler_Sifre.Text;

                ctx.SubmitChanges();
            }

            cagir_dgwUyeler_Uye();
        }

        private void txtUyeler_AdiSoyadi_TextChanged(object sender, EventArgs e)
        {
            if (nudUyeler_DogumYili.Value.ToString().Length == 4 && txtUyeler_AdiSoyadi.Text.Length > 0)
            {
                txtUyeler_Sifre.Text = txtUyeler_AdiSoyadi.Text.Replace(" ", "").ToLower() + nudUyeler_DogumYili.Value.ToString();
            }
        }

        private void nudUyeler_DogumYili_ValueChanged(object sender, EventArgs e)
        {
            if (nudUyeler_DogumYili.Value.ToString().Length == 4 && txtUyeler_AdiSoyadi.Text.Length > 0 )
            {
                txtUyeler_Sifre.Text = txtUyeler_AdiSoyadi.Text.Replace(" ", "").ToLower() + nudUyeler_DogumYili.Value.ToString();
            }
        }

        private void seçiliÜyeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Guid id = (Guid)dgwUyeler_Uye.CurrentRow.Cells["ID"].Value;
                if (ctx.OduncKitaps.Where(x => x.UyeID == id).Count() > 0)// DEĞİŞTİR : o tarih te alan varsa hata verdir , yada kitap tablosuna eklenirse alındı alınmadı diye sütun öyle değiştir
                {
                    MessageBox.Show("Hata : Silinmeye Çalışılan Üyeye bağlı Ödünç kitap alımı bulunmakta.");
                    return;
                }
                Uye u= ctx.Uyes.FirstOrDefault(x => x.ID == id);
                ctx.Uyes.DeleteOnSubmit(u);
                ctx.SubmitChanges();
            }
            cagir_dgwUyeler_Uye();
        }
        ///////////////////////////////////////////////////////////// Üyeye Kitap Verimi
        private void txtUyeKitapVer_UyeAra_TextChanged(object sender, EventArgs e)
        {
            cmbUyeKitapVer_UyeSec.DataSource = ctx.Uyes.Where(x => x.AdSoyad.Contains(txtUyeKitapVer_UyeAra.Text)).ToList();
            cmbUyeKitapVer_UyeSec.DisplayMember = "Email";
            cmbUyeKitapVer_UyeSec.ValueMember = "ID";

        }

        private void txtUyeKitapVer_KitapAra_TextChanged(object sender, EventArgs e)
        {
            // arama sonucunda , Verilmeye AKtif olan kitaplar getirilir
            cmbUyeKitapVer_KitapSec.DataSource = ctx.Kitaps.Where(x => x.Adi.Contains(txtUyeKitapVer_KitapAra.Text) && x.Aktif==true).ToList();
            cmbUyeKitapVer_KitapSec.DisplayMember = "Adi";
            cmbUyeKitapVer_KitapSec.ValueMember = "ID";
        }

        private void btnUyeKitapVer_Click(object sender, EventArgs e)
        {

            Uye u = ctx.Uyes.FirstOrDefault(x => x.ID == (Guid)cmbUyeKitapVer_UyeSec.SelectedValue);
            Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == (Guid)cmbUyeKitapVer_KitapSec.SelectedValue);

            if (u != null && k != null)
            {
                if (dgwUyeKacirdigiKitap.RowCount > 0)
                {
                    DialogResult sonuc = MessageBox.Show("Üyenin Geri Getirmediği Kitap Var yine de bu kitap ona verilsin mi? Vermek İçin evet Vermemek için hayır tıkla", "HIRSIZ ÜYE UYARISI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.No)
                    {
                        return;
                    }
                }
                if (mcUyeKitapVer_AlimTarihi.SelectionRange.Start.Date <= DateTime.Now)
                {
                    MessageBox.Show("ileri bir tarih seçiniz");
                    return;
                }
                if (mcUyeKitapVer_AlimTarihi.SelectionRange.Start.Date > DateTime.Now.AddDays(30))
                {
                    MessageBox.Show("30 günden fazla kitap ödünç verilemez");
                    return;
                }
                OduncKitap ok = new OduncKitap();
                ok.ID = Guid.NewGuid();
                ok.UyeID = u.ID;
                ok.KitapID = k.ID;
                ok.BaslangicTarih = DateTime.Now;
                ok.BitisTarih = mcUyeKitapVer_AlimTarihi.SelectionRange.Start.Date;
                ok.GeriAlindiMi = false;

                ctx.OduncKitaps.InsertOnSubmit(ok);
                k.Aktif = false;
                k.OkunmaSayisi += 1;
                ctx.SubmitChanges();

                cmbUyeKitapVer_UyeSec_SelectedValueChanged(sender, e);
                cagir_dgwKitapIslem_Kitap();
            }
            else
            {
                MessageBox.Show("Veri Seçiniz");
            }
        }

        private void cmbUyeKitapVer_UyeSec_SelectedValueChanged(object sender, EventArgs e)
        {
            // her farklı üye seçiminde üyenin aldığı/ okudğu / el koyduğu kitaplar datagrid de göstertilir.
            Guid id;
            try
            { id = (Guid)cmbUyeKitapVer_UyeSec.SelectedValue; }
            catch (InvalidCastException)
            { return; }
            
            //aldigi tum kitaplar
            dgwUyeGeriVerdigiKitap.DataSource = ctx.OduncKitaps.Where(x => x.UyeID == id && x.GeriAlindiMi == true && x.BitisTarih < DateTime.Now).Select(
                    x => new
                    {
                        KitapAdi = x.Kitap.Adi,
                        BaslangicTarihi = x.BaslangicTarih,
                        BitisTarihi = x.BitisTarih,
                        GeriVerisTarihi = x.GeriAlinmaTarihi,
                    }
                ).ToList();

            //select * from OduncKitap where (BitisTarih<GETDATE() AND GeriAlindiMi = 0 AND UyeID='f124b901-d59c-463c-915d-71d402763271')
            dgwUyeVermedigiKitap.DataSource = ctx.OduncKitaps.Where(x => x.BitisTarih >= DateTime.Now && x.GeriAlindiMi == false && x.UyeID == id).Select(
                    x => new
                    {
                        KitapAdi = x.Kitap.Adi,
                        BaslangicTarihi = x.BaslangicTarih,
                        BitisTarihi = x.BitisTarih,
                        TeslimAlindi = x.GeriAlindiMi
                    }
                ).ToList();

            dgwUyeKacirdigiKitap.DataSource = ctx.OduncKitaps.Where(x => x.BitisTarih < DateTime.Now && x.GeriAlindiMi == false && x.UyeID == id).Select(
                    x => new
                    {
                        KitapAdi = x.Kitap.Adi,
                        BaslangicTarihi = x.BaslangicTarih,
                        BitisTarihi = x.BitisTarih,
                        TeslimAlindi = x.GeriAlindiMi
                    }
                ).ToList();
        }

        ////////////////////////////////////////////////////////////////// Üyeden Kitabı Geri Alma

        private void txtUyeKitapAl_UyeAra_TextChanged(object sender, EventArgs e)
        {
            cmbUyeKitapAl_UyeSec.DataSource = ctx.Uyes.Where(x => x.AdSoyad.Contains(txtUyeKitapAl_UyeAra.Text)).ToList();
            cmbUyeKitapAl_UyeSec.DisplayMember = "Email";
            cmbUyeKitapAl_UyeSec.ValueMember = "ID";
        }

        private void cmbUyeKitapAl_UyeSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            // her farklı üye seçiminde üyenin aldığı/ okudğu / el koyduğu kitaplar datagrid de göstertilir.
            Guid id;
            try
            { id = (Guid)cmbUyeKitapAl_UyeSec.SelectedValue; }
            catch (InvalidCastException)
            { return; }

            dgwUyeKitapAl_OndakiKitaplar.DataSource = ctx.OduncKitaps.Where(x => x.UyeID == id && x.GeriAlindiMi == false).Select(
                x => new
                {
                    ID = x.ID,
                    KitapAdi = x.Kitap.Adi,
                    BaslangicTarihi = x.BaslangicTarih,
                    BitisTarihi = x.BitisTarih,
                    TeslimAlindi = x.GeriAlindiMi
                }
            ).ToList();
            dgwUyeKitapAl_OndakiKitaplar.Columns["ID"].Visible = false;
            btnUyeKitapAl_KitapGeriAl.Tag = null;
        }

        private void dgwUyeKitapAl_OndakiKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgwUyeKitapAl_OndakiKitaplar.CurrentRow;
            btnUyeKitapAl_KitapGeriAl.Tag = row.Cells["ID"].Value;
        }

        private void btnUyeKitapAl_KitapGeriAl_Click(object sender, EventArgs e)
        {
            if (btnUyeKitapAl_KitapGeriAl.Tag != null)
            {
                OduncKitap ok = ctx.OduncKitaps.FirstOrDefault(x => x.ID == (Guid)btnUyeKitapAl_KitapGeriAl.Tag);
                ok.GeriAlindiMi = true;
                ok.GeriAlinmaTarihi = DateTime.Now;
                Kitap k = ctx.Kitaps.FirstOrDefault(x => x.ID == ok.KitapID);
                k.Aktif = true;

                ctx.SubmitChanges();
                cmbUyeKitapAl_UyeSec_SelectedIndexChanged(sender, e);
                cagir_dgwKitapIslem_Kitap();
            }

        }

        
    }
}
