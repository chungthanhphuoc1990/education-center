<%@ Page Title="" Language="C#" MasterPageFile="~/page/Home.master" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="page.page_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CplHome" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanelMain" runat="server">
        <ContentTemplate>
            <div class="col-md-12">
                <asp:TextBox ID="txtInput" TextMode="MultiLine" CssClass="form-control" runat="server"/>
            </div>
            <div class="col-md-12">
                <asp:Label ID="lbResult" runat="server" Text="lbResult"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnCountChar" CssClass="btn btn-primary" runat="server" Text="Đến ký tự" OnClick="btnCountChar_Click" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCountChar" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgressContentTop" runat="server" AssociatedUpdatePanelID="UpdatePanelMain">
    <ProgressTemplate>
            <asp:Label ID="lbProcess" runat="server" Text="Đang tải..."></asp:Label>
    </ProgressTemplate>
</asp:UpdateProgress>
</asp:Content>
