<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCamiones.aspx.cs" Inherits="Transporte_3Capas_Gen13.Catalogos.Camiones.FormularioCamiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="subTitulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%-- Formulario --%>
                <div class="form-group">
                    <%-- Etiquetado --%>
                    <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
                    <%-- Campo --%>
                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
                    <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblKilometraje" runat="server" Text="Kilometraje"></asp:Label>
                    <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblModelo" runat="server" Text="Modelo"></asp:Label>
                    <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de Camión"></asp:Label>
                    <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>

                    <%-- Campos especiales --%>
                    <br />
                    <br />
                    <asp:Label ID="lblDisponibilidad" runat="server" Text="Disponibilidad"></asp:Label>
                    <br />
                    <asp:CheckBox ID="chkDisponibilidad" runat="server" />
                    <br />
                    <br />

                    <asp:Label ID="lblImagen" runat="server" Text="Imagen"></asp:Label>
                    <input type="file" id="subeImagen" runat="server" class="btn btn-group"/>
                    <asp:Button ID="btnSubeImagen" runat="server" CssClass="btn btn-primary" Text="Subir Imagen" OnClick="btnSubeImagen_Click"/>

                    <asp:Label ID="lblUrlFoto" runat="server" Text="Foto"></asp:Label>

                    <asp:Image ID="imgFoto" Width="100" Height="100" runat="server" />
                    <asp:Image ID="imgCamion" Width="100" Height="100" runat="server" />

                    <asp:Label ID="urlFoto" runat="server"></asp:Label>

                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
