<%@ page title="Cấu hình trang tĩnh" language="C#" masterpagefile="~/webmaster/page/webmaster.master" autoeventwireup="true" inherits="webmaster.page.webmaster_page_Page_Setting, App_Web_j5ubxec3" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="ContentHeaderMaster" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentContentMaster" ContentPlaceHolderID="ContentPlaceHolderMainMaster" Runat="Server">
<asp:UpdatePanel ID="UpdatePanelControlTop" runat="server">
    <ContentTemplate>
        <ul class="breadcrumb">
          <li>
              <asp:LinkButton ID="linkRefresh" runat="server" OnClick="linkRefresh_Click"><i class="fa fa-refresh"></i> Tải lại</asp:LinkButton>
          </li>
        </ul>
    </ContentTemplate>
    <Triggers>
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
                            <th style="text-align: center;vertical-align:middle;width: 5%">
                                <input type="checkbox" onclick=" checkAll('chkList'); " id="chkAll">
                            </th>
                            <th style="text-align: center;vertical-align:middle;width: 20%">Tiêu đề trang</th>
                            <th style="text-align: center;vertical-align:middle;width: 20%">Cuối trang</th>
                            <th style="text-align: center;vertical-align:middle;width: 15%">Icon</th>
                            <th style="text-align: center;vertical-align:middle;width: 15%">Logo</th>
                            <th style="text-align: center;vertical-align:middle;width: 10%">Banner</th>
                            <th style="text-align: center;vertical-align:middle; width: 10%" id="function" runat="server">Thao tác</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="ListViewAll" runat="server" DataKeyNames="ID_Page" ItemPlaceholderID="lstViewAll" OnItemCommand="ListViewAll_ItemCommand" OnItemDataBound="ListViewAll_ItemDataBound">
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
                                        <asp:Label ID="lb_lst_titile_vn" runat="server" Text='<%# Eval("Page_Titile") %>'></asp:Label>
                                        <input type="hidden" id="hiddenId" value='<%# Eval("ID_Page") %>' runat="server" name="hiddenId" />
                                    </td>
                                    
                                    <td style="vertical-align:middle;">
                                        <asp:Label ID="lb_lst_titile_en" runat="server" Text='<%# Eval("Page_Footer") %>'></asp:Label>
                                    </td>
                                    
                                    <td style="vertical-align:middle;text-align: center">
                                        <asp:Image ID="lst_images_logo" ImageAlign="Middle" ImageUrl='<%# Eval("Page_Logo") %>' Width="120px" Height="120px" runat="server"></asp:Image>
                                    </td>
                                            
                                    <td style="vertical-align:middle;text-align: center">
                                        <asp:Image ID="lst_images_icon" ImageAlign="Middle" ImageUrl='<%# Eval("Page_Icon") %>' Width="120px" Height="120px" runat="server"></asp:Image>
                                    </td>
                                            
                                    <td style="vertical-align:middle;text-align: center">
                                        <asp:Image ID="lst_images_banner" ImageAlign="Middle" ImageUrl='<%# Eval("Page_Banner") %>' Width="120px" Height="120px" runat="server"></asp:Image>
                                    </td>

                                    <td style="text-align: center;vertical-align:middle" id="groupbtnlist" runat="server">
                                        <asp:Button ID="btnEdit_lst" Visible="False" CommandName="Edit_lst" CssClass="btn btn-primary btn-xs groupbutton" title="Thay đổi" runat="server" Text="Thay đổi"/>
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
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DataPagerListAll" EventName="PreRender"/>
        <asp:AsyncPostBackTrigger ControlID="ListViewAll" EventName="ItemCommand"/>
    </Triggers>
</asp:UpdatePanel>
    
<%--Modal-Popup--%>
<div class="modal fade modal-width-homepage" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header modal-header-background">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title modal-titile">Cập nhật trang tĩnh</h4>
            </div>
            <div class="modal-body modal-body-height">
                <asp:UpdatePanel ID="UpdatePanelUser" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbID" runat="server" Text="" Visible="False"></asp:Label>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Tiêu đề đầu rang</label>
                                    <input class="form-control" id="txtTitile_Vn" runat="server"/>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label" style="text-align:left">Tiêu đề cuối trang</label>
                                    <CKEditor:CKEditorControl ID="txtFooter_En" runat="server" Height="250px"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Thêm Logo</label>
                                <div class="input-group">
                                    <input class="form-control imgurl" id="txtImgLogo" type="text" runat="server" readonly="readonly" />
                                    <span class="input-group-btn">
                                        <input class="btn btn-default" type="button" value="Thêm ảnh" onclick="onclickBrowser()" />
                                        <input class="btn btn-default" type="button" value="Xem ảnh" runat="server" onserverclick="btnViewImage_OnClick" />
                                        <input class="btn btn-default" type="button" value="Xoá ảnh" runat="server" onserverclick="btnDelImages_OnClick" />
                                    </span>
                                 </div>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Thêm Banner</label>
                                <div class="input-group">
                                    <input class="form-control imgurbanner" id="txtBanner" type="text" runat="server" readonly="readonly" />
                                    <span class="input-group-btn">
                                        <input class="btn btn-default" type="button" value="Thêm ảnh" onclick="onclickBrowserBanner()" />
                                        <input class="btn btn-default" type="button" value="Xem ảnh" runat="server" onserverclick="btnViewImage_OnClick" />
                                        <input class="btn btn-default" type="button" value="Xoá ảnh" runat="server" onserverclick="btnDelImages_OnClick" />
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Thêm Icon</label>
                                <div class="input-group">
                                    <input class="form-control imguricon" id="txtIcon" type="text" runat="server" readonly="readonly" />
                                    <span class="input-group-btn">
                                        <input class="btn btn-default" type="button" value="Thêm ảnh" onclick="onclickBrowserIcon()" />
                                        <input class="btn btn-default" type="button" value="Xem ảnh" runat="server" onserverclick="btnViewImage_OnClick" />
                                        <input class="btn btn-default" type="button" value="Xoá ảnh" runat="server" onserverclick="btnDelImages_OnClick" />
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="control-label">Bản đồ</label>
                                    <input class="form-control" id="txtMapUrl" runat="server"/>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                   <label class="control-label">Chiều rộng</label>
                                    <input class="form-control num" id="txtWidth" title="Chiều rộng bản đồ là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                   <label class="control-label">Chiều cao</label>
                                    <input class="form-control num" id="txtHeight" title="Chiều cao bản đồ là một số nguyên" onkeypress="return ValidateKeypress(/\d/,event);" runat="server"/>
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
<%--Call-File-Upload--%>
<script  type="text/javascript">
    function onclickBrowser() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".imgurl").val(fileUrl);
        };
        finder.popup();
    }
    function onclickBrowserBanner() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".imgurbanner").val(fileUrl);
        };
        finder.popup();
    }
    function onclickBrowserIcon() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".imguricon").val(fileUrl);
        };
        finder.popup();
    }
</script>
</asp:Content>