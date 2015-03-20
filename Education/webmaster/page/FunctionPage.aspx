<%@ page title="Phân quyền" language="C#" masterpagefile="~/webmaster/page/webmaster.master" autoeventwireup="true" inherits="webmaster.page.webmaster_page_FunctionPage, App_Web_j5ubxec3" %>
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
                    <div class="col-md-3" style="margin-top: 8px">
                        <div class="form-group">
                            <label class="control-label" style="text-align:left">Lọc theo trang chính</label>
                            <asp:DropDownList ID="drModuleMainFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drModuleMainFillter_Change">
                                <asp:ListItem Value="-1">--Chọn trang chính--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3" style="margin-top: 8px">
                        <div class="form-group">
                            <label class="control-label" style="text-align:left">Lọc theo trang con</label>
                            <asp:DropDownList ID="drModuleParrentFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drModuleParrentFillter_Change">
                                <asp:ListItem Value="-1">--Chọn trang con--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3" style="margin-top: 8px">
                        <div class="form-group">
                            <label class="control-label" style="text-align:left">Lọc theo trang danh mục</label>
                            <asp:DropDownList ID="drPageFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drPageFillter_Change">
                                <asp:ListItem Value="-1">--Chọn trang danh mục--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3" style="margin-top: 8px">
                        <div class="form-group">
                            <label class="control-label" style="text-align:left">Lọc theo nhóm</label>
                            <asp:DropDownList ID="drGroupUserFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drGroupUserFillter_Change">
                                <asp:ListItem Value="-1">--Chọn nhóm người dùng--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-12">
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
                            <th style="text-align: center;vertical-align:middle;width: 20%">Nhóm</th>
                            <th style="text-align: center;vertical-align:middle;width: 10%">Chức năng</th>
                            <th style="text-align: center;vertical-align:middle;width: 10%">Trang</th>
                            <th style="text-align: center;vertical-align:middle; width: 15%" id="function" runat="server">Thao tác</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="Function_Id" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td style="text-align: center;vertical-align:middle">
                                        <asp:Label ID="lb_lst_row_number" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </td>

                                    <td style="text-align: center;vertical-align:middle">
                                        <asp:CheckBox ID="chkList"  ClientIDMode="Static" runat="server" />
                                    </td>
                                    
                                    <td style="vertical-align:top">
                                        <b>Nhóm : </b><asp:Label ID="lb_lst_titile_vn" runat="server" Text='<%# Eval("Group_Name") %>'></asp:Label><br/>
                                        <b>Trang chính : </b><asp:Label ID="lb_lst_module_main" runat="server" Text='<%# Eval("Module_Main_Name") %>'></asp:Label><br/>
                                        <b>Trang con : </b><asp:Label ID="lb_lst_module_parrent" runat="server" Text='<%# Eval("Module_Parrent_Name") %>'></asp:Label><br/>
                                        <b>Trang danh mục : </b><asp:Label ID="lb_lst_page" runat="server" Text='<%# Eval("Page_Page_Titile_Vn") %>'></asp:Label>
                                    </td>

                                    <td style="vertical-align:top;">
                                        <b>Chức năng : </b><br/>
                                            + <asp:CheckBox ID="chkAddNew"  Checked='<%# Eval("IsbtnAddNew") %>' runat="server" Text="Thêm" /><br/>
                                            + <asp:CheckBox ID="chkEdit"  Checked='<%# Eval("IsbtnEdit") %>' runat="server" Text="Sửa" /><br/>
                                            + <asp:CheckBox ID="chkDel"  Checked='<%# Eval("IstbtnDel") %>' runat="server" Text="Xoá" /><br/>
                                            + <asp:CheckBox ID="chkUpdate"  Checked='<%# Eval("IsbtnUpdate") %>' runat="server" Text="Cập nhật" /><br/>
                                            + <asp:CheckBox ID="chkRefesh"  Checked='<%# Eval("IsbtnRefesh") %>' runat="server" Text="Tải lại" />
                                    </td>
                                
                                    <td style="vertical-align:top">
                                         <b>Trang : </b><br/>
                                            + <asp:CheckBox ID="chkPageMain"  Checked='<%# Eval("IsUsedPageMain") %>' runat="server" Text="Trang chính" /><br/>
                                            + <asp:CheckBox ID="chkPageParrent"  Checked='<%# Eval("IsUsedPageParrent") %>' runat="server" Text="Trang con" /><br/>
                                            + <asp:CheckBox ID="chkPage"  Checked='<%# Eval("IsUsedPage") %>' runat="server" Text="Trang danh mục" /><br/>
                                            <input type="hidden" id="hiddenId" value='<%# Eval("Function_Id") %>' runat="server" name="hiddenId" />
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
        <asp:AsyncPostBackTrigger ControlID="drModuleMainFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drModuleParrentFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drGroupUserFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drPageFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"/>
    </Triggers>
</asp:UpdatePanel>

<%--Modal-Popup--%>
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Phân quyền</h4>
            </div>
            <div class="modal-body modal-body-height">
                <asp:UpdatePanel ID="UpdatePanelUser" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                            <div class="col-md-12" style="margin-top: 8px">
                                <div class="form-group">
                                    <label class="control-label" style="text-align:left">Chọn trang chính</label>
                                    <asp:DropDownList ID="drModuleMain" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drModuleMain_Change">
                                        <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: 8px">
                                <div class="form-group">
                                    <label class="control-label" style="text-align:left">Chọn trang con</label>
                                    <asp:DropDownList ID="drModuleParrent" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                        <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: 8px">
                                <div class="form-group">
                                    <label class="control-label" style="text-align:left">Chọn trang danh mục</label>
                                    <asp:DropDownList ID="drPage" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                        <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12" style="margin-top: 8px">
                                <div class="form-group">
                                    <label class="control-label" style="text-align:left">Chọn nhóm</label>
                                    <asp:DropDownList ID="drGroupUser" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                        <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                     <label class="control-label">Chức năng</label>
                                    <table class="table" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIsbtnAddNew" Text="Thêm mới"/>
                                            </td>
                                            <td>
                                                 <asp:CheckBox runat="server" ID="chkIsbtnEdit" Text="Sửa"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIstbtnDel" Text="Xoá"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIsbtnUpdate" Text="Cập nhật"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIsbtnRefesh" Text="Tải lại"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIsUsedPageMain" Text="Trang chính"/>
                                            </td>
                                            <td>
                                                 <asp:CheckBox runat="server" ID="chkIsUsedPageParrent" Text="Trang con"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkIsUsedPage" Text="Trang danh mục"/>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"/>
                        <asp:AsyncPostBackTrigger ControlID="drModuleMain" EventName="SelectedIndexChanged"/>
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