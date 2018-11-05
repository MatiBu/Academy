<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="frmABMCursos.aspx.cs" Inherits="UI.Web.frmABMCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cursos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de cursos</h2>
        </div>
        <br />

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar por Nombre de Usuario"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
                <br />
                <br />
                <asp:GridView ID="grvCursos" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvCursos_SelectedIndexChanged"
                    
                    DataKeyNames="ID">
                    <Columns>                        
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="NombreUsuario" HeaderText="Descripcion" SortExpression="Descripcion" />
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
        <div>
            <br />
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
            <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
            <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        <br />      
    </form>
</asp:Content>
