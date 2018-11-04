<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmABMAlumnos.aspx.cs" Inherits="UI.Web.frmAlumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

     <form id="form1" runat="server">

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar por Nombre de Usuario"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <br />
                <br />
                <asp:GridView ID="grvAlumnos" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvAlumnos_SelectedIndexChanged"
                    
                    DataKeyNames="ID">
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
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="cbHabilitado" runat="server"></asp:CheckBox>
            <br />
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: "></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
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
