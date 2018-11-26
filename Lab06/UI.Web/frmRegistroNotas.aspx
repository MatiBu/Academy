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
                <div class="form-row">
                    <div class="form-group col-4">
                        <asp:Label for="DropDownList1" runat="server" Text="Carrera: "></asp:Label>
                        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group col-4">
                        <asp:Label for="DropDownList2" runat="server" Text="Materia: "></asp:Label>
                        <asp:DropDownList class="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group col-4">
                        <asp:Label for="TextBox1" runat="server" Text="Comision: "></asp:Label>
                        <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
                <br />
                <%--<asp:GridView ID="grvAlumnos" runat="server" AutoGenerateColumns="False"
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
                <br />--%>
                <br />
                <asp:GridView ID="grvAlumnosInsc" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" CssClass="table table-hover" OnRowEditing="grvAlumnosInsc_RowEditing"
                    OnRowUpdating="grvAlumnosInsc_RowUpdating" OnRowCancelingEdit="grvAlumnosInsc_RowCancelingEdit">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="Alumno.Apellido" HeaderText="Apellido" ReadOnly="True" />
                        <asp:BoundField DataField="Alumno.Nombre" HeaderText="Nombre" ReadOnly="True" />
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
