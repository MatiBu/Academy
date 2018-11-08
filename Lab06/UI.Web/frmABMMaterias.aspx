<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="frmABMMaterias.aspx.cs" Inherits="UI.Web.frmABMMaterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Materias</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de materias</h2>
        </div>
        <br />    

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <asp:GridView ID="grvMaterias" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvMaterias_SelectedIndexChanged"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion de Materia" SortExpression="Nombre" />
                        <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" SortExpression="Nombre" />
                        <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" />
                        <asp:BoundField DataField="DescripcionPlan" HeaderText="Descripcion del Plan" />
                        <%--<asp:BoundField DataField="DescripcionMateria" HeaderText="Materia" />--%>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>
        </asp:Panel>

        <div class="col-5">
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaDescripcion" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblHorasTotales" runat="server" Text="Horas Totales: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtHorasTotales" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaHorasTotales" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>            
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblHorasSemanales" runat="server" Text="Horas semanales: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtHoraSemanales" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaHorasSem" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
                <div class="col-7">
                    <asp:dropDownList class="form-control" ID="ddlPlanes" runat="server" Width="105px"></asp:dropDownList>
                    <asp:Label ID="lblValidaPlan" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
        </div>
        <div class="d-flex">
            <asp:Button class="ml-auto mr-2 btn btn-default" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>
            <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
            <asp:Button class="mr-2 btn btn-default" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
            <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
        </div>

    </form>
</asp:Content>
