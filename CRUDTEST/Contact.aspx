<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CRUDTEST.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>DropDownList en cascada</h2>
    <div>
        <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true" Width="300" />
    </div>
    <div>
        <asp:DropDownList ID="ddlMunicipio" runat="server" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged" AutoPostBack="true" Width="300" />
    </div>
    <div>
        <asp:DropDownList ID="ddlColonia" runat="server" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged" AutoPostBack="true" Width="300" />
    </div>

</asp:Content>
