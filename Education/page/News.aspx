<%@ Page Title="" Language="C#" MasterPageFile="~/page/Home.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="page.page_News" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="CHome" ContentPlaceHolderID="CplHome" Runat="Server">
    <div class="container body-content">
        <div class="col-xs-12 col-md-3 right-main-titile">
            <ul class="nav nav-pills nav-stacked panel-left">
                <%=_htmlGetMenu %>
            </ul>
        </div>
        <div class="col-md-9 news-main-1">
            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                <ContentTemplate>
                    <asp:ListView ID="ListViewAll" runat="server" ItemPlaceholderID="lstViewAll" OnItemDataBound="ListViewAll_ItemDataBound">
                       <ItemTemplate>
                           <div class="content-news">
                               <div class="col-md-3">
                                   <img src='<%# Eval("Img_Thumb") %>' style="width: 100%;height: 145px" class="img-thumbnail" />
                                </div>
                               <div class="col-md-9">
                                    <div class="titile-news">
                                        <a href='/detail/<%# Eval("Friendly_Url_Vn") %>'><%# Eval("Titile_Vn") %></a>
                                    </div>
                                    <div>
                                        <p class="short-content-news">
                                            <asp:Label ID="lb_lst_short_vn" runat="server" Text='<%# Eval("ShortContent_Vn") %>'/>
                                        </p>
                                        <span class="date-begin-news">
                                            Ngày đăng : <%# Eval("DateBegin","{0:dd-MM-yyyy}") %>
                                        </span>
                                        <span class="more-detail">
                                            <a class="more-detail" href='/detail/<%# Eval("Friendly_Url_Vn") %>'>Chi tiết</a>
                                        </span>
                                    </div>
                                </div>
                                <div class="clear"></div>
                            </div>
                           <hr class="hr"/>
                       </ItemTemplate>
                       <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="lstViewAll"></asp:PlaceHolder>
                        </LayoutTemplate>
                   </asp:ListView>

                    <asp:ListView ID="ListViewAllEn" runat="server" ItemPlaceholderID="lstViewAllEn" OnItemDataBound="ListViewAllEn_ItemDataBound">
                       <ItemTemplate>
                           <div class="content-news">
                               <div class="col-md-3">
                                   <img src='<%# Eval("Img_Thumb") %>' style="width: 100%;height: 145px" class="img-thumbnail" />
                                </div>
                               <div class="col-md-9">
                                    <div class="titile-news">
                                        <a href='/detail/<%# Eval("Friendly_Url_En") %>'><%# Eval("Titile_En") %></a>
                                    </div>
                                    <div>
                                        <p class="short-content-news">
                                            <asp:Label ID="lb_lst_short_en" runat="server" Text='<%# Eval("ShortContent_En") %>'/>
                                        </p>
                                        <span class="date-begin-news">
                                            Date Post : <%# Eval("DateBegin","{0:dd-MM-yyyy}") %>
                                        </span>
                                        <span class="more-detail">
                                            <a class="more-detail" href='/detail/<%# Eval("Friendly_Url_En") %>'>View Detail</a>
                                        </span>
                                    </div>
                                </div>
                                <div class="clear"></div>
                            </div>
                           <hr class="hr"/>
                       </ItemTemplate>
                       <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="lstViewAllEn"></asp:PlaceHolder>
                        </LayoutTemplate>
                   </asp:ListView>
                
                    <div class="pagination-main">
                        <asp:DataPager ID="DataPagerListAll" runat="server"
                            OnPreRender="DataPagerListAll_PreRender" PagedControlID="ListViewAll" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" PreviousPageText="&lt;"
                                    ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-default" />
                                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NextPreviousButtonCssClass="btn btn-default" NumericButtonCssClass="btn btn-default" />
                                <asp:NextPreviousPagerField LastPageText="&gt;&gt;" NextPageText="&gt;"
                                    ShowLastPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default" />
                            </Fields>
                        </asp:DataPager>
                        <asp:DataPager ID="DataPagerEn" runat="server"
                            OnPreRender="DataPagerEn_PreRender" PagedControlID="ListViewAllEn" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" PreviousPageText="&lt;"
                                    ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-default" />
                                <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-primary" NextPreviousButtonCssClass="btn btn-default" NumericButtonCssClass="btn btn-default" />
                                <asp:NextPreviousPagerField LastPageText="&gt;&gt;" NextPageText="&gt;"
                                    ShowLastPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-default" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DataPagerListAll" EventName="PreRender"/>
                    <asp:AsyncPostBackTrigger ControlID="ListViewAll" EventName="ItemCommand"/>
                    <asp:AsyncPostBackTrigger ControlID="DataPagerEn" EventName="PreRender"/>
                    <asp:AsyncPostBackTrigger ControlID="ListViewAllEn" EventName="ItemCommand"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdateProgress ID="UpdateProgressContentTop" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <div class="loadding">
                    <div class="loadding-main">
                        <asp:Image ID="Image1" runat="server"  ImageUrl="../webmaster/ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
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
                        <asp:Image ID="Image2" runat="server"  ImageUrl="../webmaster/ImagesLogin/fancybox_loading.gif" AlternateText="Đang tải ..." ToolTip="Đang tải ..." style="padding: 10px;top:45%;left:50%;" />
                        <span class="label label-danger">
                            <asp:Label ID="Label2" runat="server" Text="Đang tải..."/>
                        </span>  
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>