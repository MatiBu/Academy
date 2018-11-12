<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmABMComisiones.aspx.cs" Inherits="UI.Web.frmABMComisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Comisiones</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de comisiones</h2>
        </div>
        <br />

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Label ID="lblBuscar" runat="server" Text="Buscar comisiones por descripcion"></asp:Label>
                        <asp:TextBox ID="txtBuscar" class="form-control mx-2" runat="server"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <br />
                <asp:GridView ID="grvComisiones" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvComisiones_SelectedIndexChanged"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Nombre" />
                        <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año" />
                        <asp:BoundField DataField="Plan.Descripcion" HeaderText="Plan" />
                        <asp:BoundField DataField="Plan.Especialidad.Descripcion" HeaderText="Especialidad" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />

                <div class="col-5">
                    <div class="form-group row">
                        <asp:Label class="col-5 col-form-label" ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                        <div class="col-7">
                            <asp:TextBox class="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                            <asp:Label ID="lblValidaCupo" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label class="col-5 col-form-label" ID="lblAnioCalendario" runat="server" Text="Año Calendario: "></asp:Label>
                        <div class="col-7">
                            <asp:TextBox class="form-control" ID="txtAnioEspecialidad" runat="server"></asp:TextBox>
                            <asp:Label ID="lblAñoCalendario" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label class="col-5 col-form-label" ID="Label1" runat="server" Text="Plan: "></asp:Label>
                        <div class="col-7">
                            <asp:DropDownList class="form-control" ID="ddlPlan" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblValidarPlan" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label class="col-5 col-form-label" ID="Label2" runat="server" Text="Especialidad: "></asp:Label>
                        <div class="col-7">
                            <asp:DropDownList class="form-control" ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblValidarEspecialidad" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="d-flex">
                    <asp:Button class="ml-auto mr-2 btn btn-default" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
                <br />
            </div>
        </asp:Panel>

    </form>
</asp:Content>
