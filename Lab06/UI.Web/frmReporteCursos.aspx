<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="frmReporteCursos.aspx.cs" Inherits="UI.Web.frmReporteCursos" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reporte</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Reporte de cursos</h2>
        </div>
        <br />

        <asp:Button ID="GenerarRepo" class="btn btn-success" runat="server" Text="Generar Nuevo Reporte" OnClick="GenerarRepo_Click" />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </form>
</asp:Content>
