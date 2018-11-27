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
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Plan.Descripcion" HeaderText="Plan" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>
        </asp:Panel>
        <div class="col-5">
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox ID="txtLegajo" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
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
                <asp:Label class="col-5 col-form-label" ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
                <div class="col-7">
                    <asp:DropDownList class="form-control" ID="ddlPlan" runat="server"></asp:DropDownList>
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
