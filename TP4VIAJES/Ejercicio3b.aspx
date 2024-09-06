<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4VIAJES.Ejercicio3b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Libros</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Libros del Tema Seleccionado</h2>
            <asp:GridView ID="grvLibros" runat="server">
            </asp:GridView>
            <br />
            <asp:LinkButton ID="btnRegresar" runat="server" OnClick="btnRegresar_Click">Consultar Otro Tema</asp:LinkButton>
        </div>
    </form>
</body>
</html>
