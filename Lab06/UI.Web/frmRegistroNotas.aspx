<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmRegistroNotas.aspx.cs" Inherits="UI.Web.frmRegistroNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Notas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Registrar notas</h2>
        </div>
        <br />
        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <div class="form-inline">
                    <div class="form-group">
                        <asp:Label ID="lblBuscar" runat="server" Text="Buscar alumnos por apellido"></asp:Label>
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
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Plan.Descripcion" HeaderText="Plan" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:GridView ID="grvAlumnosInsc" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="Curso.Materia.Descripcion" HeaderText="Materia" />
                        <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                        <asp:BoundField DataField="Nota" HeaderText="Nota" />
                    </Columns>
                </asp:GridView>

                <div class="d-flex">
                    <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
                <br />
            </div>
        </asp:Panel>
    </form>
</asp:Content>
