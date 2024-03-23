using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
