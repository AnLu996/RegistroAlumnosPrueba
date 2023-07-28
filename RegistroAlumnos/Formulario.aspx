<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="RegistroAlumnos.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Segundo Laboratorio</title>

<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<!--JQuery-->
<script type="text/javascript" src="/Scripts/jquery-3.4.1.min.js"></script>
<!-- Bootstrap core CSS -->
<link rel="stylesheet" href="/Content/bootstrap.min.css" />
<script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
<script type="text/javascript" src="/Scripts/modernizr-2.8.3.js"></script>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

<script src="./Recursos\JavaScript.js"></script>
<link rel="stylesheet" href="./Recursos\StyleSheet1.css"/>

</head>

<body>
    <form id="form1" runat="server" onsubmit="return validar_contenido()">
        
        <div class="container col-8">
            <img src="https://upload.wikimedia.org/wikipedia/commons/3/3a/LOGO_UNSA.png" alt="unsa-logo" class="styleimageunsa" />
            <img src="https://semcomp-epcc-unsa.github.io/assets/images/cslogos/logo-only.png" alt="cs-logo" class="styleimagecs" />
            <div class="top">   </div>
            <div class="centrado">
                <h1>REGISTRO DE ALUMNOS:</h1> <br/>
               
            </div>
                <div class="row">
                    <label id="labelname" class="col-sm-2 col-form-label formato centrarf">Nombre:</label>
                    <div class="col-4">
                        <asp:TextBox runat="server" ID="nombre" class="form-control" type="text"  /><br/>
                    </div>
                </div>
                <div class="row rejilla">
                    <label id="labellastname" class="col-sm-2 col-form-label formato centrarf">Apellidos:</label>
                    <div class="col-4">
                        <asp:TextBox runat="server" ID="apellido" class="form-control" type="text"  /><br/>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label id="labelsex" class="col-sm-2 col-form-label formato centrarf">Sexo:</label>
                    <div class="col-4">
                        <div class="form-check form-check-inline"> 
                            <asp:RadioButton runat="server" class="form-check-input" ID="sexo_masculino" value="Masculino" />
                            <label class="form-check-label">Masculino</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:RadioButton runat="server" class="form-check-input" ID="sexo_femenino" value="Femenino" />
                            <label class="form-check-label">Femenino</label>
                        </div> 
                    </div> <br />
                </div> 

                <div class="row">
                    <label id="labelmail" class="col-sm-2 col-form-label formato centrarf">Email:</label>
                    <div class="col-4">
                       <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping">@</span>
                            <asp:TextBox runat="server" ID="email" type="text" class="form-control"/>
                       </div>
                    </div>
                </div> <br />

                <div class="row">
                    <label id="labeladress" class="col-sm-2 col-form-label formato centrarf">Dirección:</label>
                    <div class="col-4">
                        <asp:TextBox runat="server" ID="direccion" class="form-control" type="text"  /><br/>
                    </div>
                    
                        <label id="labelcity" class="col-sm-2 col-form-label formato centrarf">Ciudad:</label>
                        <div class="col-auto centrar">
                            <asp:DropDownList ID="city" class="form-control" runat="server"></asp:DropDownList><br/>
                        </div>
                 </div>
                 <div class="row">
                    <label id="labelreq" class="col-sm-2 col-form-label formato centrarf">Requerimiento:</label><br/>             
                 </div>
                 <div class="row">
                     <div class="col-xl-11">
                        <asp:TextBox runat="server" ID="requerimientos" class="form-control" cols="10" rows="4" TextMode="MultiLine"></asp:TextBox><br/>
                     </div><br/>
                 </div>
                 <div class="row justify-content-center">                    
                     <asp:Button ID="ButtonLimpiar" class="btn btn-dark" runat="server" Text="Limpiar" OnClientClick="return limpiar_contenido();"/>
                     <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" OnClientClick="var a = validar_contenido(); return a;" class="btn btn-success btn-lg" OnClick="ButtonEnviar_Click" />
                 </div>
                
            
            <div class="row">
                   <asp:Label runat="server" ID="labelreg" class="col-sm-2 col-form-label formato centrarf" visible="false">Registros:</asp:Label><br/>             
                </div>
                 <div class="row">
                     <div class="col-xl-11">
                        <asp:TextBox runat="server" ID="informacion" class="form-control formatotextbox" cols="10" rows="4" TextMode="MultiLine" visible="false" enable="false"></asp:TextBox><br/>
                     </div><br/>
                 </div>
            </div>
    </form>
</body>
</html>
