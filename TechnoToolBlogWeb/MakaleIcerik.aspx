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
</asp:Content>
