<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CRUDTEST.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>DropDownList</h2>
    <asp:Panel runat="server" ID="pnlControls" Visible="false">
        <div>
            <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true" Width="300" />
        </div>
        <div>
            <asp:DropDownList ID="ddlMunicipio" runat="server" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged" AutoPostBack="true" Width="300" />
        </div>
        <div>
            <asp:DropDownList ID="ddlColonia" runat="server" Width="300" />
        </div>
    </asp:Panel>
    <div>
        <div>
            <asp:Label ID="lblUsuario" Text="Usuario" runat="server" />
        </div>
        <div>
            <asp:TextBox ID="txtUsuario" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblContrasena" Text="Contraseña" runat="server" />
        </div>
        <div>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" />
        </div>
        <div>
            <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
        </div>
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" />
        </div>


    </div>
</asp:Content>
