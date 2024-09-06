<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4VIAJES.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de Destinos</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #ffffff;
            color: #000000;
            padding: 20px;
        }

        .form-container {
            width: 300px;
            margin: 0 auto;
            border: 1px solid #cccccc;
            padding: 15px;
            background-color: #f9f9f9;
        }

        .form-container h2 {
            color: #4A0D67;
            font-size: 18px;
            margin-bottom: 10px;
        }

        .form-container label {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }

        .form-container select {
            width: 100%;
            padding: 5px;
            margin-top: 5px;
        }

        .form-container .section-title {
            color: #4A0D67;
            font-weight: bold;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Destino Inicio</h2>
            <label for="ddlPronviaInicio">Provincia:</label>
            <asp:DropDownList ID="ddlProvinciaInicio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged"  >
            </asp:DropDownList>

            <label for="ddlLocalidadInicio">Localidad:</label>
            <asp:DropDownList ID="ddlLocalidadInicio" runat="server">
            </asp:DropDownList>

            <h2 class="section-title">Destino Final</h2>
            <label for="ddlProvinciaFinal">Provincia:</label>
            <asp:DropDownList ID="ddlProvinciaFinal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged">
            </asp:DropDownList>

            <label for="ddlLocalidadFinal">Localidad:</label>
            <asp:DropDownList ID="ddlLocalidadFinal" runat="server">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
