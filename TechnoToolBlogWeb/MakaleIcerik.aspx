<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleIcerik.aspx.cs" Inherits="TechnoToolBlogWeb.MakaleIcerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makale">
        <div class="resim">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="baslik">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="bilgi">
            <label>Kategori:</label>
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | 
         <label>Yazar:</label>
            <asp:Literal ID="ltrl_Yazar" runat="server"></asp:Literal>
            |
         <label>Tarih:</label>
            <asp:Literal ID="ltrl_Tarih" runat="server"></asp:Literal>
        </div>
        <div class="ozet">
            <asp:Literal ID="ltrl_Icerik" runat="server"></asp:Literal>
        </div>

    </div>
    <div class="yorumPanel">
        <div class="baslik">
            <h3>Yorum Paneli</h3>
        </div>
        <asp:Panel ID="pnl_girisvar" runat="server">
           <div class="satir">
                <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="formMetinKutu"></asp:TextBox>
           </div>
            <div class="satir" style="margin-top:20px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formYorumButon">Yorum Gönder</asp:LinkButton>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnl_girisYok" runat="server">
            Yorum yapabilmek için lütfen <a href="UyeGiris.aspx">Giriş </a> yapınız.
        </asp:Panel>
        <asp:Repeater ID="rp_yorumlar" runat="server">
            <ItemTemplate>
                <div>
                    <div>
                        <%#Eval("Icerik") %>
                    </div>
                    <div>
                        Uye : <%#Eval("UyeIsim") %> | Tarih : <%#Eval("YorumTarih") %> 
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
