<%@ Page Title="" Language="C#" MasterPageFile="~/page/Home.master" AutoEventWireup="true" CodeFile="titile.aspx.cs" Inherits="page.page_titile" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="CHome" ContentPlaceHolderID="CplHome" Runat="Server">
<div class="container body-content">
    <div class="col-xs-12 col-md-3 right-main-titile">
            <ul class="nav nav-pills nav-stacked panel-left">
                <%=_htmlGetMenu %>
            </ul>
        </div>
    <div class="col-xs-12 col-md-9">
        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
            <ContentTemplate>
                <asp:ListView ID="ListViewAll" runat="server" ItemPlaceholderID="lstViewAll" OnItemDataBound="ListViewAll_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="box-news-main">
                                <img src='<%# Eval("Img_Thumb") %>' style="width: 100%;height: 180px" class="img-thumbnail" />
                                <div class="box-news">
                                    <a class="box-news" href='/detail/<%# Eval("Friendly_Url_Vn") %>'>
                                        <asp:Label ID="lb_lst_short_vn" runat="server" Text='<%# Eval("Titile_Vn") %>'/>
                                    </a>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="lstViewAll"></asp:PlaceHolder>
                    </LayoutTemplate>
                </asp:ListView>

                <asp:ListView ID="ListViewAllEn" runat="server" ItemPlaceholderID="lstViewAllEn" OnItemDataBound="ListViewAllEn_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="box-news-main">
                                <img src='<%# Eval("Img_Thumb") %>' style="width: 100%;height: 180px" class="img-thumbnail" />
                                <div class="box-news">
                                    <a class="box-news" href='/detail/<%# Eval("Friendly_Url_En") %>'>
                                        <asp:Label ID="lb_lst_short_en" runat="server" Text='<%# Eval("Titile_En") %>'/>
                                    </a>
                                </div>
                                <div class="clear"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="lstViewAllEn"></asp:PlaceHolder>
                    </LayoutTemplate>
                </asp:ListView>
                  <div class="clear"></div>
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
</asp:Content>