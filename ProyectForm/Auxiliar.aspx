<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auxiliar.aspx.cs" Inherits="ProyectForm.Auxiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Auxiliar</title>

<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script type="text/javascript">
        function Cookies() {
            var info = document.cookie;
            document.getElementById("cookieinfo").value = "userinfo: " + info + "\n";
            return false;
        }

        function callAjax() {
            let send = $('#cookieinfo').val();
            
            $.ajax({
                url: 'Auxiliar.aspx/getInformacion', 
                type: 'POST', 
                async: true,
                data: '{ "valor": "' + send + '" }', 
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: exito
            });
            return false;
        }

        function exito(data) {
            var returnS = data.d;
            $('#TextBoxAjax').val(data.d); 
            $('#TextBoxAjax').css('visibility', 'visible'); 
            return false;
        }

    </script>
    


    <style>
        body {
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }

        .container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            background-color: #fff;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .font-weight-bold {
            font-weight: bold;
        }

        .btn {
            font-size: 14px;
        }

        .form-control {
            resize: none;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-group">
            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario" CssClass="font-weight-bold"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="font-weight-bold"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="LabelApellido" runat="server" Text="Apellido" CssClass="font-weight-bold"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="ButtonCookie" runat="server" Text="Mostrar Cookie" class="btn btn-success btn-sm btn-block" OnClientClick="return Cookies();" />
        </div>
        <div class="form-group">
            <asp:TextBox runat="server" ID="cookieinfo" placeholder="Cookie Content" class="form-control" cols="10" rows="4" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="row mt-3">
            <div class="col-5">
                <asp:Button ID="ButtonAjax" runat="server" Text="Ajax" OnClientClick="return callAjax();" class="btn btn-success btn-lg btn-block" />
            </div>
        </div>
        <div class="form-group row mt-3">
            <div class="col-12">
                <asp:TextBox ID="TextBoxAjax" runat="server" class="form-control" cols="10" rows="4" TextMode="MultiLine" Style="visibility: hidden"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
