<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDTEST._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Panel runat="server" ID="pnlDatoaAlumno">
            <div>
                   <asp:Label Text="Nombre alumno" runat="server" />
                 <asp:TextBox id="txtNombreBus" runat="server"/> 
                <asp:Button id="btnBuscar" runat="server"  Text="Buscar" OnClick="btnBuscar_Click"/>
            </div>
            <br />

         
            <asp:GridView ID="gvdAlumnos" runat="server" AutoGenerateColumns="false" DataKeyNames="ClaveAlumno" OnRowDeleting="gvdAlumnos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ClaveAlumno" HeaderText="Clave Alumno" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electronico" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" />        
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbActualizar" runat="server" Text="Actualizar" OnClick="lkbActualizar_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnNuevo" Text="Nuevo Alumno" runat="server" OnClick="btnNuevo_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlAltaAlumno" runat="server" Visible="false">
            <div>
                <asp:Label ID="lblNombre" Text="Nombre" runat="server"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblApPaterno" Text="Apellido Paterno " runat="server"></asp:Label>
                <asp:TextBox ID="txtApPaterno" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblApMaterno" Text="Apellido Materno" runat="server" />
                <asp:TextBox ID="txtApMaterno" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblEmail" Text="Email" runat="server" />
                <asp:TextBox ID="txtEmail" runat="server" />
            </div>
            <br />        
            <asp:Label ID="lblIdAlumno" runat="server" Visible="false" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Alumno" OnClick="btnGuardar_Click" />  
            <asp:Button ID="btnActualizar" runat="server" Text="Actulizar Alumno" Visible="false" OnClick="btnActualizar_Click" />
        </asp:Panel>
    </div>

</asp:Content>
