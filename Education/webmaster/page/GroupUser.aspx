<%@ page title="Nhóm người dùng" language="C#" masterpagefile="~/webmaster/page/webmaster.master" autoeventwireup="true" inherits="webmaster.page.webmaster_page_GroupUser, App_Web_wlb4l3rd" %>
<asp:Content ID="ContentHeaderMaster" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentContentMaster" ContentPlaceHolderID="ContentPlaceHolderMainMaster" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelControlTop" runat="server">
    <ContentTemplate>
        <ul class="breadcrumb">
          <li class="active">
              <asp:LinkButton ID="linkAddNew" runat="server" OnClick="linkAddNew_Click"><i class="fa fa-plus"></i> Thêm mới</asp:LinkButton>
          </li>
          <li>
              <asp:LinkButton ID="linkSave" runat="server" OnClick="linkSave_Click" OnClientClick=" return confirmCheckOut(this);"><i class="fa fa-floppy-o"></i> Lưu lại</asp:LinkButton>
          </li>
          <li>
              <asp:LinkButton ID="linkDelete" runat="server" OnClick="linkDelete_Click" OnClientClick=" return confirmCheckIn(this);"><i class="fa fa-times"></i> Xoá</asp:LinkButton>
          </li>
          <li>
              <asp:LinkButton ID="linkRefresh" runat="server" OnClick="linkRefresh_Click"><i class="fa fa-refresh"></i> Tải lại</asp:LinkButton>
          </li>
        </ul>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="linkAddNew" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="linkSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="linkDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="linkRefresh" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
    <ContentTemplate>
        <ContentTemplate>
            <%=_Error %>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Bộ lọc và Tìm kiếm</h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-6" style="margin-top: 8px">
                        <div class="form-group">
                            <label class="control-label" style="text-align:left">Lọc theo trạng thái</label>
                            <asp:DropDownList ID="drStatus" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drStatus_Change">
                                <asp:ListItem Value="-1">--Chọn trạng thái--</asp:ListItem>
                                <asp:ListItem Value="0">Hiễn thị</asp:ListItem>
                                <asp:ListItem Value="1">Ẩn</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                       <div class="form-group" style="margin-top: 8px;">
                           <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
                               <label class="control-label">Tìm kiếm</label>
                                <div class="input-group">
                                    <input type="text" id="txtSearch" class="form-control search" title="Nhập vào tên danh mục chính có dấu hoặc không dấu" runat="server">
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click"></asp:Button>
                                    </span>
                                </div>
                           </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="table-responsive" style="margin-top: 8px">
                <table class="table table-striped table-hover table-bordered">
                    <thead>
                        <tr>
                            <th style="text-align: center;vertical-align:middle;width: 5%">ID</th>
                            <th style="text-align: center;vertical-align:middle;width: 5%">
                                <input type="checkbox" onclick=" checkAll('chkList'); " id="chkAll">
                            </th>
                            <th style="text-align: center;vertical-align:middle;width: 20%">Tên nhóm</th>
                            <th style="text-align: center;vertical-align:middle;width: 10%">Số thứ tự</th>
                            <th style="text-align: center;vertical-align:middle;width: 10%">Trạng thái</th>
                            <th style="text-align: center;vertical-align:middle; width: 15%" id="function" runat="server">Thao tác</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="Group_Id" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td style="text-align: center;vertical-align:middle">
                                        <asp:Label ID="lb_lst_row_number" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </td>

                                    <td style="text-align: center;vertical-align:middle">
                                        <asp:CheckBox ID="chkList"  ClientIDMode="Static" runat="server" />
                                    </td>
                                    
                                    <td style="vertical-align:middle;">
                                        <b>Tên nhóm : </b><asp:Label ID="lb_lst_titile_vn" runat="server" Text='<%# Eval("Group_Name") %>'></asp:Label><br/>
                                        <b>Diễn giải : </b><asp:Label ID="lb_lst_code" runat="server" Text='<%# Eval("Descripttion") %>'></asp:Label><br/>
                                        <input type="hidden" id="hiddenId" value='<%# Eval("Group_Id") %>' runat="server" name="hiddenId" />
                                    </td>
                                    
                                    <td style="vertical-align:middle;text-align: center">
                                        <asp:TextBox ID="txtNumList" title="Nhập vào một nguyên để sắp xếp danh mục" onkeypress="return ValidateKeypress(/\d/,event);" CssClass="form-control num" Text='<%# Eval("Num") %>' runat="server"></asp:TextBox>
                                    </td>
                                
                                    <td style="vertical-align:middle;text-align: center">
                                        <asp:CheckBox ID="chkHide"  Checked='<%# Eval("IsActive") %>' runat="server" />
                                    </td>

                                    <td style="text-align: center;vertical-align:middle" id="groupbtnlist" runat="server">
                                        <asp:Button ID="btnEdit_lst" CommandName="Edit_lst" CssClass="btn btn-primary btn-xs groupbutton" title="Thay đổi" runat="server" Text="Thay đổi"/>
                                        <asp:Button ID="btnDel_lst" Visible="False" CommandName="Del_lst" OnClientClick=" return confirmCheckIn(this); " CssClass="btn btn-danger btn-xs groupbutton" title="Xoá" runat="server" Text="Xoá"/>
                                    </td>
                                </tr>
                            </tbody>
                        </ItemTemplate>

                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="lstViewAll"></asp:PlaceHolder>
                        </LayoutTemplate>
                    </asp:ListView>
                    <footer>
                        <tr>
                            <td style="text-align: center" colspan="6">
                                 <asp:DataPager ID="DataPagerListAll" runat="server"
                                    OnPreRender="DataPagerListAll_PreRender" PagedControlID="ListViewAll">
                                    <Fields>
                                        <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" PreviousPageText="&lt;"
                                            ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-default btn-xs" />
                                        <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary btn-xs" NextPreviousButtonCssClass="btn btn-default btn-xs" NumericButtonCssClass="btn btn-default btn-xs" />
                                        <asp:NextPreviousPagerField LastPageText="&gt;&gt;" NextPageText="&gt;"
                                            ShowLastPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default btn-xs" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </footer>
                </table>
            </div>
        </ContentTemplate>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DataPagerListAll" EventName="PreRender"/>
        <asp:AsyncPostBackTrigger ControlID="ListViewAll" EventName="ItemCommand"/>
        <asp:AsyncPostBackTrigger ControlID="drStatus" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"/>
    </Triggers>
</asp:UpdatePanel>

<%--Modal-Popup--%>
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Cập nhật nhóm người dùng</h4>
            </div>
            <div class="modal-body modal-body-height">
                <asp:UpdatePanel ID="UpdatePanelUser" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Tên nhóm người dùng</label>
                                    <input class="form-control" id="txtModule_Main_Code" runat="server"/>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Diễn giải</label>
                                    <textarea class="form-control" id="txtTitile_Vn" runat="server"/>
                                </div>
                            </div>
                            <input class="form-control" id="txtNum" type="hidden" runat="server"/>
                            <input class="form-control" id="txtModule_Main_ID" type="hidden" runat="server"/>
                            <asp:CheckBox ID="chkHideEdit" runat="server" Visible="False" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
                <div class="clr"></div>
            </div>
            <div class="modal-footer">
                <asp:UpdatePanel ID="UpdatePanelControl" runat="server">
                    <ContentTemplate>
                        <%=_Msg %>
                        <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"/>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng lại</button>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
<%--End--%>

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
<asp:UpdateProgress ID="UpdateProgressControlBottom" runat="server" AssociatedUpdatePanelID="UpdatePanelControl">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-main">
                    <asp:Image ID="Image3" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="Label3" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--End--%>
</asp:Content>