<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="TechnoToolBlogWeb.UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="girisKutu">
        <div class="baslik">
            <h2>Techo Blog'a Hoş Geldiniz</h2>
            <h3>Üye Girişi</h3>
        </div>
        <div class="girisForm">
            <div class="satir">
                <asp:TextBox ID="tb_mail" runat="server" CssClass="formMetinKutu" placeholder="Mail Adresiniz"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="formMetinKutu" placeholder="Şifreniz"></asp:TextBox>
            </div>
            <div class="satir" style="margin-top:20px">
                <a href="#" style="float:right">Şifremi Unuttum</a>
                <div style="clear:both"></div>
            </div>
            <div class="satir" style="margin-top:20px">
                <asp:LinkButton ID="lbtn_giris" runat="server" OnClick="lbtn_giris_Click" CssClass="formGirisButon">Üye Girişi Yap</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
