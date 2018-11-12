<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="frmABMEspecialidades.aspx.cs" Inherits="UI.Web.frmABMEspecialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Especialidades</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de especialidades</h2>
        </div>
        <br />    

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <asp:GridView ID="grvEspecialid" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvEspecialid_SelectedIndexChanged"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Año Calendario" SortExpression="Nombre" />                        
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>
        </asp:Panel>
        <div class="col-5">
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblDescripcion" runat="server" Text="Cupo: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtDescripcion" runat="server"></asp:TextBox>
                    <asp:Label ID="txtValidarDescripcion" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>            
        </div>
        <div class="d-flex">
            <asp:Button class="ml-auto mr-2 btn btn-default" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
            <asp:Button class="mr-2 btn btn-default" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
            <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
        </div>
        <br />
    </form>
</asp:Content>
