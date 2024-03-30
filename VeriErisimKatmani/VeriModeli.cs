using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModeli
    {
        SqlConnection baglanti; SqlCommand komut;
        public VeriModeli()
        {
            baglanti = new SqlConnection(BaglantiYollari.AnaBaglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                Yonetici y = new Yonetici();
                komut.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim,Y.KullaniciAdi,Y.Email, Y.Sifre, Y.Durum FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.KullaniciAdi = @kadi AND Y.Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    y.ID = okuyucu.GetInt32(0);
                    y.YoneticiTur_ID = okuyucu.GetInt32(1);
                    y.YoneticiTur = okuyucu.GetString(2);
                    y.Isim = okuyucu.GetString(3);
                    y.Soyisim = okuyucu.GetString(4);
                    y.KullaniciAdi = okuyucu.GetString(5);
                    y.Email = okuyucu.GetString(6);
                    y.Sifre = okuyucu.GetString(7);
                    y.Durum = okuyucu.GetBoolean(8);
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama, Durum) VALUES(@isim,@aciklama,@durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.Isim);
                komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Kategori> TumKategorileriGetir()
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Kategori> TumKategorileriGetir(bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE Durum=@d";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@d", durum);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Kategori kat = new Kategori();
                while (okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Isim=@isim, Aciklama=@aciklama, Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", kat.ID);
                komut.Parameters.AddWithValue("@isim", kat.Isim);
                komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());

                komut.CommandText = "UPDATE Kategoriler SET Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                komut.CommandText = "INSERT INTO Makaleler(Kategori_ID, Yazar_ID, Baslik, Ozet,Icerik,KapakResim,Tarih,GoruntulemeSayi,Durum) VALUES(@kategori_ID, @yazar_ID, @baslik, @ozet, @icerik, @kapakResim, @tarih, @goruntulemeSayi, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kategori_ID" , mak.Kategori_ID);
                komut.Parameters.AddWithValue("@yazar_ID", mak.Yazar_ID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                komut.Parameters.AddWithValue("@tarih", mak.Tarih);
                komut.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                komut.Parameters.AddWithValue("@durum", mak.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.Tarih, M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.Kategori_ID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.Yazar_ID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.Tarih = okuyucu.GetDateTime(9);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    mak.GoruntulemeSayi = okuyucu.GetInt32(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Makale> MakaleListele(bool durum)
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.Tarih, M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID WHERE M.Durum =@d";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@d", durum);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.Kategori_ID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.Yazar_ID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.Tarih = okuyucu.GetDateTime(9);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    mak.GoruntulemeSayi = okuyucu.GetInt32(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Makale> MakaleListele(int KategoriID)
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.Tarih, M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID WHERE M.Durum=1 AND M.Kategori_ID=@kid";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kid", KategoriID);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.Kategori_ID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.Yazar_ID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.Tarih = okuyucu.GetDateTime(9);
                    mak.TarihStr = mak.Tarih.ToShortDateString();
                    mak.GoruntulemeSayi = okuyucu.GetInt32(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.Tarih, M.GoruntulemeSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID WHERE M.ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Makale mak = new Makale();
                while (okuyucu.Read())
                {
                    mak.ID = okuyucu.GetInt32(0);
                    mak.Kategori_ID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.Yazar_ID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.Tarih = okuyucu.GetDateTime(9);
                    mak.GoruntulemeSayi = okuyucu.GetInt32(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool MakaleDuzenle(Makale mak)
        {
            try
            {
                komut.CommandText = "UPDATE Makaleler SET Kategori_ID=@kategori_ID,  Baslik=@baslik, Ozet=@ozet,Icerik=@icerik, KapakResim=@kapakresim,Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", mak.ID);
                komut.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                komut.Parameters.AddWithValue("@durum", mak.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Üye Metotları

        public Uye UyeGiris(string email, string sifre)
        {
            try
            {
                Uye u = new Uye();
                komut.CommandText = "SELECT * FROM Uyeler WHERE Email = @e AND Sifre = @s";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@e", email);
                komut.Parameters.AddWithValue("@s", sifre);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Email = okuyucu.GetString(4);
                    u.Sifre = okuyucu.GetString(5);
                    u.UyelikTarihi = okuyucu.GetDateTime(6);
                    u.Durum = okuyucu.GetBoolean(7);
                }
                return u;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
    }
}
