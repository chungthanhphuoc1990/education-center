<%@ page title="Thống kê truy cập" language="C#" masterpagefile="~/webmaster/page/webmaster.master" autoeventwireup="true" inherits="webmaster.page.webmaster_page_Visit_Count, App_Web_51nukgau" %>
<asp:Content ID="ContentHeaderMaster" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentContentMaster" ContentPlaceHolderID="ContentPlaceHolderMainMaster" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelControlTop" runat="server">
    <ContentTemplate>
        <ul class="breadcrumb">
          <li>
              <asp:LinkButton ID="linkSave" runat="server" OnClick="linkSave_Click" OnClientClick=" return confirmCheckOut(this);"><i class="fa fa-floppy-o"></i> Lưu lại</asp:LinkButton>
          </li>
          <li>
              <asp:LinkButton ID="linkRefresh" runat="server" OnClick="linkRefresh_Click"><i class="fa fa-refresh"></i> Tải lại</asp:LinkButton>
          </li>
        </ul>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="linkSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="linkRefresh" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
    <ContentTemplate>
        <ContentTemplate>
            <%=_Error %>
            <div class="table-responsive" style="margin-top: 8px">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th style="text-align: center;vertical-align:middle;width: 5%">ID</th>
                            <th style="text-align: center;vertical-align:middle;width: 95%">Tổng số lượng truy cập</th>
                        </tr>
                    </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center;vertical-align:middle">
                                    1
                                </td>

                                <td style="vertical-align:middle;text-align: center">
                                    <asp:TextBox ID="txtNumList" title="Nhập vào một nguyên để thay đổi số lượng thống kê" onkeypress="return ValidateKeypress(/\d/,event);" CssClass="form-control num" Text="" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                </table>
            </div>
        </ContentTemplate>
    </ContentTemplate>
</asp:UpdatePanel>
    
<%--Process--%>
<asp:UpdateProgress ID="UpdateProgressContentTop" runat="server" AssociatedUpdatePanelID="UpdatePanelControlTop">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <asp:Image ID="Image1" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="Label1" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressControlGrid" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <asp:Image ID="Image2" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="Label2" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--End--%>
</asp:Content>