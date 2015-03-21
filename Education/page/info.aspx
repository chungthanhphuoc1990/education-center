<%@ Page Title="" Language="C#" MasterPageFile="~/page/Home.master" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="page.page_info" %>
<asp:Content ID="Chead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="CHome" ContentPlaceHolderID="CplHome" runat="Server">
    <div class="container body-content">
        <div class="col-xs-12 col-md-3 right-main-titile">
            <ul class="nav nav-pills nav-stacked panel-left">
                <%--<li class="active" role="presentation">
                    <a href="#">Thu ngo</a>
                </li>
                <li role="presentation">
                    <a href="#">Gioi thieu chung</a>
                </li>
                <li role="presentation">
                    <a href="#">Thanh tuu</a>
                </li>
                <li role="presentation">
                    <a href="#">Doi ngu giao vien</a>
                </li>
                <li role="presentation">
                    <a href="#">Cac co so</a>
                </li>--%>
                <%=_htmlGetMenu %>
            </ul>
        </div>
        <div class="col-md-9 news-main-1">
            <div class="content-news">
                <%--<div class='col-md-12'>
                    <div class='titile-news'>
                        Thầy Dương Minh - Người sáng lập  Ngoại Ngữ Dương Minh phát biểu:
                        <p class='short-content-news'>
                            Hưởng ứng theo chương trình xã hội hóa giáo dục của Nhà Nước, Ngoại Ngữ Dương Minh được thành lập ngày 01 tháng 04 năm 1990. Từ đó đến nay chúng tôi không ngừng phát triển. So với thời gian ban đầu phải thuê mướn mặt bằng đến nay trường đã có cơ sở ổn định, đầy đủ trang thiết bị hiện đại, giáo viên lúc đó chỉ vài chục người nay đã có một đội ngũ hùng hậu cả về số lượng lẫn chất lượng. Giáo viên của chúng tôi là những người tận tâm với nghề, có chuyên môn giỏi và đạo đức tốt.
                            Gần 20 năm qua chúng tôi đã đào tạo được rất nhiều lớp người. Học viên của chúng tôi có cả người Việt lẫn người nước ngoài như Trung quốc, Hàn quốc, Campuchia, v. v.  hiện đang có mặt khắp nơi, ở trong nước cũng như nước ngoài và họ đang rất thành công trong nhiều lãnh vực. Chúng tôi đã được sở GDĐT thành phố Hồ Chí Minh và ĐH Cambridge tặng bằng khen trong nhiều năm liền và nhất là được sự tín nhiệm của người dân thành phố chúng ta. Hiện chúng tôi có 7 cơ sở nằm tại các quận 1, Phú Nhuận, Tân Bình, Gò Vấp. Với đủ các khối lớp cho trẻ em và người lớn đáp ứng được mọi nhu cầu của người học.
                        </p>
                    </div>
                </div>
                <div class='clr'></div>
                <hr class='hr'/>
                <div class='order-new-titile'>
                    <h2 class='order-new-titile'>Bài viết liên quan</h2>
                    <a href='#' class='order-news-titile-link'>
                        <img src='../img/red-next-icon.png' style='width: 12px;margin-right:5px;vertical-align: initial'>
                        Lễ phát bằng Starters, Movers, Flyers, Ket, Pet của Đại học Cambridge vào ngày 31/03/2013
                    </a>
                </div>--%>
                <%=_htmlDetail %>
            </div>
        </div>
    </div>
</asp:Content>