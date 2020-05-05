<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUDTEST.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div> 
                <div><asp:Label ID="lblUsuario" runat="server" Text="Usuario" /></div>
            </div>        
                <div>
                    <asp:TextBox ID="txtUsuario" runat="server" />
                </div>
             <div>
                 <asp:Label ID="lblContrasena" runat="server" Text="Constraseña" />
             </div>
            <div>
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" />
            </div>
            <div>
                <asp:Button id="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"/>
            </div>
        </div>
    </form>
</body>
</html>
