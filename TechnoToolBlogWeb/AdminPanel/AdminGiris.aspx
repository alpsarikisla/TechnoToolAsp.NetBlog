<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="TechnoToolBlogWeb.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tekno Tool Blog Admin Panel</title>
    <link href="assets/css/girisStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="baslik">
                <h3>Admin Panel Giriş</h3>
            </div>
            <div class="icerik">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                   <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <label class="formetiket">Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="metinkutu" placeholder="Kullanıcı Adınız" Text="AlpHodja"></asp:TextBox>
                </div>
                <div class="satir">
                    <label class="formetiket">Şifre</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" placeholder="Şifreniz" Text="1234"></asp:TextBox>
                </div>
                <div class="satir">
                    <div class="sus"></div>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" CssClass="girisbutton" OnClick="btn_giris_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
