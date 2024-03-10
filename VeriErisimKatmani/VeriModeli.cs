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

    }
}
