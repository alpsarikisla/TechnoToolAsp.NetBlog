<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="TechnoToolBlogWeb.AdminPanel.MakaleEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makale Ekle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                <label>Makale başarıyla eklenmiştir</label>
            </asp:Panel>
            <div class="sol">
                <div class="satir">
                    <label class="formetiket">Makale Başlık</label>
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinkutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label class="formetiket">Kategori</label>
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinkutu" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="satir">
                    <label class="formetiket">Makale Özeti</label>
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="satir">
                    <label class="formetiket">Kapak Resim</label>
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu" />
                </div>
                <div class="satir">
                    <label class="formetiket">Yayın Durum</label>
                    <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" />
                    <small style="color: dimgray">(Eğer işaretli ise kategori yayınlanır)</small>
                </div>
                <div class="satir">
                    <asp:Button ID="lbtn_ekle" runat="server" CssClass="formButton" Text="Makale Ekle" OnClick="lbtn_ekle_Click" />
                </div>
            </div>
            <div class="sag">
                <div class="satir">
                    <label class="formetiket">Makale İçerik</label>
                    <asp:TextBox ID="tb_Icerik" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</asp:Content>
