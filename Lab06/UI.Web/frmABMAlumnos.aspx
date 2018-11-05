<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmABMAlumnos.aspx.cs" Inherits="UI.Web.frmABMAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alumnos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de alumnos</h2>
        </div>
        <br />

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Label ID="lblBuscar" runat="server" Text="Buscar por Nombre de Alumno"></asp:Label>
                        <asp:TextBox ID="txtBuscar" class="form-control mx-2" runat="server"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <br />
                <asp:GridView ID="grvAlumnos" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvAlumnos_SelectedIndexChanged"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" SortExpression="NombreUsuario" />
                        <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" />
                        <asp:CheckBoxField DataField="Habilitado" HeaderText="Habilitado" SortExpression="Habilitado" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="EMail" HeaderText="EMail" SortExpression="EMail" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>
        </asp:Panel>
        <div class="col-5">
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
                <div class="col-7">
                    <asp:CheckBox ID="cbHabilitado" runat="server" class="form-control"></asp:CheckBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtNombreUsuario" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblClave" runat="server" Text="Clave: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="d-flex">
                <asp:Button class="ml-auto mr-2 btn btn-default" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="mr-2 btn btn-default" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>
        <br />
    </form>
</asp:Content>
