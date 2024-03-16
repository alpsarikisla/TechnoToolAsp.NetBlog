<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="TechnoToolBlogWeb.AdminPanel.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                <label>Kategori başarıyla eklenmiştir</label>
            </asp:Panel>
            <div class="satir">
                <label class="formetiket">Kategori Adı</label>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label class="formetiket">Açıklama</label>
                <asp:TextBox ID="tb_aciklama" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="satir">
                 <label class="formetiket">Yayın Durum</label>
                <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" />
                <small style="color:dimgray">(Eğer işaretli ise kategori yayınlanır)</small>
            </div>
            <div class="satir">
                <asp:Button ID="lbtn_ekle" runat="server" CssClass="formButton" Text="Kategori Ekle" OnClick="lbtn_ekle_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
