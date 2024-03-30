<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnoToolBlogWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <div class="makale">
                <div class="resim">
                    <img src='Resimler/MakaleResimleri/<%# Eval("KapakResim") %>' />
                </div>
                <div class="baslik">
                    <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>
                        <h2>
                            <%# Eval("Baslik") %>
                        </h2>
                    </a>
                </div>
                <div class="bilgi">
                    <label>Kategori:</label>
                    <%# Eval("Kategori") %> | 
                    <label>Yazar:</label>
                    <%# Eval("Yazar") %> |
                    <label>Tarih:</label>
                    <%# Eval("TarihStr") %>
                </div>
                <div class="ozet">
                    <%# Eval("Ozet") %>
                </div>
                <div class="devami">
                    <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>Devamını Oku...</a>
                </div>

            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
