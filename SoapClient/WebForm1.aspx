<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SoapClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
    
        Listado Eventos<br />
        <asp:GridView ID="gv_datos" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:TextBox ID="txt_evento" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_fecha" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="txt_fono" runat="server"></asp:TextBox>
        <asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="Grabar" />
        <br />
        <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_num" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_rut" runat="server" Height="41px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
