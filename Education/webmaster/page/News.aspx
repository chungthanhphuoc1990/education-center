<%@ page title="Tin tức" language="C#" masterpagefile="~/webmaster/page/webmaster.master" autoeventwireup="true" inherits="webmaster.page.webmaster_page_News, App_Web_j5ubxec3" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
        <%=_Error %>
            
        <div class="panel panel-primary">
            <div class="panel-heading">
            <h3 class="panel-title">Bộ lọc và Tìm kiếm</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-3" style="margin-top: 8px">
                    <div class="form-group">
                        <label class="control-label" style="text-align:left">Chọn danh mục chính</label>
                        <asp:DropDownList ID="drCatalogMainFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drCatalogMainFillter_Change">
                            <asp:ListItem Value="-1">--Chọn danh mục chính--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3" style="margin-top: 8px">
                    <div class="form-group">
                        <label class="control-label" style="text-align:left">Lọc theo danh mục con</label>
                        <asp:DropDownList ID="drCatalogParrentFillter" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drCatalogParrentFillter_Change">
                            <asp:ListItem Value="-1">--Chọn danh mục chính--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3" style="margin-top: 8px">
                    <div class="form-group">
                        <label class="control-label" style="text-align:left">Lọc theo trạng thái</label>
                        <asp:DropDownList ID="drStatus" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drStatus_Change">
                            <asp:ListItem Value="-1">--Chọn trạng thái--</asp:ListItem>
                            <asp:ListItem Value="0">Hiễn thị</asp:ListItem>
                            <asp:ListItem Value="1">Ẩn</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3" style="margin-top: 8px">
                    <div class="form-group">
                        <label class="control-label" style="text-align:left">Lọc theo tin nóng</label>
                        <asp:DropDownList ID="drIsHot" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged ="drIsHot_Change">
                            <asp:ListItem Value="-1">--Chọn trạng thái--</asp:ListItem>
                            <asp:ListItem Value="0">Tin bình thường</asp:ListItem>
                            <asp:ListItem Value="1">Tin nóng</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Panel ID="PanelSearch" runat="server" DefaultButton="btnSearch">
                            <label class="control-label">Tìm kiếm</label>
                            <div class="input-group">
                                <input type="text" id="txtSearch" class="form-control search" title="Nhập vào tên danh mục con có dấu hoặc không dấu" runat="server">
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
                        <th style="text-align: center;vertical-align:middle;width: 15%">Tiêu đề tiếng Việt</th>
                        <th style="text-align: center;vertical-align:middle;width: 15%">Tiêu đề tiếng Anh</th>
                        <th style="text-align: center;vertical-align:middle;width: 15%">Số thứ tự</th>
                        <th style="text-align: center;vertical-align:middle;width: 10%">Trạng thái</th>
                        <th style="text-align: center;vertical-align:middle;width: 10%">Tin nóng</th>
                        <th style="text-align: center;vertical-align:middle;width: 10%">Slide show</th>
                        <th style="text-align: center;vertical-align:middle; width: 15%" id="function" runat="server">Thao tác</th>
                    </tr>
                </thead>
                <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="ID_News" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
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
                                    <b>Tiêu đề : </b><asp:Label ID="lb_lst_titile_vn" runat="server" Text='<%# Eval("Titile_Vn") %>'></asp:Label><br/>
                                    <b>Thuộc : </b><asp:Label ID="lb_lst_MainMenu" runat="server" Text='<%# Eval("Catalog_Main_Titile_Vn") %>'></asp:Label> ==>
                                    <asp:Label ID="lb_lst_ParrentMenu" runat="server" Text='<%# Eval("Catalog_Prarent_Titile_Vn") %>'></asp:Label><br/>
                                    <b>Ngày bắt đầu : </b><asp:Label ID="lb_lst_DateBegin" runat="server" Text='<%# Eval("DateBegin","{0:dd-MM-yyyy}") %>'></asp:Label><br/>
                                    <b>Ngày bắt KT : </b><asp:Label ID="lb_lst_DateEnd" runat="server" Text='<%# Eval("DateEnd","{0:dd-MM-yyyy}") %>'></asp:Label><br/>
                                    <b>Url : </b><asp:Label ID="lb_lst_friendly_url_vn" runat="server" Text='<%# Eval("Friendly_Url_Vn") %>'></asp:Label>
                                    <input type="hidden" id="hiddenId" value='<%# Eval("ID_News") %>' runat="server" name="hiddenId" />
                                </td>
                                    
                                <td style="vertical-align:middle;">
                                    <b>Tiêu đề : </b> <asp:Label ID="lb_lst_titile_en" runat="server" Text='<%# Eval("Titile_En") %>'></asp:Label><br/>
                                    <b>Thuộc : </b><asp:Label ID="lb_lst_MainMenuEn" runat="server" Text='<%# Eval("Catalog_Main_Titile_En") %>'></asp:Label> ==>
                                    <asp:Label ID="lb_lst_ParrentMenuEn" runat="server" Text='<%# Eval("Catalog_Prarent_Titile_En") %>'></asp:Label><br/>
                                    <b>Ngày bắt đầu : </b><asp:Label ID="lb_lst_DateBeginEn" runat="server" Text='<%# Eval("DateBegin","{0:dd-MM-yyyy}") %>'></asp:Label><br/>
                                    <b>Ngày bắt KT : </b><asp:Label ID="lb_lst_DateEndVn" runat="server" Text='<%# Eval("DateEnd","{0:dd-MM-yyyy}") %>'></asp:Label><br/>
                                    <b>Url : </b> <asp:Label ID="lb_lst_Friendly_Url_En" runat="server" Text='<%# Eval("Friendly_Url_En") %>'></asp:Label>
                                </td>

                                <td style="vertical-align:middle;text-align: center">
                                    <asp:TextBox ID="txtNumList" title="Nhập vào một nguyên để sắp xếp danh mục" onkeypress="return ValidateKeypress(/\d/,event);" CssClass="form-control num" Text='<%# Eval("Num") %>' runat="server"></asp:TextBox>
                                </td>
                                
                                <td style="vertical-align:middle;text-align: center">
                                    <asp:CheckBox ID="chkHide"  Checked='<%# Eval("IsActive") %>' runat="server" />
                                </td>
                                    
                                <td style="vertical-align:middle;text-align: center">
                                    <asp:CheckBox ID="chkIsHot"  Checked='<%# Eval("IsHot") %>' runat="server" />
                                </td>
                                
                                <td style="vertical-align:middle;text-align: center">
                                    <asp:CheckBox ID="chkIsSlide"  Checked='<%# Eval("IsSlide") %>' runat="server" />
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
                        <td style="text-align: center" colspan="8">
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
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DataPagerListAll" EventName="PreRender"/>
        <asp:AsyncPostBackTrigger ControlID="ListViewAll" EventName="ItemCommand"/>
        <asp:AsyncPostBackTrigger ControlID="drCatalogMainFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drStatus" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drCatalogParrentFillter" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="drIsHot" EventName="SelectedIndexChanged"/>
        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"/>
    </Triggers>
</asp:UpdatePanel>    

<%--Modal-Popup--%>
<div class="modal fade modal-width-homepage" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header modal-header-background">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 class="modal-title modal-titile">Cập nhật tin tức</h4>
        </div>
        <div class="modal-body modal-body-height">
            <asp:UpdatePanel ID="UpdatePanelUser" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                        <div class="col-md-3">
                            <div class="form-group">
                               <label class="control-label">Chọn trình đơn chính</label>
                                <asp:DropDownList ID="drCatalogMain" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="drCatalogMain_Change">
                                    <asp:ListItem Value="=-1">--Chọn--</asp:ListItem>
                                </asp:DropDownList> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                               <label class="control-label">Chọn trình đơn con</label>
                                <asp:DropDownList ID="drCatalogPrarent" CssClass="form-control" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                    <asp:ListItem Value="=-1">--Chọn--</asp:ListItem>
                                </asp:DropDownList> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Tiêu đề tiếng Việt</label>
                                <input class="form-control" id="txtTitile_Vn" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Tiêu đề tiếng Anh</label>
                                <input class="form-control" id="txtTitile_En" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Đường dẩn thân thiện tiếng Việt</label>
                                <input class="form-control" id="txtFrienlyUrl_Vn" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Đường dẩn thân thiện tiếng Anh</label>
                                <input class="form-control" id="txtFrienlyUrl_En" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <label class="control-label">Thêm ảnh</label>
                            <div class="input-group">
                                <input class="form-control imgurl" id="txtImages" type="text" runat="server" readonly="readonly" />
                                <span class="input-group-btn">
                                    <input class="btn btn-default" type="button" value="Thêm ảnh" onclick="onclickBrowser()" />
                                    <input class="btn btn-default" type="button" value="Xem ảnh" runat="server" onserverclick="btnViewImage_OnClick" />
                                    <input class="btn btn-default" type="button" value="Xoá ảnh" runat="server" onserverclick="btnDelImages_OnClick" />
                                </span>
                             </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                               <label class="control-label">Chiều rộng</label>
                                <input class="form-control num" id="txtWidth" title="Chiều rộng ảnh là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                               <label class="control-label">Chiều cao</label>
                                <input class="form-control num" id="txtHeight" title="Chiều cao ảnh là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <label class="control-label">Thêm ảnh Thumb</label>
                            <div class="input-group">
                                <input class="form-control imgurlthumb" id="txtThumb" type="text" runat="server" readonly="readonly" />
                                <span class="input-group-btn">
                                    <input class="btn btn-default" type="button" value="Thêm ảnh" onclick="onclickBrowserThumb()" />
                                    <input class="btn btn-default" type="button" value="Xem ảnh" runat="server" onserverclick="btnViewImage_OnClick" />
                                    <input class="btn btn-default" type="button" value="Xoá ảnh" runat="server" onserverclick="btnDelImages_OnClick" />
                                </span>
                                </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Chiều rộng</label>
                                <input class="form-control num" id="txtWidthThumb" title="Chiều rộng ảnh là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">Chiều cao</label>
                                <input class="form-control num" id="txtHegithThumb" title="Chiều cao ảnh là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Url (nếu có)</label>
                                <input class="form-control" id="txtUrl" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Mô tả ngắn tiếng Việt</label>
                                <CKEditor:CKEditorControl ID="txtShortContent_Vn" runat="server" Height="250px"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Mô tả ngắn tiếng Anh</label>
                                <CKEditor:CKEditorControl ID="txtShortContent_En" runat="server" Height="250px"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Nội dung tiếng Việt</label>
                                <CKEditor:CKEditorControl ID="txtDescription_Vn" runat="server" Height="250px"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Nội dung tiếng Anh</label>
                                <CKEditor:CKEditorControl ID="txtDescription_En" runat="server" Height="250px"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Keywords Titile</label>
                                <input class="form-control" id="txtKeywordsTitile" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Keywords ShortContent</label>
                                <textarea class="form-control" id="txtKeywordsShortContent" rows="3" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Keywords Description</label>
                                <textarea class="form-control" id="txtKeywordsDescriptions" rows="3" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Tin nóng</label>
                                <asp:CheckBox ID="chkIsHotNews" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Hiễn thị trang chủ</label>
                                <asp:CheckBox ID="chkIsSilde" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Ngày bắt đầu</label>
                                <input class="form-control daytime" id="txtDateBegin" runat="server"/>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label" style="text-align:left">Ngày kết thúc</label>
                                <input class="form-control daytime" id="txtDateEnd" runat="server"/>
                            </div>
                        </div>
                        <input class="form-control" id="txtNum" type="hidden" runat="server"/>
                        <asp:CheckBox ID="chkHideEdit" runat="server" Visible="False" />
                </ContentTemplate>
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
                <asp:AsyncPostBackTrigger ControlID="drCatalogMain" EventName="SelectedIndexChanged"/>
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
                <div class="loadding-Prarent">
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
                <div class="loadding-Prarent">
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
                <div class="loadding-Prarent">
                    <asp:Image ID="Image3" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="Label3" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgressControlCenter" runat="server" AssociatedUpdatePanelID="UpdatePanelUser">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <div class="loadding">
                <div class="loadding-Prarent">
                    <asp:Image ID="Image4" runat="server"  ImageUrl="../ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                    <span class="label label-danger">
                        <asp:Label ID="Label4" runat="server" Text="Đang tải..."/>
                    </span>  
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--End--%>
<%--Call-File-Upload--%>
<script  type="text/javascript">
    function onclickBrowser() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".imgurl").val(fileUrl);
        };
        finder.popup();
    }
    function onclickBrowserThumb() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".imgurlthumb").val(fileUrl);
        };
        finder.popup();
    }
</script>
</asp:Content>