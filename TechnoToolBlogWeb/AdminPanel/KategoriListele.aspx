<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="TechnoToolBlogWeb.AdminPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategoriler</h3>
        </div>
        <asp:ListView ID="lv_kategoriler" runat="server">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="tablo">
                    <tr>
                        <th style="text-align:center">ID</th>
                        <th>Isim</th>
                        <th>Açıklama</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Aciklama") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td>
                        <a href="#" class="tablebuttonduzenle">Düzenle</a>
                         <a href="#" class="tablebuttonsil">Sil</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>


</asp:Content>
