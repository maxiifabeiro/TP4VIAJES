<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4VIAJES.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
&nbsp;&nbsp;&nbsp; Seleccionar tema:&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="btnLibros" runat="server" OnClick="btnLibros_Click">Ver libros</asp:LinkButton>
        </div>
    </form>
</body>
</html>
